using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.Models.Ventas
{
    public class Venta
    {
        public ulong id { get; set; }
        public List<Item> items { get; set; }
        public Socio socio { get; set; }
        public Evento evento { get; set; }



    }
}