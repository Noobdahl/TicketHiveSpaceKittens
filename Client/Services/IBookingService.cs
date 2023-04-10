using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IBookingService
    {
        Task<bool> AddBookningAsync(EventModel bookedEvent, UserModel userId);
    }
}
