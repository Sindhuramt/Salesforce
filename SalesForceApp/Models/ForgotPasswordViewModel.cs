
using Library.Entity;
using System.ComponentModel.DataAnnotations;

namespace SalesForceApp.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Please select a security question")]
        public string SecurityQuestionCode { get; set; }

        [Required(ErrorMessage = "Security answer is required")]
        public string SecurityAnswer { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

        public List<SecurityQuestion> SecurityQuestions { get; set; }
    }
}
