using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schaetzerei.Core.Contracts.Repositories;

namespace Schaetzerei.Persistence.Repository
{
    class RoundRepository : IRoundRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoundRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
