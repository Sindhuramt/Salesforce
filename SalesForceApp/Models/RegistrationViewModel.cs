using Library.Entity;

namespace SalesForceApp.Models
{
    public class RegistrationViewModel
    {
        public Customer Customer { get; set; }

        public List<SecurityQuestion> SecurityQuestions { get; set; }
    }

}
