using TicketHiveSpaceKittens.Server.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IUserRepo
    {
        /// <summary>
        /// Adds new user and saves to database
        /// </summary>
        /// <param name="username">Use the string username to match with username and set it to new</param>
        /// <param name="country">Use country to set the selected country to the user</param>
        void AddUser(string username, string country);

        /// <summary>
        /// Sing in user by the username and password with SingInManager
        /// </summary>
        /// <param name="password">If the password correct, log in the user</param>
        /// <param name="country">The country of the user</param>
        /// <returns>If sign in was successful or not</returns>
        Task<bool> SignInUser(string password, string country);

        /// <summary>
        /// Register user by using ApplicationUser
        /// </summary>
        /// <param name="newUser">Add the new user</param>
        /// <param name="password">Add the new password</param>
        /// <param name="country">Add an country to the user</param>
        /// <returns>If register was ssuccessful add a new user</returns>
        Task<bool> RegisterUser(ApplicationUser newUser, string password, string country);

        /// <summary>
        /// Change the country of the logged in user
        /// </summary>
        /// <param name="currentPassword">Current password of the user</param>
        /// <param name="newPassword">Adding the new password</param>
        /// <returns>If everything was successful, change the password</returns>
        Task<bool> ChangePassword(string currentPassword, string newPassword);

        /// <summary>
        /// Get's the country of the singed in user
        /// </summary>
        /// <param name="username">Get the country by the username</param>
        /// <returns>The users country</returns>
        Task<string> GetCountryAsync(string username);

        /// <summary>
        /// If the user is singed in, get the country of the user and set it to the new country
        /// </summary>
        /// <param name="newCountry">Set the selected country of user and update it</param>
        /// <returns>If new country was selected was successful change it and save it </returns>
        Task<bool> ChangeCountry(string newCountry);
    }
}
