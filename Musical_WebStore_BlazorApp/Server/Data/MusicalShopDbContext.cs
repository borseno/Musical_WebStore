using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Server.Data
{
    public class MusicalShopIdentityDbContext : IdentityDbContext
    {
        public MusicalShopIdentityDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
