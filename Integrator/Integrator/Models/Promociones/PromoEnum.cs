using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;

namespace Integrator.Models.Promociones
{
    public enum PromoEnum
    {
        [Display(Name = "--> Seleccionar <-- ")]
        noPromo = 0,
        [Display(Name = "Promo orientada a nX1")]
        PromoNx1 = 1,

        [Display(Name = "Promocion orientada a porcentaje")]
        PromoPercen = 2,

        [Display(Name = "Promo orientada a un Pack")]
        PromoPack = 3
    }
    public static class PromoEnumExtensions
    {
        public static string ToString(this PromoEnum me)
        {
            switch (me)
            {
                case PromoEnum.noPromo:
                    return "noPromo";
                case PromoEnum.PromoNx1:
                    return "PromoNx1";
                case PromoEnum.PromoPercen:
                    return "PromoPercen";
                case PromoEnum.PromoPack:
                    return "PromoPack";
                default:
                    return null;
            }
        }
        public static int? ToInt(this PromoEnum me)
        {
            switch (me)
            {
                case PromoEnum.noPromo:
                    return 0;
                case PromoEnum.PromoNx1:
                    return 1;
                case PromoEnum.PromoPercen:
                    return 2;
                case PromoEnum.PromoPack:
                    return 3;
                default:
                    return null;
            }
        }

    }
}

