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
        public DateTime fechahora { get; set; }

        [Required]
        public List<Tribuna> tribunas { get; set; }
        
        [Required]
        public List<Promo> promociones { get; set; }

        
    }
}