using Ecommerce.DTO;
using Ecommerce.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _UsuarioServicio;

        public UsuarioController(IUsuarioServicio UsuarioServicio)
        {
            _UsuarioServicio = UsuarioServicio;
        }
        //METODOS GET
        
        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Lista(rol, buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

       
        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        //METODOS POST
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]UsuarioDTO modelo)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO modelo)
        {
            var response = new ResponseDTO<SesionDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Autorizacion(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        //METODOS PUT
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        //METODO DELETE
        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

    }
}
