using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(Customer customer);
        Task<long?> LoginAsync(string email, string password);
        Task<bool> RecoverPasswordAsync(string email, string securityQuestionCode, string securityAnswer, string newPassword);
    }
}
