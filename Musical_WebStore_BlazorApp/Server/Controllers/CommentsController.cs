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
using System.Security.Claims;
using AutoMapper.QueryableExtensions;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public CommentsController(MusicalShopIdentityDbContext ctx, UserManager<User> userManager, IMapper mapper)
        {
            this.ctx = ctx;
            _userManager = userManager;
            _mapper = mapper;
        }

        private Task<Comment[]> GetCommentsAsync() => ctx.Comments.ToArrayAsync();

        private async Task<CommentLimited[]> GetCommentsLimitedAsync()
        {
            var comments = await ctx.Comments
                .AsNoTracking()
                .Include(i => i.User)
                .Include(i => i.Instrument)
                .ProjectTo<CommentLimited>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
            
            return comments;
        }
        [HttpGet]
        public async Task<IEnumerable<CommentLimited>> Get()
        {
            var comments = await GetCommentsLimitedAsync();

            return comments;
        }
        [HttpPost]
        [Route("addcomment")]
        public async Task<IActionResult> LeaveCommentSample(LeaveCommentModel model)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Ok(new LeaveCommentResult() { Successful = false });
            }

            ctx.Comments.Add(
                new Comment()
                {
                    InstrumentId = model.InstrumentId,
                    Text = model.Text,
                    Date = DateTime.UtcNow,
                    User = user
                }
            );

            await ctx.SaveChangesAsync();

            return Ok(new LeaveCommentResult() { Successful = true });
        }

        [Route("deletecomment")]
        public async Task<IActionResult> DeleteComment(DeleteCommentModel model)
        {

            ctx.Comments.Remove(
                ctx.Comments.Single(c => c.Id == model.CommentId)
            );
            await ctx.SaveChangesAsync();
            return Ok(new DeleteCommentResult() { Successful = true });
        }
    }
}