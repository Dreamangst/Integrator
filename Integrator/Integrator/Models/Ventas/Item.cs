using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//


namespace Integrator.Models.Ventas
{
    public class Item
    {
        public ulong id { get; set; }
        public int cant { get; set; }
        public Integrator.Models.Estadio.Sector sect { get; set; }
        
    }
}