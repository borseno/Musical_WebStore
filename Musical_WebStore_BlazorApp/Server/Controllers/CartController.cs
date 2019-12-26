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
        public async Task<CartItemModel[]> Get()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return await ctx.CartItems
                .Include(i => i.User)
                .Include(i => i.Instrument)
                .Where(ci => ci.UserId == user.Id)
                .Select(ci => _mapper.Map<CartItemModel>(ci))
                .ToArrayAsync();
        }
        [Route("purchase")]
        public async Task<Result> MakePurchase(PurchaseModel model)
        {
            var isValid = true;
            // ???
            // PROFIT!
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var torem = ctx.CartItems.Where(ci => ci.UserId == user.Id);
            var order = new Order() { UserId = user.Id, StatusId = (int)OrderStatuses.InConfirmation, Date = DateTime.Now, LocationId = int.Parse(model.LocationId) };
            ctx.Orders.Add(order);
            await ctx.SaveChangesAsync();
            foreach(var ci in torem)
            {
                ctx.ItemOrders.Add(new ItemOrder() {OrderId = order.Id, InstrumentId = ci.InstrumentId, Num = ci.Num });
            }
            ctx.CartItems.RemoveRange(torem); 
            await ctx.SaveChangesAsync();
            return new Result() { Successful = true };
        }

        [Route("getorders")]
        public async Task<OrderViewModel[]> GetOrders()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return await ctx.Orders
                .Include(i => i.Items)
                .ThenInclude(i => i.Instrument)
                .Include(i => i.Location)
                .Where(o => o.UserId == user.Id)
                .Select(o => _mapper.Map<OrderViewModel>(o))
                .ToArrayAsync();
        }

        [Route("addtocart")]
        public async Task<Result> AddItemToCart(AddItemToCartModel model)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var cartItem = _mapper.Map<CartItem>(model);
            cartItem.UserId = user.Id;
            var x = ctx.CartItems.Where(ci => ci.UserId == user.Id && ci.InstrumentId == model.InstrumentId);
            if(x.Count() == 0)
            {
                cartItem.Num = int.Parse(model.Num);
                ctx.CartItems.Add(cartItem);
            }
            else
            {
                x.First().Num += int.Parse(model.Num);
            }
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