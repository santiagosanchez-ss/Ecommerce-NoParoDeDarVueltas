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


namespace Ecommerce.WebAssembly.Service.Implementation
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IGenericoRepositorio<Producto> _ModeloRepositorio;
        private readonly IMapper _Mapper;

        public ProductoServicio(IGenericoRepositorio<Producto> modeloRepositorio, IMapper mapper)
        {
            _ModeloRepositorio = modeloRepositorio;
            _Mapper = mapper;

        }

        public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {

                var Consulta = _ModeloRepositorio.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                p.IdCategoriaNavigation.Nombre.ToLower().Contains(buscar.ToLower()));

                List<ProductoDTO> lista = _Mapper.Map<List<ProductoDTO>>(await Consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var DbModelo = _Mapper.Map<Producto>(modelo);
                var RspModelo = await _ModeloRepositorio.Crear(DbModelo);
                if (RspModelo.IdCategoria != 0) return _Mapper.Map<ProductoDTO>(RspModelo); else throw new TaskCanceledException("No se puede crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdProducto == modelo.IdProducto);
                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if (FromDbModelo != null)
                {
                    FromDbModelo.Nombre = modelo.Nombre;
                    FromDbModelo.Descripcion = modelo.Descripcion;
                    FromDbModelo.IdCategoria = modelo.IdCategoria;
                    FromDbModelo.Precio = modelo.Precio;
                    FromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    FromDbModelo.Cantidad = modelo.Cantidad;
                    FromDbModelo.Imagen = modelo.Imagen;

                    var Respuesta = await _ModeloRepositorio.Editar(FromDbModelo);

                    if (!Respuesta) throw new TaskCanceledException("No se pudo editar"); return Respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
                try
                {
                    var Consulta = _ModeloRepositorio.Consultar(p => p.IdProducto == id);
                    var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                    if (FromDbModelo != null)
                    {
                        var Respuesta = await _ModeloRepositorio.ELiminar(FromDbModelo);
                        if (!Respuesta)
                            throw new TaskCanceledException("No se pudo eliminar");
                        return Respuesta;

                    }
                    else
                    {
                        throw new TaskCanceledException("No se encontraron resultados");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try
            {

                var Consulta = _ModeloRepositorio.Consultar(p =>p.Nombre.ToLower().Contains(buscar.ToLower()));

                Consulta = Consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _Mapper.Map<List<ProductoDTO>>(await Consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async  Task<ProductoDTO> Obtener(int id)
        {

            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdProducto == id);
                Consulta = Consulta.Include(c => c.IdCategoriaNavigation);
                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if (FromDbModelo != null) return _Mapper.Map<ProductoDTO>(FromDbModelo); else throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
