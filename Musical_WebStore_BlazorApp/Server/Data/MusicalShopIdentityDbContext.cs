﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using System;
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
        public DbSet<CartItem> CartItems {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CartItem>().HasKey(item => new {item.InstrumentId, item.UserId});
            builder.Entity<CartItem>().HasOne(ci => ci.User).WithMany(u => u.CartItems).HasForeignKey(ci => ci.UserId);
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
        private static string[] GetName(string type)
        {
            string[] guitarTitles = new string[]{"Yamaha S1209", "Fender CD60", "Takamine EF360S-TT", "Taylor 314ce",
                "Blueridge BR-160", "Martin 16 Series D-16GT", "Yamaha A Series A3M", "Seagull S6 Original",
                "The Loar LH-204 Brownstone", "Yamaha APX600"};
            string[] pedalTitles = new string[]{"MXR Phase 90", "Boss DD-7 Digital", "Ibanez TS808 Tube Screamer", "Electro-Harmonix SOULFOOD",
                "Boss CH-1 Stereo", "MXR Dyna Comp Effects Pedal", "Dunlop The Original Crybaby", "Boss RC-3 Loop Station Pedal",
                "	Electro-Harmonix LPB-1", "Boss FV-500H"};
            string[] amplifierTitles = new string[]{ "Peavey 6505", "Vox AC4HW1", "EVH 5150III 50W", "Vox Custom AC15C2", 
                "Blackstar HT Stage 60 MKII", "Orange Crush Pro CR60C", "Boss Katana KTN-100", "Fender Champion 100",
                "AER Compact 60", "Roland Cube Street" };

            switch (type)
            {
                case "guitar":
                    return guitarTitles;
                case "pedal":
                    return pedalTitles;
                case "amplifier":
                    return amplifierTitles;
            }
            return null;
        }
        private static string[] GetDescription(string type)
        {
            string[] guitarDescriptions = new string[] 
            {
                "Vintage tone and style to spare with this high-end Takamine.", "A gorgeous premium all-solid-wood Taylor.",
                "Great looking dreadnaught body guitar from Bristol.", "Classic style with this solid-wood Martin.",
                "A mid-range performance-focused acoustic with a high-end feel.", "Beautiful style, quality and playability with this Seagull.",
                "A taste of vintage America with this stylish Chinese guitar.", "Affordable slimline Yamaha with upgraded performance.",
                "A proud representative from the Takamine family.", "FG800 shows what made Yamaha's FG series so legendary to begin with." 
            };
            string[] pedalDescriptions = new string[]
            {
                "Focused pedal that excels at distortion, overdrive and classic fuzz sounds.","British tube distortion with outstanding dynamic range.",
                "Fully analog distortion that brings an impressive range of tones and gain.","Unique features and great tones with an outstanding pedigree.",
                "More refined affordable dist box that brings great performance and limited versatility.","A faithful reproduction of the classic Tube Screamer sound.",
                "Another classic stompbox that brings impressive performance and abundant flexibility.","Very light distortion that caters to Rock, but brings high quality tone.",
                "Quintessential distortion pedal used both by legendary guitar players and the masses.","One of the best and only Klon Centaur clones on the market."
            };
            string[] amplifierDescriptions = new string[]
            {
                "One of the most legendary amps for the fans of heavier tone.","A high-end hand-wired tube amp with great style.",
                "A legendary tone monster designed by Eddie Van Halen.","A modern reimagining of the iconic AC15.",
                "Superb flexibility and power from this all-tube combo.","A stand-out combo that crushes stage performances.",
                "Flexible combo providing legendary Boss tone at an attractive price.","A classic Fender combo amp with great power.",
                "Huge tone and power from this high-end acoustic amp.","A solid dual-channel choice for street performers."
            };

            switch (type)
            {
                case "guitar":
                    return guitarDescriptions;
                case "pedal":
                    return pedalDescriptions;
                case "amplifier":
                    return amplifierDescriptions;
            }
            return null;
        }
        private static (int price,int quantity) GetRandomPrice()
        {
            int[] prices = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};
            int[] quantities = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random rnd = new Random();
            return (prices[rnd.Next(prices.Length)], quantities[rnd.Next(quantities.Length)]);
        }
        private static IEnumerable<Guitar> GetGuitars(int length, int offset)
        {

            string[] guitarTitles = GetName("guitar");
            string[] guitarDescription = GetDescription("guitar");

            int j = 1;
            for (int i = 0; i < length; i++,j++)
            {
                (int price, int quantity) priceQuantity = GetRandomPrice();
                yield return new Guitar
                {
                    Id = -(j + offset),
                    Title = guitarTitles[i],
                    Price = priceQuantity.price,
                    Quantity = priceQuantity.quantity,
                    Description = guitarDescription[i],
                    Image = $"images/Guitars/{j}.jpg"
                };
            }
        }

        private static IEnumerable<Amplifier> GetAmplifiers(int length, int offset)
        {
            string[] guitarTitles = GetName("amplifier");
            string[] guitarDescription = GetDescription("amplifier");

            int j = 1;
            for (int i = 0; i < length; i++, j++)
            {
                (int price, int quantity) priceQuantity = GetRandomPrice();
                yield return new Amplifier
                {
                    Id = -(j + offset),
                    Title = guitarTitles[i],
                    Price = priceQuantity.price,
                    Quantity = priceQuantity.quantity,
                    Description = guitarDescription[i],
                    Image = $"images/Amplifiers/{j}.jpg"
                };
            }
        }

        private static IEnumerable<Pedal> GetPedals(int length, int offset)
        {
            string[] guitarTitles = GetName("pedal");
            string[] guitarDescription = GetDescription("pedal");

            int j = 1;
            for (int i = 0; i < length; i++, j++)
            {
                (int price, int quantity) priceQuantity = GetRandomPrice();
                yield return new Pedal
                {
                    Id = -(j + offset),
                    Title = guitarTitles[i],
                    Price = priceQuantity.price,
                    Quantity = priceQuantity.quantity,
                    Description = guitarDescription[i],
                    Image = $"images/Pedals/{j}.jpg"
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
