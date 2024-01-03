using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class TicketMaster
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Problem { get; set; }

        public string Description { get; set; }

        public string StatusCode { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public long UserId { get; set; } = 0;

        public DateTime? ResolvedOn { get; set; }

        public string Resolution { get; set; }
    }
}
