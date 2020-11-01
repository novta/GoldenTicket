using System;

namespace GoldenTicket.Models.TicketsViewModels
{
    /// <summary>
    /// Relates time and ticket information.
    /// </summary>
    public class ReviewViewModel
    {
        /// <summary>
        /// The id of the ticket.
        /// </summary>
        /// <returns></returns>
        public string TicketId { get; set; }

        /// <summary>
        /// The title of the ticket.
        /// </summary>
        public string TicketTitle { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public string Role { get; set; }

        /// <summary>
        /// The start time.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The end time.
        /// </summary>
        public Review ReviewOutcome  { get; set; }
    }
}