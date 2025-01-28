using Microsoft.AspNetCore.Mvc;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Controllers
{

    [Route("api/Consumption")]
    public class ConsumptionController : ControllerBase
    {
        private readonly IConsumptionService _consumptionService;

        public ConsumptionController(IConsumptionService consumptionService)
        {
            _consumptionService = consumptionService;

        }

        [HttpGet("GetAllConsumptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ConsumptionDTOs>>> GetAllConsumptions()
        {
            try
            {
                var consumptions = await _consumptionService.GetAllConsumptionsAsync();
                return Ok(consumptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetConsumptionByIdAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConsumptionDTOs>> GetConsumptionByIdAsync(Guid id)
        {
            try
            {
                var consumptions = await _consumptionService.GetConsumptionByIdAsync(id);
                if (consumptions == null)
                {
                    return NotFound();
                }
                return Ok(consumptions);
            }
            catch (Exception ex)
            {

                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPost("CreateConsumptionAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateConsumptionAsync([FromForm] ConsumptionDTOs consumptionDTOs)
        {
            try
            {
                await _consumptionService.CreateConsumptionAsync(consumptionDTOs);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return StatusCode(500);// Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPut("UpdateConsumptionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateConsumptionAsync(ConsumptionDTOs consumptionDTOs)
        {
            try
            {

                await _consumptionService.UpdateConsumptionAsync(consumptionDTOs);
                return Ok();
            }
            catch (Exception ex)
            {


                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpDelete("DeleteConsumptionAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteConsumptionAsync(Guid id)
        {
            try
            {
                await _consumptionService.DeleteConsumptionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }
    }
}
