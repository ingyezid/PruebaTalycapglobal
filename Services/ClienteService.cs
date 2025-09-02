using Microsoft.EntityFrameworkCore;
using PruebaTalycapglobal.DataContext;
using PruebaTalycapglobal.Models;

namespace PruebaTalycapglobal.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ProjectContext _context;

        public ClienteService(ProjectContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Cliente>?> GetAll()
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

        public async Task<Cliente?> GetById(Guid id)
        {
            try
            {
                var result = await _context.Clientes.FindAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por Id", ex);
            }
        }


        public async Task Save(Cliente cliente)
        {
            try
            {
                cliente.Id = Guid.NewGuid();

                _context.Add(cliente);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el cliente", ex);
            }
        }

        public async Task Update(Guid id, Cliente cliente)
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
        public async Task Delete(Guid id)
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

        public async Task<Cliente?> GetByIdentificacion(string identificacion)
        {
            try
            {
                var result = await _context.Clientes.FirstOrDefaultAsync(c => c.Identificacion == identificacion);

                return result;

            }

            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por identificacion", ex);
            }

        }
    }
}
