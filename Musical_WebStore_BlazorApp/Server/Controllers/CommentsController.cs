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
using AutoMapper;

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
        [HttpGet]
        public async Task<IEnumerable<Comment>> Get()
        {
            var comments = await GetCommentsAsync();

            return comments;
        }

        [Route("addcomment")]
        public async Task<IActionResult> LeaveCommentSample(CommentModel model)
        {            
            var user = await _userManager.FindByEmailAsync(model.AuthorId);
            var userLimited = _mapper.Map<UserLimited>(user);
            ctx.Comments.Add(
                new Comment()
                {
                    InstrumentId = model.InstrumentId,
                    Text = model.Text,
                    Date = DateTime.Now,
                    User = userLimited
                }
            );
            ctx.SaveChangesAsync();
            return Ok(new LeaveCommentResult(){Successful = true});
        }

        [Route("deletecomment")]
        public async Task<IActionResult> DeleteComment(DeleteCommentModel model)
        {            
            
            ctx.Comments.Remove(
                ctx.Comments.Single(c => c.Id == model.CommentId)
            );
            await ctx.SaveChangesAsync();
            return Ok(new DeleteCommentResult(){Successful = true});
        }
    }
}