using System.ComponentModel.DataAnnotations;

namespace PROGRATHON.Models
{
    public class Reserva
    {
        [Key]
        public int IDReserva { get; set; }
        public int IDUsuario { get; set; }
        public int IDLab { get; set; }
        public DateTime FechaYHora { get; set; }
        public bool Activa { get; set; } = true;
    }
}
