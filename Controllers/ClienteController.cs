using Microsoft.AspNetCore.Mvc;
using PruebaTalycapglobal.Models;
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
        [ProducesResponseType(typeof(List<Cliente>), StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Cliente>?>> GetAll()
        {
            var result =  await _clienteService.GetAll();

            if (result == null)
            {
                return NotFound();
            }

             return result;
        }

        [HttpGet("{id}")]
       
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Cliente?>> GetById(Guid id)
        {
            var result = await _clienteService.GetById(id);

            if (result == null)
            { 
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cliente),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            await _clienteService.Save(cliente);

            return CreatedAtAction(nameof(Post), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]   
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            var clienteFind = await _clienteService.GetById(id);
            if (clienteFind == null)
            {
                return NotFound();
            }

            await _clienteService.Update(id, cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteFind = await _clienteService.GetById(id);
            if (clienteFind == null)
            {
                return NotFound();
            }

            await _clienteService.Delete(id);

            return NoContent();
        }

        [HttpGet("identificacion/{identificacion}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Cliente?>> GetByIdentificacion(string identificacion)
        {             
            var result = await _clienteService.GetByIdentificacion(identificacion);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

    }
}
