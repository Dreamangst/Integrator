using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;
using Integrator.Models.Promociones;

namespace Integrator.Models
{
    public class Socio
    {
        [Key]
        public long SocioID { get; set; }
        public string nombre { get; set; }
        public int ci { get; set; }


        public virtual ICollection<Promo> promociones { get; set; }
    }
}