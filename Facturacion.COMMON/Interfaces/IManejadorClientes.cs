using Facturacion.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.COMMON.Interfaces
{
    public interface IManejadorClientes:IManejadorGenerico<Cliente>
    {
        List<Cliente> ClientesPagos();
        Cliente ClientesPorCedula(string cedula);
    }
}
