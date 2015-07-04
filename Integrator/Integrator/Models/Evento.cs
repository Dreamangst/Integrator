using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Estadio;
using Integrator.Models.Promociones;

namespace Integrator.Models
{
    public class Evento
    {
        public ulong id { get; set; }
        public DateTime fechahora { get; set; }
        public List<Tribuna> localidades { get; set; }
        public List<Promo> promociones { get; set; }
    }
}