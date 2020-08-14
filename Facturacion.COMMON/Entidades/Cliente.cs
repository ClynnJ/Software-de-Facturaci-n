using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.COMMON.Entidades
{
    public class Cliente:Base
    {
        public string Nombre { get; set;  }
        public string PlanDeServicio { get; set; }
        public int Tarifa { get; set; }
        public string DireccionMAC { get; set; }
        public bool Pagado { get; set; }
    }
}
