using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Ventas;

namespace Integrator.Models.Promociones
{
    public class PromoPack : Promo
    {
        public PromoPercen percen { get; set; }
        public PromoNx1 qtty { get; set; }

        public override decimal getCost(List<Item> pItems)
        {
            decimal sum = 0;
            sum = this.qtty.getCost(pItems);
            sum = sum * (1 + percen.percen / 100); //Por decir que tambien pede tener porecntaje de descuento
            return sum;
        }
    }
}