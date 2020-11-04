using GoldenTicket.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class CountriesController : Controller
    {
        private GoldenTicketContext _context;

        /// <summary>
        /// Initializes _context
        /// </summary>
        /// <param name="context">context of client</param>
        public CountriesController(GoldenTicketContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Getcountrieses the specified term.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string term = null)
        {
            if (term == null)
            {
                return Json(_context.Countries.Select(a => new { a.Id, a.Name }));
            }
            return Json(_context.Countries.Where(c => c.Name.StartsWith(term)).Select(a => new { a.Id, a.Name }));
        }
    }
}
