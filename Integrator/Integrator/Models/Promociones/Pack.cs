using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.Models.Promociones
{
    public class Pack
    {
        public ulong id { get; set; }
        public string nombre { get; set; }
        public string detalles { get; set; }
        public long stock{ get; set; }

    }
}