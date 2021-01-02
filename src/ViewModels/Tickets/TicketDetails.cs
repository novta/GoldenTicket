using System.Collections.Generic;
using GoldenTicket.Models;

namespace GoldenTicket.ViewModels.Tickets
{
    /// <summary>
    /// ticket details model
    /// </summary>
    public class TicketDetails
    {
        /// <summary>
        /// get's ticket
        /// </summary>
        /// <returns>the ticket</returns>
        public Ticket Ticket { get; set; }

        /// <summary>
        /// get's Client
        /// </summary>
        /// <returns>the client</returns>
        public Client Client { get; set; }

        /// <summary>
        /// List of tech time associated with ticket
        /// </summary>
        /// <returns>list of tech times</returns>
        public List<ModeratorReviewViewModel> Reviewes { get; set; }
    }
}