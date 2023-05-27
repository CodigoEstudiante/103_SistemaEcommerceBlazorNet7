using System;
using System.Collections.Generic;

namespace BlazorEcommerce.Server.Modelos;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? IdPersona { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Persona? IdPersonaNavigation { get; set; }
}
