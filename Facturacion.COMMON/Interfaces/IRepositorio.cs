using Facturacion.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Create(T entidad);
        bool Edit(T entidadModificada);
        bool Delete(string id);
        List<T> Read { get; }
    }
}
