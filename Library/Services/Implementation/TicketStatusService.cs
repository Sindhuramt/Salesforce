// TicketStatusService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Data;
using Library.Entity;
using Microsoft.EntityFrameworkCore;

public class TicketStatusService : ITicketStatusService
{
    private readonly LibraryDbContext _dbContext;

    public TicketStatusService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TicketStatus>> GetTicketStatusesAsync()
    {
        return await _dbContext.TicketStatuses.ToListAsync();
    }
}
