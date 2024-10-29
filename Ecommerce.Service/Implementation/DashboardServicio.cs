using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using Ecommerce.Repository.Implementation;
namespace Ecommerce.WebAssembly.Service.Implementation 
{ 
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IGenericoRepositorio<Usuario> _UsuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _ProductoRepositorio;

        public DashboardServicio(
            IVentaRepositorio ventaRepositorio,
           IGenericoRepositorio<Usuario> UsuarioRepositorio,
           IGenericoRepositorio<Producto> ProductoRepositorio
           )
        {
           _ventaRepositorio = ventaRepositorio;
            _UsuarioRepositorio = UsuarioRepositorio;
            _ProductoRepositorio = ProductoRepositorio;
        }
        private string Ingresos()
        {
            var Consulta = _ventaRepositorio.Consultar();
            decimal? Ingresos = Consulta.Sum(x => x.Total);
            return Convert.ToString(Ingresos);
        }
        private int Ventas()
        {
            var Consulta = _ventaRepositorio.Consultar();
            int Total = Consulta.Count();
            return Total;
        }
        private int Cantidad()
        {
            var Consulta = _UsuarioRepositorio.Consultar(u => u.Rol.ToLower()=="CLiente");
            int Total = Consulta.Count();
            return Total;
        }
        private int Productos()
        {
            var Consulta = _ProductoRepositorio.Consultar();
            int Total = Consulta.Count();
            return Total;
        }
        public DashBoardDTO Resumen()
        {
            try
            {
                DashBoardDTO dashBoardDTO = new DashBoardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalClientes = Cantidad(),
                    TotalProductos = Productos(),
                    TotalVentas = Ventas(), 
                };
                return dashBoardDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
