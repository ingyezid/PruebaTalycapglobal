using System.ComponentModel.DataAnnotations;
using static PruebaTalycapglobal.Data.Enums.UtilEnum;


namespace PruebaTalycapglobal.Data.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Identificacion { get; set; } 

        [Required]
        public TipoDocumento TipoDocumento { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Apellidos { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Direccion { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Telefono { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
    }

}
