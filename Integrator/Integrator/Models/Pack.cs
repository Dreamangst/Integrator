using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Promociones
{
    public class Pack
    {
        [Key]
        public long PackID { get; set; }

        [Required]
        public string nombre { get; set; }

        [DataType(DataType.MultilineText)]
        public string detalles { get; set; }

        [Required]
        public long stock{ get; set; }


        public virtual ICollection<PromoPack> promopacks { get; set; }

        public override string ToString()
        {
            return "{Nombre: "+nombre +". Stock: "+ stock+"}";
        }
    }
}