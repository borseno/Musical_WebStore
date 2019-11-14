using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Musical_WebStore_BlazorApp.Server.Data
{
    public class MusicalShopIdentityDbContext : IdentityDbContext<User>
    {
        public MusicalShopIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Comment> Comments {get;set;}
        public DbSet<Star> Stars {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Guitar>()
                .HasBaseType<Instrument>();

            builder.Entity<Pedal>()
                .HasBaseType<Instrument>();

            builder.Entity<Amplifier>()
                .HasBaseType<Instrument>();

            builder.Entity<Instrument>()
                .HasDiscriminator<string>("TypeName")
            .HasValue<Instrument>(nameof(Instrument))
            .HasValue<Amplifier>(nameof(Amplifier))
            .HasValue<Guitar>(nameof(Guitar))
            .HasValue<Pedal>(nameof(Pedal))
            ;

            builder.Seed();

            base.OnModelCreating(builder);
        }
    }

    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder blder)
        {

        }
    }
}
