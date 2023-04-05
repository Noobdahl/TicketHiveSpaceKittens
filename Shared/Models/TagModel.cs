using System.ComponentModel.DataAnnotations;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class TagModel
    {
        [Key]
        public string TypeName { get; set; } = null!;
        public List<EventModel> Events { get; set; } = new();
    }
}
