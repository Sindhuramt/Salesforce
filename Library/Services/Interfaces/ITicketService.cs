using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ITicketService
    {
        Task<long> RaiseTicketAsync(TicketMaster ticket); 
        Task<List<TicketMaster>> GetTicketsByStatusAsync(string statusCode);

        Task<TicketMaster> GetTicketByIdAsync(long ticketId);
        Task<Dictionary<string, int>> GetTicketStatusCountsAsync();
    }
}
