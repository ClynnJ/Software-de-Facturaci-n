using Facturacion.COMMON.Entidades;
using Facturacion.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturacion.DAL
{
    class RepositorioDeClientes : IRepositorio<Cliente>
    {

        private string DBName = "Facturacion.db";
        private string TableName = "Clientes";

        public List<Cliente> Read{

            get 
            {
                List<Cliente> datos = new List<Cliente>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Cliente>(TableName).FindAll().ToList();
                }

                return datos;
            }

        }

        public bool Create(Cliente entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
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
                using(var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
                    coleccion.Delete(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Cliente entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
                    coleccion.Update(entidadModificada);
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
