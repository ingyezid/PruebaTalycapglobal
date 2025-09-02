
using PruebaTalycapglobal.DTOs;
using PruebaTalycapglobal.Models;
using PruebaTalycapglobal.Repositories;

namespace PruebaTalycapglobal.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<List<ClienteDto>?> ObtenerTodosAsync()
        {
            try
            {
                var clientes = await _clienteRepository.GetAllAsync();

                if (clientes == null)
                {
                    return null;
                }

                // Mapeando entidad a Dto
                var result = clientes?.Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Identificacion = c.Identificacion,
                    TipoDocumento = c.TipoDocumento,
                    Nombres = c.Nombres,
                    Apellidos = c.Apellidos,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono,
                    Email = c.Email
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }
        }

        public async Task<ClienteDto?> ObtenerByIdAsync(Guid id)
        {
            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);

                if (cliente == null)
                {
                    return null;
                }

                // Mapeando entidad a Dto
                var result = new ClienteDto
                {
                    Id = cliente.Id,
                    Identificacion = cliente.Identificacion,
                    TipoDocumento = cliente.TipoDocumento,
                    Nombres = cliente.Nombres,
                    Apellidos = cliente.Apellidos,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por Id", ex);
            }
        }

        public async Task<ClienteDto> CrearClienteAsync(ClienteCreateDto clienteCreateDto)
        {
            try
            {
                var cliente = await _clienteRepository.CreateAsync(new Cliente
                {
                    Identificacion = clienteCreateDto.Identificacion,
                    TipoDocumento = clienteCreateDto.TipoDocumento,
                    Nombres = clienteCreateDto.Nombres,
                    Apellidos = clienteCreateDto.Apellidos,
                    Direccion = clienteCreateDto.Direccion,
                    Telefono = clienteCreateDto.Telefono,
                    Email = clienteCreateDto.Email
                });

                var nuevoCliente = new ClienteDto
                {
                    Id = cliente.Id,
                    Identificacion = cliente.Identificacion,
                    TipoDocumento = cliente.TipoDocumento,
                    Nombres = cliente.Nombres,
                    Apellidos = cliente.Apellidos,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email
                };

                return nuevoCliente;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el cliente", ex);
            }
        }

        public async Task ActualizarClienteAsync(Guid id, ClienteUpdateDto clienteUpdateDto)
        {
            try
            {
                var clienteActual = await _clienteRepository.GetByIdAsync(id);

                if (clienteActual != null)
                {
                    await _clienteRepository.UpdateAsync(id, new Cliente
                    {
                        Id = id,
                        Identificacion = clienteUpdateDto.Identificacion,
                        TipoDocumento = clienteUpdateDto.TipoDocumento,
                        Nombres = clienteUpdateDto.Nombres,
                        Apellidos = clienteUpdateDto.Apellidos,
                        Direccion = clienteUpdateDto.Direccion,
                        Telefono = clienteUpdateDto.Telefono,
                        Email = clienteUpdateDto.Email
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente", ex);
            }
        }
        public async Task EliminarClienteAsync(Guid id)
        {
            try
            {
                var clienteActual = await _clienteRepository.GetByIdAsync(id);

                if (clienteActual != null)
                {
                    await _clienteRepository.DeleteAsync(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente", ex);
            }
        }

        public async Task<ClienteDto?> ObtenerByIdentificacionAsync(string identificacion)
        {
            try
            {
                var cliente = await _clienteRepository.GetByIdentificacionAsync(identificacion);

                if (cliente == null)
                {
                    return null;
                }

                // Mapeando entidad a Dto
                var result = new ClienteDto
                {
                    Id = cliente.Id,
                    Identificacion = cliente.Identificacion,
                    TipoDocumento = cliente.TipoDocumento,
                    Nombres = cliente.Nombres,
                    Apellidos = cliente.Apellidos,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email
                };

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por Identificacion", ex);
            }
        }
    }
}
