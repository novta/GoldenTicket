namespace GoldenTicket.Models.TicketsViewModels
{
    /// <summary>
    /// Tech time model
    /// </summary>
    public class ModeratorReviewViewModel
    {
        /// <summary>
        /// Get's technician
        /// </summary>
        /// <returns>technician</returns>
        public Client Moderator { get; set; }

        /// <summary>
        /// get's time
        /// </summary>
        /// <returns>technician's ticket time</returns>
        public ReviewViewModel TicketReviewOutcome { get; set; }
    }
}