using TicketHiveSpaceKittens.Client.Pages;
using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Server.Migrations;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public class BookingRepo : IBookingRepo
    {
        
        private readonly EventDbContext context;
        public BookingRepo(EventDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddBookning(EventModel bookedEvent, UserModel user)
        {
            //var eventId = bookedEvent.Event.EventId;
            try
            {
                //select in baza de date
                //adaug evenimnt in lista de la useri

                user.Bookings.Add(bookedEvent);
          
                //context.Bookings.Add(bookning);

                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

        /*
public async Task<bool> CreateBookning(CartEventModel bookedEvent, UserModel userId)
{
   var eventId = bookedEvent.Event.EventId;
   try
   {
       context.Bookings.Add(new Booking
       {
           eventsInCart = eventId,
           UserId = userId.UserId
       });

       await context.SaveChangesAsync();

       return true;
   }
   catch
   {
       return false;
   }
}
*/
        /*
        public void AddBookning(CartEventModel bookedEvent, UserModel userId)
        {
            var eventId = bookedEvent.Event.EventId;
            // Create a new CartEvent object with the eventId

            var booking = new EventModelUserModel()
            {
                eventsInCart = eventId,
                UserId = userId.UserId
            };
            
            context.EventModelUserModel.Add(booking);
            context.SaveChanges();
        }
        */
    }