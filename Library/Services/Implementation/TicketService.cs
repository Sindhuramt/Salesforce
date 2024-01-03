// TicketService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Entity;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class TicketService : ITicketService
{
    private readonly LibraryDbContext _dbContext;

    public TicketService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> RaiseTicketAsync(TicketMaster ticket)
    {
        _dbContext.TicketMasters.Add(ticket);
        await _dbContext.SaveChangesAsync();
        return ticket.Id;
    }

    public async Task<List<TicketMaster>> GetTicketsByStatusAsync(string statusCode)
    {
        if (statusCode != "")
        {

            var tickets = await _dbContext.TicketMasters
                .Where(t => t.StatusCode == statusCode)
                .ToListAsync();


            return tickets;
        }
        else
        {
            var tickets = await _dbContext.TicketMasters.ToListAsync();


            return tickets;
        }
    }

    public async Task<TicketMaster> GetTicketByIdAsync(long ticketId)
    {
        return await _dbContext.TicketMasters.FindAsync(ticketId);
    }

    public async Task<Dictionary<string, int>> GetTicketStatusCountsAsync()
    {
        var ticketStatuses = await _dbContext.TicketStatuses.ToListAsync();

        return ticketStatuses
            .ToDictionary(
                status => status.Name,
                status => _dbContext.TicketMasters.Count(ticket => ticket.StatusCode == status.Code)
            );
    }


}
