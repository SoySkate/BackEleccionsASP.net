using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEleccionsM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : Controller
    {
        private readonly ICandidatService _candidatService;

        public CandidatController(ICandidatService candidatService)
        {
            _candidatService = candidatService;
        }

        //________________READ ALL Candidats
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Candidat>))]
        public async Task<IActionResult> GetCandidats()
        {
            var candidats = await _candidatService.GetCandidats();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(candidats); }
        }

        //________________READ A Candidats byID
        [HttpGet("{candidatId}")]
        [ProducesResponseType(200, Type = typeof(Candidat))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCandidat(int candidatId)
        {
            var cand = await _candidatService.GetCandidat(candidatId);
            if (cand == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(cand);
        }

		//________________READ A Candidats by partitID
		[HttpGet("partit/{partitID}")]
		[ProducesResponseType(200, Type = typeof(Candidat))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetCandidatsByPartitID(int partitID)
		{
			var candidats = await _candidatService.GetCandidatsByPartitId(partitID);
			if (candidats == null) { return NotFound(); }
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			return Ok(candidats);
		}

		//________________READ A Candidats by muniID
		[HttpGet("muni/{muniID}")]
		[ProducesResponseType(200, Type = typeof(Candidat))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetCandidatsByMuniID(int muniID)
		{
			var candidats = await _candidatService.GetCandidatsByMunicipiId(muniID);
			if (candidats == null) { return NotFound(); }
			if (!ModelState.IsValid) { return BadRequest(ModelState); }
			return Ok(candidats);
		}

		//_______________________________Create CANDIDAT   
		[HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCandidat([FromBody] CandidatDto candidatCreate)
        {
            if (candidatCreate == null) { return BadRequest(ModelState); }
            var candCreated = await _candidatService.CreateCandidat(candidatCreate);

            if (!candCreated)
            {
                ModelState.AddModelError("", "Candidat Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Succesfully created");
        }

        //________________________UPDATE CANDIDAT
        [HttpPut("{candidatId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCandidat(int candidatId, [FromBody] CandidatDto candidatUpdate)
        {
            if (candidatUpdate == null) { return BadRequest(ModelState); }

            if (candidatId != candidatUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (! _candidatService.CandidatExists(candidatId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _candidatService.UpdateCandidat(candidatUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating candidat");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //________________________DELETE CANDIDAT
        [HttpDelete("{candidatId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int candidatId)
        {
            if (! _candidatService.CandidatExists(candidatId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _candidatService.DeleteCandidat(candidatId))
                ModelState.AddModelError("", "Something went wrong deleting candidat");

            return NoContent();
           
        }   


    }
}
