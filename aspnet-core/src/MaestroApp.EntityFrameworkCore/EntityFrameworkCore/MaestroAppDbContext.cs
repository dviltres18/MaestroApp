using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MaestroApp.Authorization.Roles;
using MaestroApp.Authorization.Users;
using MaestroApp.MultiTenancy;
using Abp.Localization;
using MaestroApp.Maestro.Container;
using MaestroApp.Maestro.State;
using MaestroApp.Maestro.Travel;
using MaestroApp.Maestro.TravelContainer;

namespace MaestroApp.EntityFrameworkCore
{
    public class MaestroAppDbContext : AbpZeroDbContext<Tenant, Role, User, MaestroAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Contenedor> Contenedores { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Viaje> Viajes { get; set; }

        public virtual DbSet<ViajeContenedor> ViajesContenedores { get; set; }


        public MaestroAppDbContext(DbContextOptions<MaestroAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
    }
}
