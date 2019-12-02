using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musical_WebStore_BlazorApp.Shared;
using Musical_WebStore_BlazorApp.Client;
using Musical_WebStore_BlazorApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarsController : Controller
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly UserManager<User> _userManager;
        private readonly IMapper mapper;

        public StarsController(MusicalShopIdentityDbContext ctx, UserManager<User> userManager, IMapper mapper)
        {
            this.ctx = ctx;
            _userManager = userManager;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<StarDTO>> Get()
        {
            var stars = await ctx.Stars
                .AsNoTracking()
                .ProjectTo<StarDTO>(mapper.ConfigurationProvider)
                .ToArrayAsync();
            
            return stars;
        }

        [Route("addstar")]
        public async Task<IActionResult> LeaveStar(StarModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.AuthorId);
            var str = ctx.Stars.SingleOrDefault(s => s.AuthorId == user.Id && s.InstrumentId == model.InstrumentId);
            if (str != null)
            {
                str.Mark = model.Mark;
            }
            else
            {
                ctx.Stars.Add(
                    new Star()
                    {
                        AuthorId = user.Id,
                        InstrumentId = model.InstrumentId,
                        Mark = model.Mark
                    }
                );
            }
            await ctx.SaveChangesAsync();
            return Ok(new StarResult() { Successful = true });
        }

        [Route("deletestar")]
        public async Task<IActionResult> DeleteStar(DeleteStarModel model)
        {
            // get star info

            var star = await ctx.Stars.FindAsync(new { model.InstrumentId, model.AuthorId });

            // get current user

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            // authorize user

            if (currentUser == null || currentUser.Id != model.AuthorId)
            {
                return Ok(new DeleteStarResult()
                {
                    Successful = false,
                    Error = "you're not authorized to delete this star"
                });
            }

            // do the job if authorized

            ctx.Stars.Remove(star);

            await ctx.SaveChangesAsync();

            return Ok(new DeleteStarResult() { Successful = true });
        }
    }
}