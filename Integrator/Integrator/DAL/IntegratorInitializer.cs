using Integrator.Models;
using Integrator.Models.Promociones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrator.DAL
{
    //public class IntegratorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<IntegratorContext>
    public class IntegratorInitializer : System.Data.Entity.DropCreateDatabaseAlways<IntegratorContext>
    {
        protected override void Seed(IntegratorContext pContext)
        {
            var packs = new List<Pack>
            {
                new Pack{nombre="Merienda 1", detalles="Patafrola con colet", stock=long.Parse("90000")},
                new Pack{nombre="Chori", detalles="Choripan y cerveza (lata 500ml)", stock=long.Parse("120000")},
                new Pack{nombre="Chori VIP", detalles="Choripan con salsas y cerveza (lata 500ml)", stock=long.Parse("600000")}
            };
            packs.ForEach(p => pContext.Packs.Add(p));
            pContext.SaveChanges();

            var promoPacks = new List<PromoPack>
            {
                new PromoPack{nombre="Socios",PackID=pContext.Packs.Where(b => b.nombre == "Chori").FirstOrDefault().PackID},
                new PromoPack{nombre="Socios VIP",PackID=pContext.Packs.Where(b => b.nombre == "Chori VIP").FirstOrDefault().PackID},
            };
            promoPacks.ForEach(p => pContext.PromoPacks.Add(p));
            pContext.SaveChanges();

            var promoPercens = new List<PromoPercen>
            {
                new PromoPercen{nombre="Socios de 'Quedate' 5%", percen=5},
                new PromoPercen{nombre="Socios de 'Quedate' 10%", percen=10},
                new PromoPercen{nombre="Tarjeta Joven", percen=15},
                new PromoPercen{nombre="Barrabrava", percen=99},
                new PromoPercen{nombre="Promo Urutallica", percen=50}
            };
            promoPercens.ForEach(p => pContext.PromoPercens.Add(p));
            pContext.SaveChanges();

            var promoNx1s = new List<PromoNx1>
            {
                new PromoNx1{nombre="Socios de 'Quedate' 2x1", qtty=2},
                new PromoNx1{nombre="Socios de 'Quedate' 3x1", qtty=3},
                new PromoNx1{nombre="Escolares", qtty=45},
            };
            promoNx1s.ForEach(p => pContext.PromoNx1s.Add(p));
            pContext.SaveChanges();

            List<Promo> promosExampl0 = new List<Promo>();
            promosExampl0.Add(pContext.Promos.Where(b => b.nombre == "Socios").FirstOrDefault());

            List<Promo> promosExampl1 = new List<Promo>();
            promosExampl1.Add(pContext.Promos.Where(b => b.nombre == "Barrabrava").FirstOrDefault());
            promosExampl1.Add(pContext.Promos.Where(b => b.nombre == "Socios").FirstOrDefault());

            List<Promo> promosExampl2 = new List<Promo>();
            promosExampl2.Add(pContext.Promos.Where(b => b.nombre == "Escolares").FirstOrDefault());
            promosExampl2.Add(pContext.Promos.Where(b => b.nombre == "Tarjeta Joven").FirstOrDefault());
            promosExampl2.Add(pContext.Promos.Where(b => b.nombre == "Barrabrava").FirstOrDefault());

            List<Promo> promosExampl3 = new List<Promo>();
            promosExampl3.Add(pContext.Promos.Where(b => b.nombre == "Tarjeta Joven").FirstOrDefault());

            var socios = new List<Socio>
            {
                new Socio{nombre="", ci=12345670, promociones=promosExampl0},
                new Socio{nombre="", ci=12345671, promociones=promosExampl1},
                new Socio{nombre="", ci=12345672, promociones=promosExampl2},
                new Socio{nombre="", ci=12345673, promociones=promosExampl3},
            };
            socios.ForEach(s => pContext.Socios.Add(s));
            pContext.SaveChanges();
            
            




        }
    }











    
}