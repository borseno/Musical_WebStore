using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Musical_WebStore_BlazorApp.Shared;
using Musical_WebStore_BlazorApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public CartController(MusicalShopIdentityDbContext ctx, UserManager<User> userManager, IMapper mapper)
        {
            this.ctx = ctx;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Instrument[]> Get()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return await ctx.CartItems.Where(ci => ci.UserId == user.Id).Select(ci => ci.Instrument).ToArrayAsync();
        }
        [Route("purchase")]
        public async Task<Result> MakePurchase(PurchaseModel model)
        {
            var isValid = true;
            // ???
            // PROFIT!
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var torem = ctx.CartItems.Where(ci => ci.UserId == user.Id);
            ctx.CartItems.RemoveRange(torem);
            await ctx.SaveChangesAsync();
            return new Result() { Successful = true };
        }
        [Route("addtocart")]
        public async Task<Result> AddItemToCart(AddItemToCartModel model)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var cartItem = _mapper.Map<CartItem>(model);
            cartItem.UserId = user.Id;
            ctx.CartItems.Add(cartItem);
            await ctx.SaveChangesAsync();
            foreach(var t in ctx.CartItems)
                Console.WriteLine($"{t.UserId} - {t.InstrumentId}");
            return new Result() {Successful = true};
        }
        [Route("deletefromcart")]
        public async Task<Result> DeleteItemFromCart(DeleteItemFromCartModel model)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var item = ctx.CartItems.Single(ci => ci.UserId == user.Id && ci.InstrumentId == model.InstrumentId );
            ctx.CartItems.Remove(item);
            await ctx.SaveChangesAsync();
            return new Result() {Successful = true};
        }

    }
}