using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;

namespace Ecommerce.Repository.Implementation
{
    public class GenericoRepositorio <T> : IGenericoRepositorio<T> where T : class
    {
        private readonly NoParoDeDarVueltasDbContext _dbContext;
        public GenericoRepositorio(NoParoDeDarVueltasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> consulta = (filtro == null)?_dbContext.Set<T>(): _dbContext.Set<T>().Where(filtro);
            return consulta;
        }

        public async Task<T> Crear(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }catch
            {
                throw;
            }
                
        }

        public async Task<bool> Editar(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ELiminar(T modelo)
        {

            try
            {
                _dbContext.Set<T>().Remove(modelo);
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
