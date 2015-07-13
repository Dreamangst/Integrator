using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Ventas;
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Promociones
{
    public abstract class Promo
    {
        [Key]
        public int PromoID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        //[Column("FirstName")]
        public string nombre { get; set; }

        public virtual ICollection<Socio> Socios { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }

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