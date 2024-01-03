// TicketController.cs
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Entity;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
public class TicketController : Controller
{
    private readonly ITicketService _ticketService;
    private readonly ITicketStatusService _ticketStatusService;

    public TicketController(ITicketService ticketService, ITicketStatusService ticketStatusService)
    {
        _ticketService = ticketService;
        _ticketStatusService = ticketStatusService;
    }
    [HttpGet]
    public async Task<IActionResult> RaiseTicket(long userId)
    {
        // Get available ticket statuses
        var statuses = await _ticketStatusService.GetTicketStatusesAsync();
        ViewBag.Statuses = statuses;

        // Set the user ID in the ViewBag
        ViewBag.UserId =  userId;

        return View("RaiseTicket");
    }


    [HttpPost]
    public async Task<IActionResult> RaiseTicket(TicketMaster model, long userId)
    {
        if (ModelState.IsValid)
        {
            // Set the user ID in the model
            model.UserId = userId;

            // Raise the ticket and get the ticket number
            var ticketNumber = await _ticketService.RaiseTicketAsync(model);

            // Redirect to the TicketConfirmation view with the ticket number
            return RedirectToAction("TicketConfirmation", new { ticketNumber });
        }

        var statuses = await _ticketStatusService.GetTicketStatusesAsync();
        ViewBag.Statuses = statuses;
        ViewBag.UserId = userId;
        // If the model is not valid, return to the view with validation errors
        return View(model);
    }



    [HttpGet]
    public IActionResult TicketConfirmation(string ticketNumber)
    {
        // You can pass the ticket number to the view
        ViewBag.TicketNumber = ticketNumber;
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> TicketHistory(string statusCode = "")
    {
        var statuses = await _ticketStatusService.GetTicketStatusesAsync();
        ViewBag.Statuses = statuses;

        // Get tickets based on the selected status code
        var tickets = await _ticketService.GetTicketsByStatusAsync(statusCode);

        return View(tickets);
    }
    [HttpGet]
    public async Task<IActionResult> ViewTicket(long ticketId)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(ticketId);

        if (ticket == null)
        {
            return NotFound(); // Ticket not found
        }

        return View(ticket);
    }

}
