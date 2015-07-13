using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrator.Models.Estadios
{
    public class Localidades
    {
        [Key]
        public long LocalidadesID { get; set; }
        public List<Tribuna> tribunas { get; set;}

        public Localidades()
        {
            

        }
        public void setStandard()
        {
            

            Tribuna trib1 = new Tribuna("T1");
            trib1.addSector(4000, "24");
            trib1.addSector(8000, "1");
            trib1.addSector(4000, "3");

            Tribuna trib4 = new Tribuna("T4");
            trib4.addSector(1500, "4");
            trib4.addSector(9000, "6");
            trib4.addSector(5750, "9");
            trib4.addSector(5750, "10");

            Tribuna trib2 = new Tribuna("T2");
            trib2.addSector(7000, "12");
            trib2.addSector(12000, "13");
            trib2.addSector(12000, "14");
            trib2.addSector(9000, "15");

            Tribuna trib3 = new Tribuna("T3");
            trib3.addSector(5750, "17");
            trib3.addSector(5750, "18");
            trib3.addSector(9000, "20");
            trib3.addSector(1500, "23");

            this.tribunas = new List<Tribuna>();
            this.tribunas.Add(trib1);
            this.tribunas.Add(trib4);
            this.tribunas.Add(trib2);
            this.tribunas.Add(trib3);
        }

        public Tribuna getTribuna(string pStr){
            //Tribuna retTrib = new Tribuna();

            return this.tribunas.First(tr => tr.nombre == pStr);
        }

    }
}