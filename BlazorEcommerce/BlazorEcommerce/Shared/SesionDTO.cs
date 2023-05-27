using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class SesionDTO
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? Rol { get; set; }
    }
}
