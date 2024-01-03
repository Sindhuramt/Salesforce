using Library.Data;
using Library.Entity;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Implementation
{
    public class SecurityQuestionService : ISecurityQuestionService
    {
        private readonly LibraryDbContext _dbContext;

        public SecurityQuestionService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync()
        {
            return await _dbContext.SecurityQuestions.ToListAsync();
        }
    }
}
