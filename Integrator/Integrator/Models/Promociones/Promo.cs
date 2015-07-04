using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Ventas;

namespace Integrator.Models.Promociones
{
    public abstract class Promo
    {
        public ulong id { get; set; }
        public string nombre { get; set; }

        public virtual decimal getCost(List<Item> pItems)
        {
            decimal sum = 0;
            foreach (Item it in pItems)
            {
                sum += it.sect.costo * it.cant;
            }
            return sum;
        }












    }
}