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
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IGenericoRepositorio<Categoria> _ModeloRepositorio;
        private readonly IMapper _Mapper;

        public CategoriaServicio(IGenericoRepositorio<Categoria> modeloRepositorio, IMapper mapper)
        {
            _ModeloRepositorio = modeloRepositorio;
            _Mapper = mapper;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {
                var DbModelo = _Mapper.Map<Categoria>(modelo);
                var RspModelo = await _ModeloRepositorio.Crear(DbModelo);
                if (RspModelo.IdCategoria != 0) return _Mapper.Map<CategoriaDTO>(RspModelo); else throw new TaskCanceledException("No se puede crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdCategoria == modelo.IdCategoria);
                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if (FromDbModelo != null)
                {
                    FromDbModelo.Nombre = modelo.Nombre;
                   
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
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdCategoria == id);
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

        public async Task<List<CategoriaDTO>> Lista(string buscar)
        {
            try
            {

                var Consulta = _ModeloRepositorio.Consultar(p => 
                p.Nombre!.ToLower().Contains(buscar.ToLower())
                );

                List<CategoriaDTO> lista = _Mapper.Map<List<CategoriaDTO>>(await Consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdCategoria == id);

                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if (FromDbModelo != null) return _Mapper.Map<CategoriaDTO>(FromDbModelo); else throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
