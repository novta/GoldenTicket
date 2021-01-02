using GoldenTicket.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is abroad.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is abroad; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool IsAbroad { get; set; }

        /// <summary>
        /// The destination country of this ticket
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = "Србија";

        /// <summary>
        /// The Destination of this ticket
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Destination { get; set; }

        /// <summary>
        /// The Institution of this ticket
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Institution { get; set; }

        /// <summary>
        /// The reason of this ticket
        /// </summary>
        [MaxLength(250)]
        public string Reason { get; set; }

        /// <summary>
        /// The kontact person in istitutuion
        /// </summary>
        [MaxLength(250)]
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
        [MaxLength(250)]
        public string Transportation { get; set; }

        /// <summary>
        /// The sources of funding of this ticket
        /// </summary>
        [MaxLength(250)]
        [DataType(DataType.MultilineText)]
        public string SourcesOfFunding { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is urgent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is urgent; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool IsUrgent { get; set; }

        /// <summary>
        /// Notes for this ticket
        /// </summary>
        [MaxLength(250)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        /// <summary>
        /// The date added
        /// </summary>
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        /// <summary>
        /// The date closed
        /// </summary>
        public DateTime DateClosed { get; set; }

        /// <summary>
        /// True if the ticket is open
        /// </summary>
        [Required]
        public bool Open { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Required]
        public TicketState State { get; set; }
    }
}