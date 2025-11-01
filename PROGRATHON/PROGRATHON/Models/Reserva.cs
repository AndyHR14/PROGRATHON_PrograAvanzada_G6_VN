namespace PROGRATHON.Models
{
    public class Reserva
    {
        public int IDReserva { get; set; }
        public int IDUsuario { get; set; }
        public int IDLab { get; set; }
        public DateTime FechaYHora { get; set; }
    }
}
