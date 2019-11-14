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
        private static IEnumerable<Guitar> GetGuitars(int length, int offset)
        {
            for (int i = 1; i <= length; i++)
            {
                yield return new Guitar
                {
                    Id = -(i + offset),
                    Title = $"guitarTest{i}",
                    Price = i,
                    Quantity = i,
                    Description = $"test desc{i}",
                    Image = "test.jpg"
                };
            }
        }

        private static IEnumerable<Amplifier> GetAmplifiers(int length, int offset)
        {
            for (int i = 1; i <= length; i++)
            {
                yield return new Amplifier
                {
                    Id = -(i + offset),
                    Title = $"amplifierTest{i}",
                    Price = i,
                    Quantity = i,
                    Description = $"test desc{i}",
                    Image = "test.jpg"
                };
            }
        }

        private static IEnumerable<Pedal> GetPedals(int length, int offset)
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new Pedal
                {
                    Id = -(i + offset),
                    Title = $"pedalTest{i}",
                    Price = i,
                    Quantity = i,
                    Description = $"test desc{i}",
                    Image = "test.jpg"
                };
            }
        }

        public static void Seed(this ModelBuilder blder)
        {
            var @base = 10;

            var pedals = GetPedals(@base, @base * 0).ToArray();
            var amps = GetAmplifiers(@base, @base * 1).ToArray();
            var guitars = GetGuitars(@base, @base * 2).ToArray();

            blder.Entity<Pedal>()
                .HasData(pedals);

            blder.Entity<Guitar>()
                .HasData(guitars);

            blder.Entity<Amplifier>()
                .HasData(amps);

        }
    }
}
