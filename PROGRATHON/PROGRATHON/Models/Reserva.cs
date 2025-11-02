using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGRATHON.Models
{
    public class Reserva
    {
        [Key]
        public int IDReserva { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int IDUsuario { get; set; }

        [Required]
        [Display(Name = "Laboratorio")]
        public int IDLab { get; set; }

        [Required]
        [Display(Name = "Fecha y hora")]
        public DateTime FechaYHora { get; set; }

        [Display(Name = "Activa")]
        public bool Activa { get; set; } = true;

        // Relaciones
        [ForeignKey(nameof(IDUsuario))]
        public Usuario? Usuario { get; set; }

        [ForeignKey(nameof(IDLab))]
        public Laboratorio? Laboratorio { get; set; }
    }
}

