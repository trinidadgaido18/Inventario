﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.COMMON.Entidades
{
    public class Material : Base
    {
        public required string Nombre { get; set; }
        public required string Categoria { get; set; }
        public int Description { get; set; }


    }
}
