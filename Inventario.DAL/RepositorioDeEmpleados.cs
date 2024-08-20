using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.DAL
{
    public class RepositorioDeEmpleados : IRepositorio<Empleado>
    {
        private readonly string DBName = "Inventario.db";
        private readonly string TableName = "Empleados";
        public List<Empleado> Read
        {
            get
            {
                List<Empleado> datos = [];
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Empleado>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Create(Empleado entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using var db = new LiteDatabase(DBName);
                var coleccion = db.GetCollection<Empleado>(TableName);
                coleccion.Insert(entidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                using var db = new LiteDatabase(DBName);
                var coleccion = db.GetCollection<Empleado>(TableName);
                var empleado = coleccion.FindOne(e => e.Id.Equals(id));
                if (empleado != null)
                {
                    bool v = coleccion.Delete(empleado.Id);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        bool IRepositorio<Empleado>.UpDate(string Id, Empleado entidadModificada)
        {
            try
            {
                using var db = new LiteDatabase(DBName);
                var coleccion = db.GetCollection<Empleado>(TableName);
                coleccion.Insert(entidadModificada);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpDate(Empleado entidadModificada)
        {
            throw new NotImplementedException();
        }
    }

}


