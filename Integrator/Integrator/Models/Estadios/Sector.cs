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
        public string nombre { get; set; }
        public decimal costo { get; set; }
        public int total { get; set; } //Total de asientos

        public bool habilitado { get; set; } //Habilitacion del sector
        public int inhabilitado { get; set; } //Asientos inhabilitados
        public int disponible { get; set; } //Asientos disponibles

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
            this.habilitado = true;
            this.disponible = pTotal;
        }
    }
}