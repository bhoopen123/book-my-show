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
        public async Task<IActionResult> Post([FromBody] BookTicketRequest bookTicketRequest, CancellationToken cancellationToken)
        {
            BookTicketResponse bookTicketResponse = new BookTicketResponse();

            try
            {
                int ticketId = ticketService.BookTicket(bookTicketRequest.ShowSeatIds);
                bookTicketResponse.Status = ResponseStatus.Success;
                //bookTicketResponse.TicketId = ticketId;
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
