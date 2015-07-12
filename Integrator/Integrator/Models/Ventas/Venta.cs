using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Ventas
{
    public class Venta
    {
        [Key]
        public long ventaID { get; set; }
        public List<Item> items { get; set; }
        public Socio socio { get; set; }
        public Evento evento { get; set; }



    }
}