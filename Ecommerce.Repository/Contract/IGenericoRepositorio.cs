using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IGenericoRepositorio <T> where T : class // metodo va a resivir un modelo (T) donde  este va a ser una clase  
    {
        IQueryable<T> Consultar(Expression <Func<T,bool>>? filtro = null);
        Task<T> Crear(T modelo);
        Task<bool> Editar(T modelo);
        Task<bool> ELiminar(T modelo);


    }
}
