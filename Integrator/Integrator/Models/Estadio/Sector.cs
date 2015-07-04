using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.Models.Estadio
{
    public class Sector : Tribuna
    {
        public decimal costo { get; set; }
        public int total { get; set; }
        public int inhabilitado { get; set; }
        public int disponible { get; set; }



    }
}