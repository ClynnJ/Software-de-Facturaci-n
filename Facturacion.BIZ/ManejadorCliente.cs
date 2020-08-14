using Facturacion.COMMON.Entidades;
using Facturacion.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturacion.BIZ
{
    public class ManejadorCliente : IManejadorClientes
    {
        IRepositorio<Cliente> repositorio;

        public ManejadorCliente(IRepositorio<Cliente> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Cliente> Listar => repositorio.Read;

        public bool Agregar(Cliente entidad)
        {
            return repositorio.Create(entidad);
        }

        public Cliente BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<Cliente> ClientesPagos()
        {
            return Listar.Where(e => e.Pagado == true).ToList();
        }

        public Cliente ClientesPorCedula(int cedula)
        {
            return Listar.Where(e => e.Cedula == cedula).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Cliente entidad)
        {
            return repositorio.Edit(entidad);
        }
    }
}
