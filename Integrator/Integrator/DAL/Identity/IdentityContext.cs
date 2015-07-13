using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Integrator.Models.ApplicationUser;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Integrator.Models;
using Integrator.Models.Promociones;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace Integrator.DAL.Identity
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("IntegratorIdentities")
        {
            
            
        }

        static IdentityContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<IdentityContext>(new IdentityInitializer());
            

        }
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Promo>()
                .HasMany(p => p.Socios).WithMany(s => s.promociones)
                .Map(t => t.MapLeftKey("PromoID")
                    .MapRightKey("SocioID")
                    .ToTable("SocioPromo"));*/
            /*modelBuilder.Entity<Pack>().MapSingleType().ToTable("dbo.Packs");
              modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("display_name"); 
            }
        }*/

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
        /*
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Evento> Eventos { get; set; }


        public DbSet<Promo> Promos { get; set; }
        public DbSet<PromoPercen> PromoPercens { get; set; }
        public DbSet<PromoNx1> PromoNx1s { get; set; }
        public DbSet<PromoPack> PromoPacks { get; set; }
        public DbSet<Pack> Packs { get; set; }*/

    }
}