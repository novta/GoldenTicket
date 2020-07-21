namespace GoldenTicket.Models.TicketsViewModels
{
    /// <summary>
    /// Tech time model
    /// </summary>
    public class ModeratorReview
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
        public TicketReview TicketReviewOutcome { get; set; }
    }
}