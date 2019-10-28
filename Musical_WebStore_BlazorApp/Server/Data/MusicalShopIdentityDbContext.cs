using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Server.Data
{
    public class MusicalShopIdentityDbContext : IdentityDbContext<User>
    {
        public MusicalShopIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Instrument> Instruments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
