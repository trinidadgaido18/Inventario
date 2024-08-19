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
    public class RepositorioDeMaterial : IRepositorio<Material>
    {
        private readonly string DBName = "Inventario,db";
        private readonly string TableName = " Materiales";

        public List<Material> Read
        {
            get
            {
                List<Material> datos = [];
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Material>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Create(Material entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using var db = new LiteDatabase(DBName);
                var coleccion = db.GetCollection<Material>(TableName);
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
                var coleccion = db.GetCollection<Material>(TableName);
                var empleado = coleccion.FindOne(e => e.Id.Equals(id));
                if (empleado != null)
                {
                    coleccion.Delete(empleado.Id);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpDate(Material entidadModificada)
        {
            try
            {
                using var db = new LiteDatabase(DBName);
                var coleccion = db.GetCollection<Material>(TableName);
                coleccion.Insert(entidadModificada);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
