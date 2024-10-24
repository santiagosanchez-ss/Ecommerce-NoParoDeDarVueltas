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
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardServicio _DashboardServicio;
        public DashboardController(IDashboardServicio DashboardServicio)
        {
            _DashboardServicio = DashboardServicio;
        }



        //METODOS GET
        [HttpGet("Resumen")]
        public  IActionResult Resumen()
        {
            var response = new ResponseDTO<DashBoardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = _DashboardServicio.Resumen();
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
