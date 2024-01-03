using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ISecurityQuestionService
    {
        Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync();
    }
}
