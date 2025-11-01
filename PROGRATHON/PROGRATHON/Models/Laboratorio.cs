using System.ComponentModel.DataAnnotations;

namespace PROGRATHON.Models
{
    public class Laboratorio
    {
        [Key]
        public int IDLab { get; set; }
        public string NombreLab { get; set; }
        public int Capacidad { get; set; }
        public string Responsable { get; set; }
    }
}