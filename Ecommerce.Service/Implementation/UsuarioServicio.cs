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
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _ModeloRepositorio;
        private readonly IMapper _Mapper;

        public UsuarioServicio (IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _ModeloRepositorio = modeloRepositorio;
            _Mapper = mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p=>p.Correo==modelo.Correo && p.Clave==modelo.Clave);
                var FromDbModelo= await Consulta.FirstOrDefaultAsync();

                if (FromDbModelo != null) return _Mapper.Map<SesionDTO>(FromDbModelo); else throw new TaskCanceledException("No se encontraron coincidencias");

                
            }catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var DbModelo = _Mapper.Map<Usuario>(modelo);
                var RspModelo = await _ModeloRepositorio.Crear(DbModelo);
                if (RspModelo.IdUsuario != 0) return _Mapper.Map<UsuarioDTO>(RspModelo); else throw new TaskCanceledException("No se puede crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdUsuario == modelo.IdUsuario);
                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if(FromDbModelo != null)
                {
                    FromDbModelo.NombreCompleto = modelo.NombreCompleto;
                    FromDbModelo.Correo = modelo.Correo;
                    FromDbModelo.Clave = modelo.Clave;
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
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdUsuario == id);
                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if(FromDbModelo != null )
                {
                    var Respuesta = await _ModeloRepositorio.ELiminar(FromDbModelo);
                    if (!Respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return Respuesta;

                }else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {

                var Consulta = _ModeloRepositorio.Consultar(p =>
                p.Rol == rol && string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));
                
                List<UsuarioDTO> lista = _Mapper.Map<List<UsuarioDTO>>(await Consulta.ToListAsync());   
                return lista;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Obtener(int id)
        {
            try
            {
                var Consulta = _ModeloRepositorio.Consultar(p => p.IdUsuario == id);

                var FromDbModelo = await Consulta.FirstOrDefaultAsync();

                if (FromDbModelo != null) return _Mapper.Map<UsuarioDTO>(FromDbModelo); else throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
