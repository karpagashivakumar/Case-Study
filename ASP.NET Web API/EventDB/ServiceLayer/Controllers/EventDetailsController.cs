using Microsoft.AspNetCore.Mvc;
using DAL.DataAccess;
using DAL.Models;

namespace ServiceLayer.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EventDetailsController : ControllerBase
    {
        private readonly IEventDetailsRepo<EventDetails> _eventRepo;
        private readonly IConfiguration _config;

        public EventDetailsController(IEventDetailsRepo<EventDetails> eventRepo, IConfiguration config)
        {
            _eventRepo = eventRepo;
            _config = config;
        }

        // Retrieves all event records
        [HttpGet("GetAllEvents")]
        public IActionResult FetchAllEvents()
        {
            var allEvents = _eventRepo.GetAllEvents();
            return allEvents != null && allEvents.Any()
                ? Ok(allEvents)
                : NotFound("No event records found.");
        }

        // Retrieves a specific event by ID
        [HttpGet("GetEvent/{id}")]
        public IActionResult FetchEventById(int id)
        {
            var result = _eventRepo.GetEventsById(id);
            return result != null
                ? Ok(result)
                : NotFound($"No event found with ID = {id}");
        }

        // Adds a new event entry
        [HttpPost("CreateEvent")]
        public IActionResult CreateNewEvent([FromBody] EventDetails newEvent)
        {
            if (newEvent == null)
                return BadRequest("Invalid event data received.");

            _eventRepo.AddEvent(newEvent);
            return Created(HttpContext.Request.Path, newEvent);
        }

        // Deletes an event using its ID
        [HttpDelete("RemoveEvent/{id}")]
        public IActionResult RemoveEvent(int id)
        {
            var deleted = _eventRepo.DeleteEvent(id);
            return deleted != null
                ? Ok(deleted)
                : NotFound($"Unable to remove event with ID = {id}");
        }

        // Updates existing event details
        [HttpPut("EditEvent")]
        public IActionResult EditEvent([FromBody] EventDetails updatedEvent)
        {
            if (updatedEvent == null)
                return BadRequest("Invalid event update data.");

            var result = _eventRepo.UpdateEvent(updatedEvent);
            return result != null
                ? Accepted(HttpContext.Request.Path, result)
                : NotFound("Event not found or update failed.");
        }
    }
}
