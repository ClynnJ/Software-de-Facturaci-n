using Facturacion.COMMON.Entidades;
using Facturacion.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.DAL
{
    class RepositorioDeClientes : IRepositorio<Cliente>
    {
        public List<Cliente> Read => throw new NotImplementedException();

        public bool Create(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Cliente entidadOrigina, Cliente entidadModificada)
        {
            throw new NotImplementedException();
        }
    }
}
