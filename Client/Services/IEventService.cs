using Microsoft.AspNetCore.Components.Forms;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IEventService
    {
        /// <summary>
        /// Gets all events from api.
        /// </summary>
        /// <returns>List of EventModel</returns>
        Task<List<EventModel>?> GetEventsAsync();

        /// <summary>
        /// Gets one event from api based on id.
        /// </summary>
        /// <returns>EventModel</returns>
        Task<EventModel?> GetOneEventAsync(int id);

        /// <summary>
        /// Creates a new event using the provided eventModel in the api.
        /// </summary>
        /// <returns>
        /// A bool based on the result of creating a new event.
        /// </returns>
        Task<bool> CreateEventAsync(EventModel eventModel);

        /// <summary>
        /// Deletes the event with the specified id in the api.
        /// </summary>
        /// <returns>
        /// A bool based on the result of deleting an event.
        /// </returns>
        Task<bool> DeleteEventByIdAsync(int id);

        /// <summary>
        /// Updates the specified eventModel in the API.
        /// </summary>
        /// <returns>
        /// A bool based on the result on updating the event.
        /// </returns>
        Task<bool> UpdateEventAsync(EventModel eventModel);

        /// <summary>
        /// Books the events selected by the specified tempUsers list of events to the user in the API.
        /// </summary>
        /// <returns>
        /// A bool based on the result of booking event(s) to a user.
        /// </returns>
        Task<bool> BookEventsToUserAsync(UserModel tempUser);

        /// <summary>
        /// Retrieves the events associated with the specified username from the API.
        /// </summary>
        /// <returns>
        /// Returns a List of Eventmodel.
        /// </returns>
        Task<List<EventModel>?> GetEventsByUsernameAsync(string username);

        /// <summary>
        /// Retrieves 5 random events from the API.
        /// </summary>
        /// <returns>
        /// Returns a List of Eventmodel.
        /// </returns>
        Task<List<EventModel>?> GetEventsRandomAsync();

        /// <summary>
        /// Removes an amount of tickets from an event on the api based off CartEventModels properties: EventModel and Quantity.
        /// </summary>
        /// <returns>
        /// A bool based on the result of removing tickets from event.
        /// </returns>
        Task<bool> RemoveTicket(CartEventModel e);

       Task<string> ConvertFileToBase64Async(IBrowserFile file);
        Task<string> UploadImageAsync(IBrowserFile file);
    }
}