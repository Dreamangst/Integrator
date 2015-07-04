using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Ventas;

namespace Integrator.Models.Promociones
{
    public class PromoPercen : Promo
    {
        public decimal percen { get; set; }
       
        public override decimal getCost(List<Item> pItems)
        {
            decimal sum = 0;
            foreach (Item it in pItems)
            {
                sum += it.sect.costo * it.cant;
            }
            return sum * (1 + percen / 100);
        }

    }
}