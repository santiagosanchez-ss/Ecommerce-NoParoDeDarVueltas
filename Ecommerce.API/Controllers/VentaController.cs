using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DTO;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Implementation;
using Ecommerce.Model;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServicio _VentaServicio;

        public VentaController( IVentaServicio VentaServicio)
        {
            _VentaServicio = VentaServicio;
            
        }

        //METODOS POST
        [HttpPost("Registrar")]
        public async Task<IActionResult> Crear([FromBody] VentaDTO modelo)
        {
            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _VentaServicio.Registrar(modelo);
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
