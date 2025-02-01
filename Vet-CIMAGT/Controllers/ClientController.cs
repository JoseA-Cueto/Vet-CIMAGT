using Microsoft.AspNetCore.Mvc;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Controllers
{
    [Route("api/Client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
      
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
            
        }

        [HttpGet("GetAllClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClientDTOs>>> GetAllClients()
        {
            try
            {
                var clients = await _clientService.GetAllClientsAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetClientById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDTOs>> GetClientById(Guid id)
        {
            try
            {
                var client = await _clientService.GetClientByIdAsync(id);
                if (client == null)
                {
                    return NotFound();
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPost("AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddClient([FromBody] ClientDTOs clientDTOs)
        {
            try
            {
                await _clientService.CreateCLientAsync(clientDTOs);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500);// Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPut("UpdateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateClient([FromBody] ClientDTOs clientDTOs)
        {
            try
            {
          
                await _clientService.UpdateClientAsync(clientDTOs);
                return Ok();
            }
            catch (Exception ex)
            {
               

                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpDelete("DeleteClient/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            try
            {             
                await _clientService.DeleteClientAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
               
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }
    }
}

