using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldenTicket.Data;
using GoldenTicket.Models;
using GoldenTicket.Models.TicketsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// Controller for managing tickets
    /// </summary>
    [Authorize]
    public class TicketsController : Controller
    {
        private GoldenTicketContext _context;

        private UserManager<Client> _userManager;

        private ILogger _logger;

        /// <summary>
        /// Initializes private variable _context
        /// </summary>
        /// <param name="context">context of current ticket</param>
        /// <param name="userManager">The user manager</param>
        public TicketsController(GoldenTicketContext context, UserManager<Client> userManager, ILogger<TicketsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Used to view all tickets in queue
        /// </summary>
        /// <param name="includeClosed">boolean for including closed tickets</param>
        /// <returns>view list of ordered tickets</returns>
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] bool includeClosed = false)
        {
            try
            {
                IQueryable<Ticket> visibleTickets;
                var client = await _userManager.GetUserAsync(User);
                if (client.Role == Role.Employee)
                {
                    // can see only own tickets
                    visibleTickets = _context.Tickets.Where(x => x.ClientId == client.Id);
                }
                else
                {
                    // can see all tickets
                    visibleTickets = _context.Tickets;
                }
                List<Ticket> orderedTickets = new List<Ticket>();
                if (visibleTickets.Any())
                {
                    orderedTickets = await visibleTickets
                        .Where(ticket => ticket.Open || ticket.Open != includeClosed)
                        .OrderByDescending(ticket => ticket.DateAdded)
                        //.GroupBy(ticket => ticket.ClientId)
                        //.OrderBy(ticketClientGroup => ticketClientGroup.Count())
                        //.SelectMany(ticketClientGroup => ticketClientGroup)
                        //.Where(ticket => ticket.Open || ticket.Open != includeClosed)
                        //.OrderByDescending(ticket => ticket.IsUrgent)
                        //.OrderByDescending(ticket => ticket.Open)
                        .ToListAsync();
                }
                ViewData["includeClosed"] = includeClosed;
                return View(orderedTickets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"All has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }

        /// <summary>
        /// Opens a ticket
        /// </summary>
        /// <param name="id">unique id of ticket</param>
        /// <returns>view of the ticket</returns>
        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] string id)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(id);
                var client = await _context.Clients.FindAsync(ticket.ClientId);
                var reviewes = await _context.TicketReviews.Where(time => time.TicketId == ticket.Id)
                    .Join(_context.Users, time => time.ReviewerId, tech => tech.UserName, (time, tech) => new ModeratorReviewViewModel 
                    { 
                        Moderator = tech, 
                        TicketReviewOutcome = new TicketReviewViewModel
                        {
                            TicketId = ticket.Id,
                            TicketTitle = ticket.Destination,
                            ReviewerRole = time.ReviewerRole,
                            Timestamp = time.Timestamp,
                            ReviewOutcome = time.ReviewOutcome
                        }
                    })?.ToListAsync();

                return View(new TicketDetails { Ticket = ticket, Client = client, Reviewes = reviewes });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Open has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }

        /// <summary>
        /// Open a ticket for editiing
        /// </summary>
        /// <param name="id">unique id of ticket</param>
        /// <returns>view of the ticket to edit</returns>
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] string id)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(id);
                return View(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Edit has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }

        /// <summary>
        /// Updates a ticket.
        /// </summary>
        /// <param name="ticketUpdate">The ticket update.</param>
        /// <returns>The ticket view</returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Ticket ticketUpdate)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(ticketUpdate.Id);
                ticket.Destination = ticketUpdate.Destination;
                ticket.Institution = ticketUpdate.Institution;
                ticket.ContactPersonOnSite = ticketUpdate.ContactPersonOnSite;
                ticket.Notes = ticketUpdate.Notes;
                ticket.Open = ticketUpdate.Open;
                // Ticket is closing
                if (!ticket.Open && ticket.DateClosed == DateTime.MinValue)
                {
                    ticket.DateClosed = DateTime.Now;
                }
                // Ticket is re-opening
                if (ticket.Open && ticket.DateClosed != DateTime.MinValue)
                {
                    ticket.DateClosed = DateTime.MinValue;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Edit has failed with error '{ex.Message}'");
            }
            return RedirectToAction(nameof(Open), new { id = ticketUpdate.Id });
        }

        /// <summary>
        /// Open the page for adding time to a ticket.
        /// </summary>
        /// <param name="id">The id of the ticket.</param>
        /// <param name="role">The role of reviewer.</param>
        /// <returns>The add time view</returns>
        [HttpGet]
        public async Task<IActionResult> Review([FromRoute] string id, string role)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            return base.View(new TicketReviewViewModel { TicketTitle = ticket.Destination, TicketId = ticket.Id, ReviewerRole = role });
        }

        /// <summary>
        /// Add time to a ticket
        /// </summary>
        /// <param name="time">The time to add</param>
        /// <returns>Redirect to ticket view</returns>
        [HttpPost]
        public async Task<IActionResult> Review([FromForm] TicketReviewViewModel time)
        {
            try
            {
                var newTicket = new TicketReview
                {
                    ReviewOutcome = time.ReviewOutcome,
                    Timestamp = DateTime.Now,
                    TicketId = time.TicketId,
                    ReviewerId = _userManager.GetUserName(User),
                    ReviewerRole = time.ReviewerRole
                };
                _context.TicketReviews.Add(newTicket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Review ticket has failed with error '{ex.Message}'");
            }
            return RedirectToAction(nameof(Open), new { id = time.TicketId });
        }
        /// <summary>
        /// Deletes a time
        /// </summary>
        /// <param name="id">The id of the time</param>
        /// <returns>The ticket view</returns>
        [HttpPost]
        public async Task<IActionResult> DeleteTime([FromRoute] string id)
        {
            var time = await _context.TicketReviews.FindAsync(id);
            try
            {
                _context.TicketReviews.Remove(time);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DeleteTime has failed with error '{ex.Message}'");
            }
            return RedirectToAction(nameof(Open), new { id = time.TicketId });
        }

        ///// <summary>
        ///// Gets bill.
        ///// </summary>
        ///// <param name="id">The id for the ticket</param>
        ///// <returns>The bill</returns>
        //[HttpGet]
        //public async Task<IActionResult> Bill([FromRoute] string id)
        //{
        //    var ticket = await _context.Tickets.FindAsync(id);
        //    var client = await _context.Clients.FindAsync(ticket.ClientId);
        //    var times = await _context.TicketReviews.Where(time => time.TicketId == ticket.Id).Join(_context.Users, time => time.ModeratorId, tech => tech.UserName, (time, tech) => new ModeratorReview { Moderator = tech, ReviewOutcome = time }).ToListAsync();
        //    return View(new TicketDetails { Ticket = ticket, Client = client, Times = times });
        //}

        /// <summary>
        /// Toggles urgency of a ticket
        /// </summary>
        /// <param name="id">The id of the ticket</param>
        /// <returns>The ticket</returns>
        [HttpPost]
        public async Task<IActionResult> ToggleUrgent([FromRoute] string id)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(id);
                ticket.IsUrgent = !ticket.IsUrgent;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ToggleUrgent has failed with error '{ex.Message}'");
            }
            return RedirectToAction(nameof(Open), new { id = id });
        }
    }
}