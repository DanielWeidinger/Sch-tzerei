﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schaetzerei.Core.Contracts;
using Schaetzerei.Core.Contracts.Repositories;
using Schaetzerei.Persistence.Repository;

namespace Schaetzerei.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        /// <summary>
        /// ConnectionString kommt aus den appsettings.json
        /// </summary>
        public UnitOfWork() : this(new ApplicationDbContext())
        {
        }

        /// <summary>
        /// ConnectionString kommt aus den appsettings.json
        /// </summary>
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
            GameRepository = new GameRepository(_dbContext);
            RoundRepository = new RoundRepository(_dbContext);
            QuestionRepository = new QuestionRepository(_dbContext);
            AnswerRepository = new AnswerRepository(_dbContext);

        }

        public IUserRepository UserRepository { get; }
        public IGameRepository GameRepository { get; }
        public IRoundRepository RoundRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IAnswerRepository AnswerRepository { get; }


        public async Task DeleteDatabaseAsync()
        {
            await _dbContext.Database.EnsureDeletedAsync();
        }

        public async Task MigrateDatabaseAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                 || entity.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToArray();  // Geänderte Entities ermitteln
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity, null, null);
                if (entity is IDatabaseValidatableObject)
                {     // UnitOfWork injizieren, wenn Interface implementiert ist
                    validationContext.InitializeServiceProvider(serviceType => this);
                }

                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties: true);
                if (!isValid)
                {
                    var memberNames = new List<string>();
                    List<ValidationException> validationExceptions = new List<ValidationException>();
                    foreach (ValidationResult validationResult in validationResults)
                    {
                        validationExceptions.Add(new ValidationException(validationResult, null,
                                validationResult.MemberNames));
                        memberNames.AddRange(validationResult.MemberNames);
                    }
                    if (validationExceptions.Count == 1)  // eine Validationexception werfen
                    {
                        throw validationExceptions.Single();
                    }
                    else  // AggregateException mit allen ValidationExceptions als InnerExceptions werfen
                    {
                        throw new ValidationException($"Entity validation failed for {string.Join(", ", memberNames)}",
                            new AggregateException(validationExceptions));
                    }
                }
            }
            return await _dbContext.SaveChangesAsync();
        }


        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    await _dbContext.DisposeAsync();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void ClearChangeTracker()
        {
            _dbContext.ChangeTracker.Clear();
        }

        public void Reload(IEntityObject entity)
        {
            _dbContext.Entry(entity).Reload();
        }

        public bool ContextHasChanges => _dbContext.ChangeTracker.HasChanges();

    }
}
