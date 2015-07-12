using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Estadios
{
    public class Sector
    {
        [Key]
        public long sectorID { get; set; }
        string nombre { get; set; }
        public decimal costo { get; set; }
        public int total { get; set; }
        public int inhabilitado { get; set; }
        public int disponible { get; set; }

        public Sector()
        {

        }
        public Sector(int pTotal)
        {
            this.total = pTotal;
        }
        public Sector(int pTotal, string pNombre)
        {
            this.total = pTotal;
            this.nombre = pNombre;
        }
    }
}