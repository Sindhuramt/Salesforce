using Library.Entity;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SalesForceApp.Models;

namespace SalesForceApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISecurityQuestionService _securityQuestionService;

        public AuthController(IUserService userService, ISecurityQuestionService securityQuestionService)
        {
            _userService = userService;
            _securityQuestionService = securityQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var securityQuestions = await _securityQuestionService.GetAllSecurityQuestionsAsync();
            var registrationViewModel = new RegistrationViewModel
            {
                SecurityQuestions = securityQuestions
            };

            return View(registrationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            
                await _userService.RegisterUserAsync(model.Customer);
                // Redirect to login page or dashboard after successful registration
                return RedirectToAction("Login");

            // If registration fails, return the registration view with validation errors
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _userService.LoginAsync(model.Email, model.Password);

                if (loginResult != null)
                {
                    // Successful login, get the user ID
                    var userId = loginResult.Value;

                    // Redirect to the ticket dashboard with user ID
                    return RedirectToAction("RaiseTicket", "Ticket", new { userId });
                }

                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }

            // If login fails, return the login view with validation errors
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            var securityQuestions = await _securityQuestionService.GetAllSecurityQuestionsAsync();
            var forgotPasswordViewModel = new ForgotPasswordViewModel
            {
                SecurityQuestions = securityQuestions
            };

            return View(forgotPasswordViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resetPasswordResult = await _userService.RecoverPasswordAsync(model.Mobile, model.SecurityQuestionCode, model.SecurityAnswer, model.NewPassword);

                if (resetPasswordResult)
                {
                    // Password reset successful, redirect to login page or another page
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError(string.Empty, "Invalid mobile number, security question, or security answer");
            }

            // If password reset fails, return the forgot password view with validation errors
            return View(model);
        }

        [HttpGet]
        public IActionResult Welcome(string userName)
        {
            ViewBag.UserName = userName;
            return View();
        }
    }
}
