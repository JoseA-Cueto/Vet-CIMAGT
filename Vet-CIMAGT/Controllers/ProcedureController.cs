using Microsoft.AspNetCore.Mvc;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Controllers
{
    [Route("api/Procedures")]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpGet("GetAllProcedures")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProcedureDTOs>>> GetAllProcedures()
        {
            try
            {
                var procedures = await _procedureService.GetAllProceduresAsync();
                return Ok(procedures);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetProcedureById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProcedureDTOs>> GetProcedureById(Guid id)
        {
            try
            {
                var procedure = await _procedureService.GetProcedureByIdAsync(id);
                if (procedure == null)
                {
                    return NotFound();
                }
                return Ok(procedure);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("CreateProcedure")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProcedure([FromForm] ProcedureDTOs procedureDTOs)
        {
            try
            {
                await _procedureService.CreateProcedureAsync(procedureDTOs);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateProcedure")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProcedure(ProcedureDTOs procedureDTOs)
        {
            try
            {
                await _procedureService.UpdateProcedureAsync(procedureDTOs);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteProcedure/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProcedure(Guid id)
        {
            try
            {
                await _procedureService.DeleteProcedureAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
