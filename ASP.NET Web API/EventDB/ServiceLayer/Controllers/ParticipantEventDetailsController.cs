using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ParticipantEventDetailsController : ControllerBase
    {
        private readonly IParticipantEventDetailsRepo<ParticipantEventDetails> _participantRepo;
        private readonly IConfiguration _config;

        public ParticipantEventDetailsController(IParticipantEventDetailsRepo<ParticipantEventDetails> participantRepo, IConfiguration config)
        {
            _participantRepo = participantRepo;
            _config = config;
        }

        // Returns the list of all participant-event records
        [HttpGet("All")]
        public IActionResult FetchAllParticipants()
        {
            var records = _participantRepo.GetAllParticipantEventDetails();

            return records != null && records.Any()
                ? Ok(records)
                : NotFound("No participant event data found.");
        }

        // Returns participant-event data by participant ID
        [HttpGet("ById/{id}")]
        public IActionResult FetchParticipantById(int id)
        {
            var result = _participantRepo.GetParticipantEventDetailsById(id);

            return result != null
                ? Ok(result)
                : NotFound($"Participant with ID = {id} not found.");
        }

        // Adds a new participant-event entry
        [HttpPost("Register")]
        public IActionResult RegisterParticipant([FromBody] ParticipantEventDetails participant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _participantRepo.AddParticipantEventDetails(participant);
            return Created(HttpContext.Request.Path, created);
        }

        // Updates participant-event data
        [HttpPut("Edit")]
        public IActionResult EditParticipant([FromBody] ParticipantEventDetails participant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _participantRepo.UpdateParticipantEventDetails(participant);

            return updated != null
                ? Accepted(HttpContext.Request.Path, updated)
                : NotFound("Update failed. Participant may not exist.");
        }

        // Deletes a participant-event record by ID
        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveParticipant(int id)
        {
            var deleted = _participantRepo.DeleteParticipantEventDetails(id);

            return deleted != null
                ? Ok(deleted)
                : NotFound($"No record found for Participant ID = {id}");
        }
    }
}
