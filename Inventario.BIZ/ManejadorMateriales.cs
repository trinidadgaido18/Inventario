using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BIZ
{
    public class ManejadorMateriales(IRepositorio<Material> repositorio) : IManejadorMateriales
    {
        readonly IRepositorio<Material> repositorio = repositorio;

        public List<Material> Listar => repositorio.Read;

        public bool Agregar(Material entidad)
        {
            return repositorio.Create(entidad); 
        }

        public Material BusacarPorId(string id)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Listar.Where(e => e.Id == id).SingleOrDefault();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public List<Material> MaterialesCategoria(string categoria)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Listar.Where(e => e.Categoria == categoria).ToList();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool Modificar(Material entidad)
        {
            return repositorio.UpDate(entidad);
        }
    }
}
