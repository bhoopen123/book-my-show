namespace BmsApis.DTOs
{
    public class BookTicketRequest
    {
        public int UserId { get; set; }
        public required IEnumerable<int> ShowSeatIds { get; set; }
    }
}
