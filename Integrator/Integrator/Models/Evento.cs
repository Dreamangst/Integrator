using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Estadios;
using Integrator.Models.Promociones;
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models
{
    public class Evento
    {
        [Key]
        public long EventoID { get; set; }

        [Required]
        public string nombre { get; set; }
        [Required]
        public decimal precioGeneral { get; set; }

        [Required]
        public DateTime calendario { get; set; }
        //public virtual ICollection<DateTime> calendario { get; set; }

        
        public virtual ICollection<Tribuna> localidades { get; set; }

        
        
        public virtual ICollection<Promo> promociones { get; set; }


        
    }
}