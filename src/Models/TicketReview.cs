using System;
using System.ComponentModel.DataAnnotations;

namespace GoldenTicket.Models
{
    /// <summary>
    /// The pivot table model for many tickets to many technicians and for holding time worked data
    /// </summary>
    public class TicketReview
    {
        /// <summary>
        /// The id.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The ticket id
        /// </summary>
        public string TicketId { get; set; }

        /// <summary>
        /// The reviewer id
        /// </summary>
        public string ReviewerId { get; set; }

        /// <summary>
        /// The start time
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The outcome
        /// </summary>
        public Review ReviewOutcome { get; set; }
    }
}