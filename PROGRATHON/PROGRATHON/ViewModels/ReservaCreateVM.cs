using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PROGRATHON.ViewModels
{
    public class ReservaCreateVM
    {
        [Required(ErrorMessage = "Seleccione un usuario")]
        [Display(Name = "Usuario")]
        public int IDUsuario { get; set; }

        [Required(ErrorMessage = "Seleccione un laboratorio")]
        [Display(Name = "Laboratorio")]
        public int IDLab { get; set; }

        [Required(ErrorMessage = "Indique la fecha y hora")]
        [Display(Name = "Fecha y hora")]
        public DateTime FechaYHora { get; set; }

        // Dropdowns
        public IEnumerable<SelectListItem>? Usuarios { get; set; }
        public IEnumerable<SelectListItem>? Laboratorios { get; set; }
    }
}
