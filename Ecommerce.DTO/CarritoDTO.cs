﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CarritoDTO
    {
        public ProductoDTO? Producto { get; set; }  

        public int Cantidad { get; set; }
        public decimal? PrecioCedente { get; set; }
        public decimal? Total{ get; set; }


    }
}