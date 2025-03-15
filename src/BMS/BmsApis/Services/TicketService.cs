
using BmsApis.DbEntities;
using BmsApis.Exceptions;
using BmsApis.Repositories;
using System.Data;

namespace BmsApis.Services
{
    public class TicketService(IUserRepository userRepository,
                                ISeatInShowRepository seatInShowRepository,
                                ITicketRepository ticketRepository)
    {

        private DateTime systemDateTime = DateTime.UtcNow;

        /// <summary>
        /// Workflow from Available to Locked
        /// </summary>
        /// <param name="bookSeatIds"></param>
        /// <returns></returns>
        public int BookTicket(int userId, IEnumerable<int> bookSeatIds)
        {
            // 1. Get showSeats for selected Ids
            // 2. Check if all of the showSeats are available => available or locked 10 minutes ago
            // 3. If not available, send back with an exception
            // 4. Else, Lock the given showSeats for this user
            // 5. Prepare a dummy ticket
            // 6. Return ticketId

            var selectedSeatsInShow = seatInShowRepository.GetSeatsInShow(bookSeatIds);
            foreach (var selectedSeatInShow in selectedSeatsInShow)
            {
                if (!IsSeatInShowAvailable(selectedSeatInShow))
                {
                    throw new SeatInShowNotAvailableException("Seat(s) not available.");
                }
            }

            var bookedBy = userRepository.GetUser(userId);
            if (bookedBy is null)
            {
                throw new UserNotFoundException("User not found");
            }

            //
            foreach (var selectedSeatInShow in selectedSeatsInShow)
            {
                selectedSeatInShow.SeatStatus = new SeatStatus() { Id = 3, Name = "Locked" };
                selectedSeatInShow.StatusUpdatedAt = systemDateTime;

            }
            // save the record
            selectedSeatsInShow = seatInShowRepository.SaveRange(selectedSeatsInShow);

            // generate a ticket
            var ticket = new Ticket()
            {
                IsActive = true,
                BookedSeats = selectedSeatsInShow.ToList(),
                BookedBy = bookedBy!
            };

            // Save ticket
            ticket = ticketRepository.Save(ticket);
            return ticket.Id;
        }

        private bool IsSeatInShowAvailable(SeatInShow seatInShow)
        {
            if (seatInShow.SeatStatus.Id == 1) // means available
            {
                return true;
            }
            else if (seatInShow.SeatStatus.Id == 2) // means booked
            {
                return false;
            }
            else if (seatInShow.SeatStatus.Id == 3) // means locked
            {
                var durationInMinutes = systemDateTime.Subtract(seatInShow.StatusUpdatedAt).TotalMinutes;
                if (durationInMinutes >= 600d)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
