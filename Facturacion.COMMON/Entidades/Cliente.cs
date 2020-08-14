using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.COMMON.Entidades
{
    public class Cliente:Base
    {
        public string Nombre { get; set;  }
        public int Cedula { get; set; }
        public int CantidadMegas { get; set; }
        public int Tarifa { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public string NumeroTelefono { get; set; }
        public bool Pagado { get; set; }
    }
}
