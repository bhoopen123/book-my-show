namespace BmsApis.DTOs
{
    public class BookTicketResponse
    {
        public int TicketId { get; set; }
        public ResponseStatus Status { get; set; }
        public string? Message { get; set; }
    }
}
