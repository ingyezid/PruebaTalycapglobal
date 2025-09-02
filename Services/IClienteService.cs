using PruebaTalycapglobal.DTOs;

namespace PruebaTalycapglobal.Services
{
    public interface IClienteService
    {
        Task<List<ClienteDto>?> ObtenerTodosAsync();

        Task<ClienteDto?> ObtenerByIdAsync(Guid id);

        Task<ClienteDto> CrearClienteAsync(ClienteCreateDto clienteCreateDto);

        Task ActualizarClienteAsync(Guid id, ClienteUpdateDto clienteUpdateDto);

        Task EliminarClienteAsync(Guid id);

        Task<ClienteDto?> ObtenerByIdentificacionAsync(string identificacion);

    }
}
