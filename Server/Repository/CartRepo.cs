using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public class CartRepo
    {
        private readonly CartRepo cRepo;

        public CartRepo(CartRepo cRepo)
        {
            this.cRepo = cRepo;
        }
    }
}
