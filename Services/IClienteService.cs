using PruebaTalycapglobal.Models;

namespace PruebaTalycapglobal.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>?> GetAll();

        Task<Cliente?> GetById(Guid id);

        Task Save (Cliente cliente);

        Task Update (Guid id, Cliente cliente);

        Task Delete (Guid id);

        Task<Cliente?> GetByIdentificacion(string identificacion);

    }
}
