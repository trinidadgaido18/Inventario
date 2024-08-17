﻿using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BIZ
{
    public class ManejadorEmpleados : IManejadorEmpleados
    {
        readonly IRepositorio<Empleado> repositorio;
        public ManejadorEmpleados(IRepositorio<Empleado> repo) 
        {
            repositorio = repo;
        }

        public List<Empleado> Listar => repositorio.Read; 

        public bool Agregar(Empleado entidad)
        {
          return repositorio.Create(entidad); 
        }

        public Empleado BusacarPorId(string id)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Listar.Where(e => e.Id == id).SingleOrDefault();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool Eliminar(string id)
        {
          return repositorio.Delete(id);
        }

        public List<Empleado> EmpleadosPorArea(string area)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Empleado entidad)
        {
            return repositorio.UpDate(entidad);
        }
    }
}
