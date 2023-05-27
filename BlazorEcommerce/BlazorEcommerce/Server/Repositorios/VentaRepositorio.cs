
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Repositorios
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly DbtiendaBlazorContext _dbContext;
        public VentaRepositorio(DbtiendaBlazorContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta VentaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // restaremos el stock de cada producto dentro de la venta
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    VentaGenerada = modelo;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return VentaGenerada;
        }
    }
}
