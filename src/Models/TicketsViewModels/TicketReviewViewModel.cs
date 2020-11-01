using System;

namespace GoldenTicket.Models.TicketsViewModels
{
    /// <summary>
    /// TicketState represent last change in ticket state
    /// </summary>
    public class TicketReviewViewModel
    {
        /// <summary>
        /// Gets or sets the ticket identifier.
        /// </summary>
        /// <value>
        /// The ticket identifier.
        /// </value>
        public string TicketId { get; set; }

        /// <summary>
        /// Gets or sets the ticket title.
        /// </summary>
        /// <value>
        /// The ticket title.
        /// </value>
        public string TicketTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TicketReviewViewModel"/> is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if open; otherwise, <c>false</c>.
        /// </value>
        public bool Open { get; set; }

        /// <summary>
        /// Gets or sets the review outcome.
        /// </summary>
        /// <value>
        /// The review outcome.
        /// </value>
        public Review ReviewOutcome { get; set; }

        /// <summary>
        /// Gets or sets the reviewer role.
        /// </summary>
        /// <value>
        /// The reviewer role.
        /// </value>
        public string ReviewerRole { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }
    }
}
