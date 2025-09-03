using PruebaTalycapglobal.Data.Models;

namespace PruebaTalycapglobal.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>?> GetAllAsync();
        Task<Cliente?> GetByIdAsync(Guid id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Guid id, Cliente cliente);
        Task DeleteAsync(Guid id);
        Task<Cliente?> GetByIdentificacionAsync(string identificacion);


    }
}
