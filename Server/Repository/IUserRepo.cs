﻿using TicketHiveSpaceKittens.Server.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IUserRepo
    {
        void AddUser(string username, string country);
        Task<bool> SignInUser(string password, string country);
        Task<bool> RegisterUser(ApplicationUser newUser, string password, string country);
        Task<bool> ChangePassword(string currentPassword, string newPassword);
        Task<string> GetCountryAsync(string username);
        Task<bool> ChangeCountry(string newCountry);
        //Task<string> GetUserIdentityName();
    }
}
