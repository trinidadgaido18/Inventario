using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.COMMON.Entidades
{
    public class Vale : Base 
    {
        public DateTime FechaHoraSolicitud {  get; set; } 
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaEntregaReal { get; set; }
        public required  List<Material> MaterialesPrestados { get; set; }  
        public required  Empleado Solicitante { get; set; } 
        public required Empleado EncargadoDeAlmacen { get; set; } 
    }
}
