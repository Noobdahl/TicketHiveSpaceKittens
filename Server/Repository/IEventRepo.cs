using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IEventRepo
    {
        /// <summary>
        /// Get's all the events from the database
        /// </summary>
        /// <returns>List of EventModel with all the events</returns>
        Task<List<EventModel>> GetEvents();

        /// <summary>
        /// Get one Event from the database, based on the id
        /// </summary>
        /// <param name="id">The id of the returned event</param>
        /// <returns>EventModel containing the details of the event if it was found</returns>
        Task<EventModel?> GetEvent(int id);

        /// <summary>
        /// Create new event with details
        /// </summary>
        /// <param name="newEvent">EventModel containing the new event details</param>
        /// <returns>Using Bool to see if the event was successful or not</returns> 
        Task<bool> CreateEvent(EventModel newEvent);

        /// <summary>
        /// Find the correct event and delete it from the database
        /// </summary>
        /// <param name="id">The id of the selected event to delete</param>
        /// <returns>If event was found in EventModel it will delete it</returns>
        Task<EventModel?> DeleteEvent(int id);

        /// <summary>
        /// Find the correct event and update it with the new details
        /// </summary>
        /// <param name="id">The id of the event to update</param>
        /// <param name="updatedEvent">EventModel with the new object that will contain the new updated event</param>
        /// <returns>Find the correct event in EventModel and updates the information if the event is not null</returns>
        Task<EventModel?> UpdateEvent(int id, EventModel updatedEvent);

        /// <summary>
        /// Book a List of events to a user
        /// </summary>
        /// <param name="bookedEvent">List of EventModel to book to the user</param>
        /// <param name="username">Find the correct user and add the event to that user</param>
        /// <returns>If the booking was successful or not to the user.</returns>
        bool BookEventsToUser(List<EventModel> bookedEvent, string username);

        /// <summary>
        /// List of EventModel to get all the users event
        /// </summary>
        /// <param name="username">Find the right user with username</param>
        /// <returns>Users event if find or otherwise return nothing</returns>
        Task<List<EventModel>> GetEventsByUsernameAsync(string username);
        
        /// <summary>
        /// If tickets are available, delete the quantity by checking the amount of tickets left
        /// </summary>
        /// <param name="e">CartModel have event and number of tickets to remove</param>
        /// <returns>The right amount tickets</returns>
        Task RemoveTicket(CartEventModel e);

        /// <summary>
        /// Check if tag exist in the database otherwise create new tag
        /// </summary>
        /// <param name="Tagname">Compare the new tag with tag in database</param>
        /// <returns>A new tag and add it to the database if it not exist already</returns>
        Task<TagModel> TagChecker(string Tagname);
    }
}
