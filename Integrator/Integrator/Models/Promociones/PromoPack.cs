using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Ventas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Promociones
{
    [Table("PromoPacks")]
    public class PromoPack : Promo
    {
        [Required]
        public long PackID { get; set; }

        
        public virtual Pack pack { get; set; }
        //[Required]
        //public virtual long? refPackID { get; set; }

        /*
        public PromoPercen percen { get; set; }
        public long percenId { get; set; }

        public PromoNx1 nx1 { get; set; }
        public long nx1Id { get; set; }
        */
        public override decimal getCost(List<Item> pItems)
        {
            decimal sum = 0;
            //sum = this.nx1.getCost(pItems);
           // sum = sum * (1 + percen.percen / 100); //Por decir que tambien pede tener porecntaje de descuento
            return sum;
        }
    }
}