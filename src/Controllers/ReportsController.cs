using GoldenTicket.Data;
using GoldenTicket.Models.ReportsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// For handling reports
    /// </summary>
    [Authorize(Roles = Role.Administrator)]
    public class ReportsController : Controller
    {
        private GoldenTicketContext _context;

        /// <summary>
        /// Initializes this controller
        /// </summary>
        /// <param name="context">context of the technician</param>
        public ReportsController(GoldenTicketContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the report view
        /// </summary>
        /// <returns>The report view</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            // var timeSpan = new TimeSpan(hours: 24, minutes: 0, seconds: 0);
            // var end = DateTime.Now;
            // var start = end - timeSpan;

            // var openEvents = (await _context.Tickets.Where(ticket => ticket.DateAdded > start || (ticket.DateAdded <= start && (ticket.DateClosed > start || ticket.Open))).Select(ticket => ticket.DateAdded < start ? start : ticket.DateAdded).ToListAsync()).Select(time => (time, true));
            // var closeEvents = (await _context.Tickets.Where(ticket => ticket.DateClosed > start).Select(ticket => ticket.DateClosed).ToListAsync()).Select(time => (time, false));

            // var events = new List<IEnumerable<(DateTime, bool)>> { openEvents, closeEvents }.SelectMany(ticket => ticket); OrderBy<IQueryable<(DateTime, bool)>, bool>((time, open) => true);

            var details = new ReportDetails
            {
                //AverageQueueLength = await _context.Tickets.Where(ticket => ticket.Open).CountAsync(),
                //AverageWait = new TimeSpan(0, 0, 0),
                //EmptyQueuePercentage = 0,
                //TicketsNotAddressedSameDay = 15,
                //ModeratorReviews = await _context.Users.GroupJoin(_context.TicketReviews,
                //                                                clinet => clinet.Id,
                //                                                review => review.ModeratorId,
                //                                                (clinet, review) => new { Moderator = clinet, Outcome = review})
                //                                        .ToAsyncEnumerable().Select(x => (x.Moderator, x.Outcome)).ToList()
            };
            return View(details);
        }
    }
}