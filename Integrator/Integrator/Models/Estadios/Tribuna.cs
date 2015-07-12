using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace Integrator.Models.Estadios
{
    public class Tribuna
    {
        [Key]
        public long TribunaID { get; set; }

        public string nombre { get; set; }
        public decimal? costo { get; set; }
        public List<Sector> sectores { get; set; }

        public Tribuna()
        {

        }
        public Tribuna(string pNombre)
        {
            this.nombre = pNombre;
        }
        public void addSector(int pTotal)
        {
            if (this.sectores == null)
            {
                this.sectores = new List<Sector>();
            }
            this.sectores.Add(new Sector(pTotal));
        }
        public void addSector(int pTotal, string pNombre)
        {
            if (this.sectores == null)
            {
                this.sectores = new List<Sector>();
            }
            this.sectores.Add(new Sector(pTotal, pNombre));
        }
        public void addSector(Sector pSect)
        {
            if (this.sectores == null)
            {
                this.sectores = new List<Sector>();
            }
            this.sectores.Add(pSect);
        }
    }
}