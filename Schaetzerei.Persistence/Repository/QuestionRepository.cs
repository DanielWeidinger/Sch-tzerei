using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schaetzerei.Core.Contracts.Repositories;

namespace Schaetzerei.Persistence.Repository
{
    class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
