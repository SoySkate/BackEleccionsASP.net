using BackEleccionsM.Dto;
using BackEleccionsM.Interfaces;
using BackEleccionsM.Models;
using BackEleccionsM.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEleccionsM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultatsTaulaController :Controller
    {
        private readonly IResultatsTaulaService _resultatsTaulaService;

        public ResultatsTaulaController(IResultatsTaulaService resultatsTaulaService)
        {
            _resultatsTaulaService = resultatsTaulaService;
        }

        //________________READ ALL ResultatsTaules
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ResultatsTaula>))]
        public async Task<IActionResult> GetResultatsTaula()
        {
            var resultatsTaula = await _resultatsTaulaService.GetResultatsTaules();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(resultatsTaula); }
        }

        //________________READ A ResultatsTaula byID
        [HttpGet("{resultatsTaulaId}")]
        [ProducesResponseType(200, Type = typeof(ResultatsTaula))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetResultatsTaula(int resultatsTaulaId)
        {
            var resultatsTaula = await _resultatsTaulaService.GetResultatsTaula(resultatsTaulaId);
            if (resultatsTaula == null) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(resultatsTaula);
        }

        //_______________________________Create ResultatsTaula   
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateResultatsTaula([FromBody] ResultatsTaulaDto resultatsTaulaCreate)
        {
            if (resultatsTaulaCreate == null) { return BadRequest(ModelState); }
            var resultatsTaula = await _resultatsTaulaService.CreateResultatsTaula(resultatsTaulaCreate);

            if (!resultatsTaula)
            {
                ModelState.AddModelError("", "ResultatsTaula Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Succesfully created");
        }

        //________________________UPDATE ResultatsTaula
        [HttpPut("{resultatsTaulaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateResultatsTaula(int resultatsTaulaId, [FromBody] ResultatsTaulaDto resultatsTaulaUpdate)
        {
            if (resultatsTaulaUpdate == null) { return BadRequest(ModelState); }

            if (resultatsTaulaId != resultatsTaulaUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!_resultatsTaulaService.ResultatsTaulaExists(resultatsTaulaId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _resultatsTaulaService.UpdateResultatsTaula(resultatsTaulaUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating resultatsTaula");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //________________________DELETE RresultatsTaula
        [HttpDelete("{resultatsTaulaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteResultatsTaula(int resultatsTaulaId)
        {
            if (!_resultatsTaulaService.ResultatsTaulaExists(resultatsTaulaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _resultatsTaulaService.DeleteResultatsTaula(resultatsTaulaId))
                ModelState.AddModelError("", "Something went wrong deleting resultatsTaula");

            return NoContent();

        }
    }
}
