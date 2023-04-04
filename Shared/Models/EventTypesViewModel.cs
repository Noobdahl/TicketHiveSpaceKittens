using System.ComponentModel.DataAnnotations;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class EventTypesViewModel
    {
        [Key]
        public string TypeName { get; set; } = null!;
    }
}
