using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese precio")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "Ingrese precio oferta")]
        public decimal? PrecioOferta { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese imagen")]
        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }

    }
}
