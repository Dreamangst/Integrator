using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//-------
using Integrator.Models.Promociones;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Integrator.Models;

namespace Integrator.DAL
{
    public class IntegratorContext : DbContext
    {
        public IntegratorContext()
            : base("IntegratorEntities")
        {
            //Database.SetInitializer<IntegratorContext>(new CreateDatabaseIfNotExists<IntegratorContext>());
            //Database.SetInitializer<IntegratorContext>(new Integrator.DAL.IntegratorInitializer());
            
            //Database.SetInitializer<IntegratorContext>(new DropCreateDatabaseIfModelChanges<IntegratorContext>());
            Database.SetInitializer<IntegratorContext>(new IntegratorInitializer());
            //Database.SetInitializer<IntegratorContext>(new SchoolDBInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Promo>()
                .HasMany(p => p.Socios).WithMany(s => s.promociones)
                .Map(t => t.MapLeftKey("PromoID")
                    .MapRightKey("SocioID")
                    .ToTable("SocioPromo"));
            /*modelBuilder.Entity<Pack>().MapSingleType().ToTable("dbo.Packs");
              modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("display_name"); 
            }*/
        }
        static IntegratorContext()
        {
            Database.SetInitializer<IntegratorContext>(new IntegratorInitializer());

        }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        

        public DbSet<Promo> Promos { get; set; }
            public DbSet<PromoPercen> PromoPercens { get; set; }
            public DbSet<PromoNx1> PromoNx1s { get; set; }
            public DbSet<PromoPack> PromoPacks { get; set; }
                public DbSet<Pack> Packs { get; set; }
    }
}