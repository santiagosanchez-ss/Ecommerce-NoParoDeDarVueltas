using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IVentaRepositorio : IGenericoRepositorio <Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
