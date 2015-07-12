using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Ventas
{
    public class Item
    {
        [Key]
        public long itemID { get; set; }
        public int cant { get; set; }
        public Integrator.Models.Estadios.Sector sect { get; set; }
        
    }
}