using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEleccionsM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiController :Controller
    {
        private readonly IMunicipiService _municipiService;

        public MunicipiController(IMunicipiService municipiService)
        {
            _municipiService = municipiService;
        }

        //________________READ ALL Municipis

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Municipi>))]
        public async Task<IActionResult> GetMunicipis()
        {
            var munis = await _municipiService.GetMunicipis();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(munis); }
        }

        //________________READ A Municipi byID
        [HttpGet("{muniId}")]
        [ProducesResponseType(200, Type = typeof(Municipi))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMunicipi(int muniId)
        {
            var muni = await _municipiService.GetMunicipi(muniId);
            if (muni == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(muni);
        }
        //________________READ A Municipi byName
        [HttpGet("{muniName}")]
        [ProducesResponseType(200, Type = typeof(Municipi))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMunicipiByName(string muniName)
        {
            var muni = await _municipiService.GetMunicipi(muniName);
            if (muni == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(muni);
        }

        //_______________________________Create municipi  
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMunicipi([FromBody] MunicipiDto municipiCreate)
        {
            if (municipiCreate == null) { return BadRequest(ModelState); }
            var muniCreated = await _municipiService.CreateMunicipi(municipiCreate);

            if (!muniCreated)
            {
                ModelState.AddModelError("", "Candidat Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Succesfully created");
        }

        //________________________UPDATE MUNICIPI
        [HttpPut("{municipiId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMunicipi(int municipiId, [FromBody] MunicipiDto municipiUpdate)
        {
            if (municipiUpdate == null) { return BadRequest(ModelState); }

            if (municipiId != municipiUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!_municipiService.MunicipiExists(municipiId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _municipiService.UpdateMunicipi(municipiUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating municipi");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //________________________DELETE Municipi
        [HttpDelete("{municipiId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMunicipi(int municipiId)
        {
            if (!_municipiService.MunicipiExists(municipiId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _municipiService.DeleteMunicipi(municipiId))
                ModelState.AddModelError("", "Something went wrong deleting municipi");

            return NoContent();

        }

    }
}
