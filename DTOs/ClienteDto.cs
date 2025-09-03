using static PruebaTalycapglobal.Data.Enums.UtilEnum;

namespace PruebaTalycapglobal.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        public string? Identificacion { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

    }
}
