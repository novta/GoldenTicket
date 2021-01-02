using System.Collections.Generic;
using GoldenTicket.Models;

namespace GoldenTicket.ViewModels.Reports
{
    /// <summary>
    /// Information for a report
    /// </summary>
    public class ReportDetails
    {
        /// <summary>
        /// Hours each technician was idle
        /// </summary>
        public List<(Client Client, Review? ReviewOutcome)> Reviews { get; set; }
    }
}