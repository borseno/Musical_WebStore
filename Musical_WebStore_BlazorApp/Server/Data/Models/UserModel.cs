using Microsoft.AspNetCore.Identity;
using Musical_WebStore_BlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class User : IdentityUser
    {
        public virtual IEnumerable<CartItem> CartItems {get;set;}
    }
}
