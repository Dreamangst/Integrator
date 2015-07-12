using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrator.ViewModels
{
    public class PromoPackViewModel
    {

        public int PromoID { get; set; }

        [Required]
        public long? refPackID { get; set; }
        [Required]
        public string nombre { get; set; }





    }
}