using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage = "Ingrese Titular")]
        public string? Titular { get; set; }
        [Required(ErrorMessage = "Ingrese Numero tarjeta")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "Ingrese Vigencia")]
        public string? Vigencia { get; set; }
        [Required(ErrorMessage = "Ingrese CVV")]
        public string? CVV { get; set; }
    }
}
