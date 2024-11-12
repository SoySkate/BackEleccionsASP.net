using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEleccionsM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaulaElectoralController :Controller
    {
        private readonly ITaulaElectoralService _taulaElectoralService;

        public TaulaElectoralController(ITaulaElectoralService taulaElectoralService)
        {
            _taulaElectoralService = taulaElectoralService;
        }

        //________________READ ALL TaulaElectoral
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TaulaElectoral>))]
        public async Task<IActionResult> GetTaulesElectorals()
        {
            var raulaElectoral = await _taulaElectoralService.GetTaulesElectorals();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(raulaElectoral); }
        }

        //________________READ A TaulaElectoral byID
        [HttpGet("{taulaElectoralId}")]
        [ProducesResponseType(200, Type = typeof(TaulaElectoral))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTaulaElectoral(int taulaElectoralId)
        {
            var taulaElectoral = await _taulaElectoralService.GetTaulaElectoral(taulaElectoralId);
            if (taulaElectoral == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(taulaElectoral);
        }

		//________________READ A TaulesElectorals by MuniID
		[HttpGet("muniID/{muniId}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<TaulaElectoral>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetTauleselectoralsByMuniId(int muniId)
		{
			var taules = await _taulaElectoralService.GetTaulesElectoralsByMuniId(muniId);
			if (taules == null) { return NotFound(); }
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			return Ok(taules);
		}

		//_______________________________Create TaulaElectoral   
		[HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTaulaElectoral([FromBody] TaulaElectoralDto taulaElectoralCreate)
        {
            if (taulaElectoralCreate == null) { return BadRequest(ModelState); }
            var taulaElectoralCreated = await _taulaElectoralService.CreateTaulaElectoral(taulaElectoralCreate);

            if (!taulaElectoralCreated)
            {
                ModelState.AddModelError("", "TaulaElectoral Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Succesfully created");
        }


        //________________________UPDATE TaulaElectoral
        [HttpPut("{taulaElectoralId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTaulaElectoral(int taulaElectoralId, [FromBody] TaulaElectoralDto taulaElectoralUpdate)
        {
            if (taulaElectoralUpdate == null) { return BadRequest(ModelState); }

            if (taulaElectoralId != taulaElectoralUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!_taulaElectoralService.TaulaElectoralExists(taulaElectoralId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _taulaElectoralService.UpdateTaulaElectoral(taulaElectoralUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating TaulaElectoral");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //________________________DELETE TaulaElectoral
        [HttpDelete("{taulaElectoralId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTaulaElectoral(int taulaElectoralId)
        {
            if (!_taulaElectoralService.TaulaElectoralExists(taulaElectoralId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _taulaElectoralService.DeleteTaulaElectoral(taulaElectoralId))
                ModelState.AddModelError("", "Something went wrong deleting TaulaElectoral");

            return NoContent();

        }

    }
}
