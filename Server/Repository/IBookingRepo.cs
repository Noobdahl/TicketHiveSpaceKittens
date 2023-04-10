using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IBookingRepo
    {
        Task<bool> AddBookning(EventModel bookedEvent, UserModel userId);

    }
}
