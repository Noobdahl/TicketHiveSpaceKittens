using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IBookingRepo
    {
        Task<bool> UpdateEventToUser(int eventId, int userId);
        //Task<bool> AddBookning(EventModel bookedEvent, UserModel userId);
        //Task AddBookingAsync(BookingModel booking);
        //Task UpdateBookingAsync(BookingModel booking);
    }
}
