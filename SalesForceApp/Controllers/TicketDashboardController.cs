using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SalesForceApp.Controllers
{
    public class TicketDashboardController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketDashboardController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketStatusCounts = await _ticketService.GetTicketStatusCountsAsync();
            return View(ticketStatusCounts);
        }
    }
}
