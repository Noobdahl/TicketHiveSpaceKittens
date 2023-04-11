using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IBookingService
    {
        Task<bool> UpdateBookningAsync(EventModel bookedEvents);
    }
}
