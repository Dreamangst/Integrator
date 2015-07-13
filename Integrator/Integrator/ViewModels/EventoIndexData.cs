using Integrator.Models.Estadios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.ViewModels
{
    public class EventoIndexData
    {
        public Localidades localidades { get; set; }
        public IEnumerable<Integrator.Models.Promociones.Promo> Promociones { get; set; }

    }
}