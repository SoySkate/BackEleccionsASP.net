using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEleccionsM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartitPoliticController : Controller
    {
        private readonly IPartitPoliticService _partitPoliticService;

        public PartitPoliticController(IPartitPoliticService partitPoliticService)
        {
            _partitPoliticService = partitPoliticService;
        }

        //________________READ ALL Partits
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PartitPolitic>))]
        public async Task<IActionResult> GetPartits()
        {
            var partits = await _partitPoliticService.GetPartitsPolitics();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(partits); }
        }

        //________________READ A Partit byID
        [HttpGet("{partitId}")]
        [ProducesResponseType(200, Type = typeof(PartitPolitic))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPartit(int partitId)
        {
            var partit = await _partitPoliticService.GetPartitPolitic(partitId);
            if (partit == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(partit);
        }
		//________________READ A Partit by Municipi ID
		[HttpGet("muniID/{muniId}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<PartitPolitic>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetPartitByMuniID(int muniId)
		{
			var partits = await _partitPoliticService.GetPartitsPoliticsByMuniID(muniId);
			if (partits == null) { return NotFound(); }
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			else { return Ok(partits); }
		}

		//_______________________________Create Partit   
		[HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePartitPolitic([FromBody] PartitPoliticDto partitCreate)
        {
            if (partitCreate == null) { return BadRequest(ModelState); }
            var partitCreated = await _partitPoliticService.CreatePartitPolitic(partitCreate);

            if (!partitCreated)
            {
                ModelState.AddModelError("", "Partit Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Succesfully created");
        }

        //________________________UPDATE PartitPolitic
        [HttpPut("{partitId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdatePartitPolitic(int partitId, [FromBody] PartitPoliticDto partitUpdate)
        {
            if (partitUpdate == null) { return BadRequest(ModelState); }

            if (partitId != partitUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!_partitPoliticService.PartitPoliticExists(partitId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _partitPoliticService.UpdatePartitPolitic(partitUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating partit");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //________________________DELETE PartitPolitic
        [HttpDelete("{partitId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeletePartit(int partitId)
        {
            if (!_partitPoliticService.PartitPoliticExists(partitId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _partitPoliticService.DeletePartitPolitic(partitId))
                ModelState.AddModelError("", "Something went wrong deleting partit");

            return NoContent();

        }
    }
}
