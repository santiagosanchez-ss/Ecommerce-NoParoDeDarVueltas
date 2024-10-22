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


namespace Ecommerce.Service.Implementation
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio  _ModeloRepositorio;
        private readonly IMapper _Mapper;
        public VentaServicio(IVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _ModeloRepositorio = modeloRepositorio;
            _Mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var DbModelo = _Mapper.Map<Venta>(modelo);
                var ventaGenerada = await _ModeloRepositorio.Registrar(DbModelo);
                if (ventaGenerada.IdVenta == 0)  throw new TaskCanceledException("No se puede crear");

                return _Mapper.Map<VentaDTO>(ventaGenerada);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
