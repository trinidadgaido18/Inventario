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
    public class RepositorioDeVales : IRepositorio<Vale>
    {
        private readonly string DBName = " Inventario.db";
        private readonly string TableName = " Vale";

        public List<Vale> Read
        {
            get
            {
                List<Vale> datos = new List<Vale>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Vale>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Create(Vale entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Vale>(TableName);
                    coleccion.Insert(entidad);
                }
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
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Vale>(TableName);
                    var empleado = coleccion.FindOne(e => e.Id.Equals(id));
                    if (empleado != null)
                    {
                        coleccion.Delete(empleado.Id);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpDate(Vale entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Vale>(TableName);
                    coleccion.Insert(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
