using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.COMMON.Entidades
{
    public class Empleado : Base 
    {
      public required string Nombre { get; set; }
      public required string Apellidos { get; set; } 
      public required string Area { get; set; }
    }
}
