namespace Library.Entity
{
    public class Customer
    {
        public long Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerEmail { get; set; }

        public string LoginPassword { get; set; }

        public string CustomerAddress { get; set; }

        public bool IsBlocked { get; set; } = false;

        public bool IsActive { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public string SecurityQuestionsCode { get; set; }

        public string SecurityAnswerCode { get; set; }

        public string AccountNo { get; set; }
    }

}