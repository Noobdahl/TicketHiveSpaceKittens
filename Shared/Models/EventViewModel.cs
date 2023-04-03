using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal TicketPrice { get; set; }
        public DateTime EventDate { get; set; }
        public int TicketsRemaining { get; set; }
        public List<EventTypesModel> EventTypes { get; set; } = null!;
        public string? ImageUrl { get; set; }

    }
}
