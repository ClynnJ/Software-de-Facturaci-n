using Facturacion.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Create(T entidad);
        bool Edit(string id, T entidadModificada);
        bool Delete(T entidad);
        List<T> Read { get; }
    }
}
