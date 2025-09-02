using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTalycapglobal.DTOs;
using PruebaTalycapglobal.Services;

namespace PruebaTalycapglobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<ClienteDto>), StatusCodes.Status200OK)]        
        public async Task<ActionResult<List<ClienteDto>?>> GetAll()
        {
            var result = await _clienteService.ObtenerTodosAsync();

            if (result == null)
            {
                return NotFound(new { message = "Clientes no encontrados" });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ClienteDto?>> GetById(Guid id)
        {
            var result = await _clienteService.ObtenerByIdAsync(id);

            if (result == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<ClienteDto>> Post([FromBody] ClienteCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevoCliente = await _clienteService.CrearClienteAsync(dto);

            return CreatedAtAction(nameof(Post), nuevoCliente);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ClienteUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "El ID del cliente no coincide" });

            var clienteFind = await _clienteService.ObtenerByIdAsync(id);
            if (clienteFind == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            await _clienteService.ActualizarClienteAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteFind = await _clienteService.ObtenerByIdAsync(id);
            if (clienteFind == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            await _clienteService.EliminarClienteAsync(id);

            return NoContent();
        }

        [HttpGet("identificacion/{identificacion}")]
        [Authorize]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ClienteDto?>> GetByIdentificacion(string identificacion)
        {
            var result = await _clienteService.ObtenerByIdentificacionAsync(identificacion);

            if (result == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            return Ok(result);
        }

    }
}
