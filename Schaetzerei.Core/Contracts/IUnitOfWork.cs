using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schaetzerei.Core.Contracts.Repositories;

namespace Schaetzerei.Core.Contracts
{
    public interface IUnitOfWork
    {
        //Repos
        IUserRepository UserRepository { get; }
        IGameRepository GameRepository { get; }
        IRoundRepository RoundRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }

        Task<int> SaveChangesAsync();
        Task DeleteDatabaseAsync();
        Task MigrateDatabaseAsync();
    }
}
