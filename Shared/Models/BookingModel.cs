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
        public BookingModel()
        {
        }
        public int eventsInCart { get; set; }
        public int UserId { get; set; }
    }
}
