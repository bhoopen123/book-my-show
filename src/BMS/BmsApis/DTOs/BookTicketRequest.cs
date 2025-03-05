namespace BmsApis.DTOs
{
    public class BookTicketRequest
    {
        public required IEnumerable<int> ShowSeatIds { get; set; }
    }
}
