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

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly UserManager<User> _userManager;
        public CommentsController(MusicalShopIdentityDbContext ctx, UserManager<User> userManager)
        {
            this.ctx = ctx;
            _userManager = userManager;
        }

        private Task<Comment[]> GetCommentsAsync() => ctx.Comments.ToArrayAsync();
        [HttpGet]
        public async Task<IEnumerable<Comment>> Get()
        {
            var comments = await GetCommentsAsync();

            return comments;
        }
        [Route("/{userId}/{text}/{instrumentId}")]
        public async Task<IActionResult> LeaveComment(string userId, string text, int instrumentId)
        {
            ctx.Comments.Add(
                new Comment()
                {
                    AuthorId = userId,
                    Instrument = ctx.Instruments.Single(i => i.Id == instrumentId),
                    Text = text
                }
            );
            await ctx.SaveChangesAsync();
            return Ok();
        }

        [Route("samplecomment")]
        public async Task<IActionResult> LeaveCommentSample(CommentModel model)
        {
            ctx.Comments.Add(new Comment());
            // ctx.Comments.Add(
            //     new Comment()
            //     {
            //         AuthorId = _userManager.FindByEmailAsync("vladislavburayk00@gmail.com").Result.Id,
            //         Instrument = ctx.Instruments.Single(i => i.Id == -21),
            //         Text = "text"
            //     }
            // );
            await ctx.SaveChangesAsync();
            return Ok(new LeaveCommentResult(){Successful = true});
        }
    }
}