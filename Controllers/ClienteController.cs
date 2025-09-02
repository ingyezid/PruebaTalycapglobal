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
        [ProducesResponseType(typeof(List<ClienteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
