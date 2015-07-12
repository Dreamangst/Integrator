using Integrator.Models.Promociones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.ViewModels
{
    public class PromoPackIndexData
    {
        public IEnumerable<PromoPack> PromoPacks { get; set; }
        public Pack Pack { get; set; }



    }
}