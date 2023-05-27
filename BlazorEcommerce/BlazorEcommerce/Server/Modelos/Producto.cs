using System;
using System.Collections.Generic;

namespace BlazorEcommerce.Server.Modelos;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public decimal? PrecioOferta { get; set; }

    public int? Cantidad { get; set; }

    public string? Imagen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
