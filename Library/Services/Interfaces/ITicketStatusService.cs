// ITicketStatusService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Entity;

public interface ITicketStatusService
{
    Task<List<TicketStatus>> GetTicketStatusesAsync();
}
