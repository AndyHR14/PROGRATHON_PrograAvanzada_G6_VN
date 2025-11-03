using System.ComponentModel.DataAnnotations;

namespace PROGRATHON.Models
{
    public class Laboratorio
    {
        [Key]
        public int IDLab { get; set; }

        public required string NombreLab { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required] 
        public required string Responsable { get; set; }

    }
}