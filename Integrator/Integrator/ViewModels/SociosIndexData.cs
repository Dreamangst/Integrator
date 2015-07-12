using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.ViewModels
{
    public class SociosIndexData
    {
        public IEnumerable<Integrator.Models.Socio> Socios { get; set; }
        public IEnumerable<Integrator.Models.Promociones.Promo> Promociones { get; set; }

    }
}