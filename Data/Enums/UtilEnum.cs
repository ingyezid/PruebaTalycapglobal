using System.ComponentModel.DataAnnotations;

namespace PruebaTalycapglobal.Data.Enums
{
    public class UtilEnum
    {
        public enum TipoDocumento
        {
            [Display(Name = "Cédula de Ciudadanía")]
            CC,            
            [Display(Name = "Cédula de Extranjeria")]
            CE,
            [Display(Name = "Tarjeta de Identidad")]
            TI,
            [Display(Name = "Pasaporte")]
            PA,
            [Display(Name = "NIT")]
            NIT
        }
    }
}
