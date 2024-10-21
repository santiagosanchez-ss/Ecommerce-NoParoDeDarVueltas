using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    internal class TarjetaDTO
    {
        [Required(ErrorMessage ="Ingrese el titular de la tarjeta")]
        public string? Titular {  get; set; }
        [Required(ErrorMessage = "Ingrese el numero de la tarjeta")]
        public string? Numero{  get; set; }
        [Required(ErrorMessage = "Ingrese la vigencia")]
        public string? Vigencia {  get; set; }
        [Required(ErrorMessage = "Ingrese CVV")]
        public string? CVV {  get; set; }
    }
}
