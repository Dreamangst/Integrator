using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.Ventas;
namespace Integrator.Models.Promociones
{
    public class PromoNx1 : Promo
    {
        public int qtty { get; set; }

        /**
         **/
        public override decimal getCost(List<Item> pItems)
        {
            decimal sum = 0;
            int num = 0;

            foreach (Item it in pItems)
            {
                num = 0;
                num = it.cant / qtty;           //cant items / cant items de la promo
                num += it.cant % qtty;          //cantidad items % cantidad items promo
                sum += it.sect.costo * num;     //costo de los tickets = costo por el sector * cantidad a pagar
                                                //diferencia por sector, asi si eligen de sectores diferentes (con precios diferentes) el 2x1 no funciona
                                                //si eligen 4, 2 a 2, funciona el 2x1
            }
            return sum;
            /*
             *  nx1
	                int num = total/n
	                num += total mod n
                2x1
                    1: num = 1 / 2 -> num = 0
                    num += 1 mod 2 -> num = 1
                
	                2: num = 2 / 2 -> num = 1
	                num += 2 mod 2 -> num = 1

	                3: num = 3 / 2 -> num = 1
	                num += 3 mod 2 -> num = 2

	                7: num = 7 / 2 -> num = 3
	                num += 7 mod 2 -> num = 4
                3x1
                    1: num = 1 / 3 -> num = 0
                    num += 1 mod 3 -> num = 1
             
                    2: num = 2 / 3 -> num = 0
                    num += 2 mod 3 -> num = 2
                    
                    x mod y = z 
	                    [si] x < y
		                    [entonces] x = z
                    
             */
            
        }



    }
}