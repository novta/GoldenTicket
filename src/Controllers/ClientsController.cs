using System;
using System.Linq;
using System.Threading.Tasks;
using GoldenTicket.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenTicket.ViewModels.Clients;
using GoldenTicket.Models;
using Microsoft.Extensions.Logging;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// Controller for Clients
    /// </summary>
    [Authorize]
    public partial class ClientsController : Controller
    {
        private readonly GoldenTicketContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes _context
        /// </summary>
        /// <param name="context">context of client</param>
        /// <param name="logger">Logger reference</param>
        public ClientsController(GoldenTicketContext context, ILogger<ClientsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Shows all clients
        /// </summary>
        /// <returns>clients page</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var allClients = await _context.Clients.ToListAsync();
                var allTickets = await _context.Tickets.ToListAsync();
                var clients = allClients
                    .GroupJoin(
                        allTickets,
                        client => client.Id,
                        ticket => ticket.ClientId,
                        (client, tickets) => new ClientDetails { Client = client, Tickets = tickets })
                    .OrderBy(client => client.Client.FirstName)
                    .ThenBy(client => client.Client.LastName);
                return View(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "All has failed with error '{ExceptionMessage}'", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Opens a client's details
        /// </summary>
        /// <param name="id">The id of the client</param>
        /// <returns>The client</returns>
        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] string id)
        {
            try
            {
                var client = await _context.Clients.FindAsync(id);
                var tickets = await _context.Tickets.Where(ticket => ticket.ClientId == id).ToListAsync();

                var details = new ClientDetails {
                    Client = client,
                    Tickets = tickets
                };
                return View(details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Open has failed with error '{ExceptionMessage}'", ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Gets view for adding a ticket.
        /// </summary>
        /// <returns>The view.</returns>
        [HttpGet]
        public IActionResult AddTicket([FromRoute] string id)
        {
            return View(new Ticket { ClientId = id });
        }

        /// <summary>
        /// Adds a ticket
        /// </summary>
        /// <param name="ticket">The ticket to be added</param>
        /// <returns>The added ticket</returns>
        [HttpPost]
        public async Task<IActionResult> AddTicket([FromForm] Ticket ticket)
        {
            try
            {
                ticket.DateAdded = DateTime.Now;
                ticket.Open = true;

                _context.Tickets.Add(ticket);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Open has failed with error '{ExceptionMessage}'", ex.Message);
            }
            return RedirectToAction(nameof(TicketsController.Open), "Tickets", new { id = ticket.Id });
        }
    }
}