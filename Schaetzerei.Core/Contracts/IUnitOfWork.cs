using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schaetzerei.Core.Contracts.Repositories;

namespace Schaetzerei.Core.Contracts
{
    interface IUnitOfWork
    {
        //Repos
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync();
        Task DeleteDatabaseAsync();
        Task MigrateDatabaseAsync();
    }
}
