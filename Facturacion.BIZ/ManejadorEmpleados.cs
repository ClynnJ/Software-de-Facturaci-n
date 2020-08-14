using Facturacion.COMMON.Entidades;
using Facturacion.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturacion.BIZ
{
    public class ManejadorEmpleados:IManejadorEmpleados
    {
        IRepositorio<Empleado> repositorio;
        public ManejadorEmpleados(IRepositorio<Empleado> repo)
        {
            repositorio = repo;
        }

        public List<Empleado> Listar => repositorio.Read;

        public bool Agregar(Empleado entidad)
        {
            return repositorio.Create(entidad);
        }

        public Empleado BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Empleado entidad)
        {
            return repositorio.Edit(entidad);
        }
    }
}
