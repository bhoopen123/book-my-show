using BmsApis.DTOs;
using BmsApis.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(TicketService ticketService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BookTicketResponse>> Post([FromBody] BookTicketRequest bookTicketRequest, CancellationToken cancellationToken)
        {
            BookTicketResponse bookTicketResponse = new BookTicketResponse();

            try
            {
                int ticketId = ticketService.BookTicket(bookTicketRequest.UserId, bookTicketRequest.ShowSeatIds);
                bookTicketResponse.Status = ResponseStatus.Success;
                bookTicketResponse.TicketId = ticketId;
                bookTicketResponse.Message = "Ticket generated successfully";
            }
            catch (Exception ex)
            {
                // log error : ex
                bookTicketResponse.Status = ResponseStatus.Failure;
                bookTicketResponse.Message = "Try again..";
            }

            return Created(uri: new Uri(HttpContext.Request.Path), bookTicketResponse);
        }
    }
}
