using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class PersonaDTO
    {
        
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Ingrese correo")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Clave { get; set; }
        [Required(ErrorMessage = "Ingrese confirmar contraseña")]
        public string? ConfirmarClave { get; set; }

        public string? Rol { get; set; }
    }
}
