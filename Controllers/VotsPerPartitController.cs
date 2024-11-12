using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEleccionsM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotsPerPartitController : Controller
    {
        private readonly IVotsPerPartitService _votsPerPartitService;

        public VotsPerPartitController(IVotsPerPartitService votsPerPartitService)
        {
            _votsPerPartitService = votsPerPartitService;
        }


        //________________READ ALL VotsPerPartit
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VotsPerPartit>))]
        public async Task<IActionResult> GetVotsPerPartits()
        {
            var votsPerPartit = await _votsPerPartitService.GetVotsPerPartits();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(votsPerPartit); }
        }

        //________________READ A VotsPerPartit byID
        [HttpGet("{votsPerPartitId}")]
        [ProducesResponseType(200, Type = typeof(VotsPerPartit))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetVotsPerPartit(int votsPerPartitId)
        {
            var votsPerPartit = await _votsPerPartitService.GetVotsPerPartit(votsPerPartitId);
            if (votsPerPartit == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(votsPerPartit);
        }

        //_______________________________Create VotsPerPartit   
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateVotsPerPartit([FromBody] VotsPerPartitDto votsPerPartitCreate)
        {
            if (votsPerPartitCreate == null) { return BadRequest(ModelState); }
            var votsPerPartitCreated = await _votsPerPartitService.CreateVotsPerPartit(votsPerPartitCreate);

            if (!votsPerPartitCreated)
            {
                ModelState.AddModelError("", "VotsPerPartit Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Succesfully created");
        }

        //________________________UPDATE VotsPerPartit
        [HttpPut("{votsPerPartitId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateVotsPerPartit(int votsPerPartitId, [FromBody] VotsPerPartitDto votsPerPartitUpdate)
        {
            if (votsPerPartitUpdate == null) { return BadRequest(ModelState); }

            if (votsPerPartitId != votsPerPartitUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!_votsPerPartitService.VotsPerPartitExists(votsPerPartitId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _votsPerPartitService.UpdateVotsPerPartit(votsPerPartitUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating VotsPerPartit");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //________________________DELETE VotsPerPartit
        [HttpDelete("{votsPerPartitId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVotsPerPartit(int votsPerPartitId)
        {
            if (!_votsPerPartitService.VotsPerPartitExists(votsPerPartitId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _votsPerPartitService.DeleteVotsPerPartit(votsPerPartitId))
                ModelState.AddModelError("", "Something went wrong deleting VotsPerPartit");

            return NoContent();

        }

    }
}
