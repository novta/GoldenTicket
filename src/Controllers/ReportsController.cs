using GoldenTicket.Data;
using GoldenTicket.Models.ReportsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            var details = new ReportDetails
            {
                Reviews = new List<(Models.Client Client, Models.Review? ReviewOutcome)>(),
            };
            return View(details);
        }
    }
}