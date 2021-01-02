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
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ticket identifier.
        /// </summary>
        /// <value>
        /// The ticket identifier.
        /// </value>
        [Required]
        [MaxLength(50)]
        public string TicketId { get; set; }

        /// <summary>
        /// Gets or sets the reviewer identifier.
        /// </summary>
        /// <value>
        /// The reviewer identifier.
        /// </value>
        [Required]
        [MaxLength(50)]
        public string ReviewerId { get; set; }

        /// <summary>
        /// Gets or sets the reviewer role.
        /// </summary>
        /// <value>
        /// The reviewer role.
        /// </value>
        [Required]
        [MaxLength(50)]
        public string ReviewerRole { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [Required]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the review outcome.
        /// </summary>
        /// <value>
        /// The review outcome.
        /// </value>
        [Required]
        public Review ReviewOutcome { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketReview"/> class.
        /// </summary>
        public TicketReview() => Id = Guid.NewGuid().ToString();
    }
}