// UserService.cs
using Library.Data;
using Library.Entity;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly LibraryDbContext _dbContext;

    public UserService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> RegisterUserAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<long?> LoginAsync(string email, string password)
    {
        // Example: Check if the email and password match a user in your data store
        // Replace this with your actual authentication logic (e.g., using a database)

        var user = await _dbContext.Customers
            .SingleOrDefaultAsync(u => u.CustomerEmail == email && u.LoginPassword == password);

        if (user != null)
        {
            // Return the user ID if authentication is successful
            return user.Id;
        }

        // Return null if authentication fails
        return null;
    }

    public async Task<bool> RecoverPasswordAsync(string mobile, string securityQuestionCode, string securityAnswer, string newPassword)
    {
        var user = await _dbContext.Customers.SingleOrDefaultAsync(c =>
            c.CustomerMobile == mobile &&
            c.SecurityQuestionsCode == securityQuestionCode &&
            c.SecurityAnswerCode == securityAnswer);

        if (user != null)
        {
            user.LoginPassword = newPassword;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
