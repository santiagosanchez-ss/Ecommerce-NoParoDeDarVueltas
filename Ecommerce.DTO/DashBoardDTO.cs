using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class DashBoardDTO
    {
        public string? Ingresos {  get; set; }
        public int TotalVentas { get; set; }
        public int TotalClientes{ get; set; }
        public int TotalProductos { get; set; }
     
    }
}
