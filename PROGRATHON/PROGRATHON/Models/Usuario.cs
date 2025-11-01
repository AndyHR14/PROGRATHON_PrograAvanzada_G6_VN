using System.ComponentModel.DataAnnotations;

namespace PROGRATHON.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public bool TipoUsuario { get; set; }
        public string CorreoElectronico { get; set; }
    }
}