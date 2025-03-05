
namespace BmsApis.Services
{
    public class TicketService
    {
        public int BookTicket(IEnumerable<int> bookSeatIds)
        {
            // 1. Get showSeats for selected Ids
            // 2. Check if they are available
            // 3. If not available, send back with an exception
            // 4. Lock them
            // 5. Prepare a dummy ticket
            // 6. Return ticketId
            return 0;
        }
    }
}
