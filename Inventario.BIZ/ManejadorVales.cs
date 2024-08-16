using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BIZ
{
    public class ManejadorVales : IManejadorVales
    {
        readonly IRepositorio<Vale> repositorio;
        public ManejadorVales(IRepositorio<Vale> repositorio)
        {
            this.repositorio = repositorio; 
        }
        public List<Vale> Listar => repositorio.Read; 

        public bool Agregar(Vale entidad)
        {
            return repositorio.Create(entidad); 
        }

        public Vale BusacarPorId(string id)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Listar.Where(e => e.Id == id).SingleOrDefault(); 
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool Eliminar(string id)
        {
           return repositorio.Delete(id);
        }

        public bool Modificar(Vale entidad)
        {
           return  repositorio.UpDate(entidad);
        }
    }
}
