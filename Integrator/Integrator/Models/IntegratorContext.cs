using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Integrator.Models
{
    public class IntegratorContext : DbContext
    {
        public DbSet<Promo> Promos { get; set; }

    }
}