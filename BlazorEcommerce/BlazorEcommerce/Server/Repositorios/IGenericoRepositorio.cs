using System.Linq.Expressions;

namespace BlazorEcommerce.Server.Repositorios
{
    public interface IGenericoRepositorio<TModel> where TModel : class
    {
        IQueryable<TModel> Consultar(Expression<Func<TModel, bool>>? filtro = null);
        Task<TModel> Crear(TModel modelo);
        Task<bool> Editar(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
    }
}
