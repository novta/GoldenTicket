using System.Collections.Generic;
using GoldenTicket.Models;
using System.Linq;

namespace GoldenTicket.ViewModels.Clients
{
    /// <summary>
    /// Client details request model
    /// </summary>
    public class ClientDetails
    {
        /// <summary>
        /// Get's client
        /// </summary>
        /// <returns>the client</returns>
        public Client Client { get; set; }

        /// <summary>
        /// List of tickets associated with client
        /// </summary>
        /// <returns>client's ticket list</returns>
        public IEnumerable<Ticket> Tickets { get; set; }

        /// <summary>
        /// Count of open tickets.
        /// </summary>
        public int OpenTicketCount 
        { 
            get 
            {
                return Tickets.Where(x => x.Open).Count();
            } 
        }
    }
}