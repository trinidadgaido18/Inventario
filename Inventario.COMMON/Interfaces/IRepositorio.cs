using Inventario.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Interfaces
{
    public interface IRepositorio<T> where T : Base 
    {
        bool Create(T entidad);
        List<T> Read {  get; } 
        bool UpDate(string Id, T entidadModificada ); 
        bool Delete(T entidad);

    }
}
