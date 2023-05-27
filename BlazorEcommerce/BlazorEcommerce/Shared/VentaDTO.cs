using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }

        public int? IdPersona { get; set; }

        public decimal? Total { get; set; }

        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; } = new List<DetalleVentaDTO>();

    }
}
