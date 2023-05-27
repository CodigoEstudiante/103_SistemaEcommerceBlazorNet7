namespace BlazorEcommerce.Server.Repositorios
{
    public interface IVentaRepositorio : IGenericoRepositorio<Venta>
    {
      Task<Venta> Registrar(Venta modelo);
    }
}
