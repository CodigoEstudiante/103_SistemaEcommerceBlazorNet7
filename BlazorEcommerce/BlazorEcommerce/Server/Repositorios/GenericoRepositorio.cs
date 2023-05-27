
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorEcommerce.Server.Repositorios
{
    public class GenericoRepositorio<TModelo> : IGenericoRepositorio<TModelo> where TModelo : class
    {
        private readonly DbtiendaBlazorContext _dbContext;
        public GenericoRepositorio(DbtiendaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
        {
            IQueryable<TModelo> consulta = filtro == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
            return consulta;
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
