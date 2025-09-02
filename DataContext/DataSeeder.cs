using PruebaTalycapglobal.Models;
using static PruebaTalycapglobal.Enums.UtilEnum;

namespace PruebaTalycapglobal.DataContext
{
    public static class DataSeeder
    {
        public static void Seed(ProjectContext context)
        {
            if (context == null)
            {
                return;
            }

            if (!context.Clientes.Any())
            {
                context.Clientes.AddRange(
                    new Cliente
                    {
                        Id = Guid.Parse("2a85dbf4-810e-4585-a849-32a4cdbfb111"),
                        Identificacion = "1234567890",
                        TipoDocumento = TipoDocumento.CC,
                        Nombres = "Juan",
                        Apellidos = "Pérez",
                        Direccion = "Calle 123 #45 - 67",
                        Telefono = "3001234567",
                        Email = "juan.perez@gmail.com"
                    },

                    new Cliente
                    {
                        Id = Guid.Parse("2a85dbf4-810e-4585-a849-32a4cdbfb222"),
                        Identificacion = "2244668800",
                        TipoDocumento = TipoDocumento.CE,
                        Nombres = "Maria",
                        Apellidos = "Castillo",
                        Direccion = "Calle 68 #45 - 30",
                        Telefono = "3012244668",
                        Email = "maria.castillo@hotmail.com"
                    },

                    new Cliente
                    {
                        Id = Guid.Parse("2a85dbf4-810e-4585-a849-32a4cdbfb333"),
                        Identificacion = "1133557799",
                        TipoDocumento = TipoDocumento.NIT,
                        Nombres = "Soluciones Empresariales",
                        Apellidos = "LTDA",
                        Direccion = "Carrera 30 #26 - 15",
                        Telefono = "3175245723",
                        Email = "soluciones.empresariales@soluciones.com"
                    },

                    new Cliente
                    {
                        Id = Guid.Parse("2a85dbf4-810e-4585-a849-32a4cdbfb444"),
                        Identificacion = "1234512345",
                        TipoDocumento = TipoDocumento.TI,
                        Nombres = "Juan",
                        Apellidos = "Medina",
                        Direccion = "Carrera 70 # 10 - 25",
                        Telefono = "6012561567",
                        Email = "juanito10@yahoo.es"
                    },

                    new Cliente
                    {
                        Id = Guid.Parse("2a85dbf4-810e-4585-a849-32a4cdbfb555"),
                        Identificacion = "6789067890",
                        TipoDocumento = TipoDocumento.PA,
                        Nombres = "Ximena",
                        Apellidos = "Bolivar",
                        Direccion = "Calle 105 # 90 - 70",
                        Telefono = "6017894562",
                        Email = "ximenalady@msn.com"
                    }

                );

                context.SaveChanges();
            }

        }

    }

}
