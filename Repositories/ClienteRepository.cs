using Microsoft.EntityFrameworkCore;
using PruebaTalycapglobal.DataContext;
using PruebaTalycapglobal.Models;

namespace PruebaTalycapglobal.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProjectContext _context;

        public ClienteRepository(ProjectContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Cliente>?> GetAllAsync()
        {
            try
            {
                var result = await _context.Clientes.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return null;
                }
                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente", ex);
            }
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            try
            {
                cliente.Id = Guid.NewGuid();

                _context.Add(cliente);

                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el cliente", ex);
            }
        }

        public async Task UpdateAsync(Guid id, Cliente cliente)
        {
            try
            {
                var clienteActual = await _context.Clientes.FindAsync(id);

                if (clienteActual != null)
                {
                    clienteActual.Identificacion = cliente.Identificacion;
                    clienteActual.TipoDocumento = cliente.TipoDocumento;
                    clienteActual.Nombres = cliente.Nombres;
                    clienteActual.Apellidos = cliente.Apellidos;
                    clienteActual.Direccion = cliente.Direccion;
                    clienteActual.Telefono = cliente.Telefono;
                    clienteActual.Email = cliente.Email;

                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente", ex);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var clienteActual = await _context.Clientes.FindAsync(id);

                if (clienteActual != null)
                {
                    _context.Remove(clienteActual);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente", ex);
            }
        }


        public async Task<Cliente?> GetByIdentificacionAsync(string identificacion)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Identificacion == identificacion);

            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

    }
}
