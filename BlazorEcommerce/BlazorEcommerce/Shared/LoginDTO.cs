using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese correo")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Clave { get; set; }
    }
}
