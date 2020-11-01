using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenTicket.Models
{
    /// <summary>
    /// A ticket for a client
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The Id for this ticket
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        /// <summary>
        /// The Id for the client who owns this ticket
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The destination country of this ticket
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        /// The Destination of this ticket
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// The Institution of this ticket
        /// </summary>
        public string Institution { get; set; }

        /// <summary>
        /// The reason of this ticket
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// The kontact person in istitutuion
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string ContactPersonOnSite { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The end date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The Transportation of this ticket
        /// </summary>
        public string Transportation { get; set; }

        /// <summary>
        /// The sources of funding of this ticket
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string SourcesOfFunding { get; set; }

        /// <summary>
        /// Defines if this ticket is urgent
        /// </summary>
        public bool IsUrgent { get; set; }

        /// <summary>
        /// Notes for this ticket
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        /// <summary>
        /// The date added
        /// </summary>
        public DateTime DateAdded { get; set; } = DateTime.Now;

        /// <summary>
        /// The date closed
        /// </summary>
        public DateTime DateClosed { get; set; }

        /// <summary>
        /// True if the ticket is open
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public TicketState State { get; set; }
    }
}