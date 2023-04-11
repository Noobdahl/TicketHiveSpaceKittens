using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class BookingModel
    {
        /*
        public BookingModel()
        {
        }
        public int eventsInCart { get; set; }
        public int UserId { get; set; }
        */

        public int EventId { get; set; }
        public EventModel Event { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
