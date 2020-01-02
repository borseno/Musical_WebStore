using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musical_WebStore_BlazorApp.Server.Data;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using Musical_WebStore_BlazorApp.Shared.DTOs;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ITestingService service;

        public TestingController(UserManager<User> userManager, ITestingService service)
        {
            this.userManager = userManager;
            this.service = service;
        }

        [Route("{id}")]
        [Authorize("")]
        [HttpGet]
        public async Task<IActionResult> GetInfoAsync(int id)
        {
            var testingInfoTask = service.GetTestingInfo(id);
            var testingInfo = await testingInfoTask;
            var userTask = userManager.FindByEmailAsync(User.Identity.Name);
            var isAdmin = User.IsInRole("Admin");

            await Task.WhenAll(testingInfoTask, userTask);

            if (isAdmin || userTask.Result.Id == testingInfoTask.Result.UserId)
            {
                return Ok(testingInfoTask.Result);
            }
            else
            {
                return Forbid("You aren't an admin nor the enrolee of the test");
            }
        }

        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ChangeState(IdDTO<int> id)
        {
            await service.ChangeStateAsync(id.Id);
            

            
            return Ok();
        }


        [Route("[action]/{currentUserOnly}")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Testings(bool currentUserOnly)
        {
            var currentUser = await userManager.FindByEmailAsync(User.Identity.Name);

            if (!currentUserOnly && !User.IsInRole("Admin"))
            {
                return Forbid("You can't get info about all testings if you're not an admin");
            }

            var testings = currentUserOnly ?
                await service.GetTestings(currentUser.Id) :
                await service.GetTestings();

            return Ok(testings);
        }
    }

    public class TestingService : ITestingService
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly IMapper mapper;
        private readonly IEmailSender sender;

        public TestingService(MusicalShopIdentityDbContext ctx, IMapper mapper, IEmailSender sender)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.sender = sender;
        }

        public Task<TestingDTO> GetTestingInfo(int id) => ctx.Testings
                .Where(i => i.Id == id)
                .ProjectTo<TestingDTO>(mapper.ConfigurationProvider)
                .FirstAsync();

        public async Task ChangeStateAsync(int id)
        {
            var test = await ctx.Testings
                .Include(i => i.User)
                .Include(i => i.Instrument)
                .FirstAsync(i => i.Id == id);

            test.IsConfirmed ^= true; // fancy way of inverting a bool

            string message;

            if (test.IsConfirmed)
            {
                message = 
                    $@"The testing #{test.Id} of instrument ${test.Instrument.Title} has been approved.
{Environment.NewLine}We are waiting for you at {test.DateTime.ToString("MM/dd/yyyy")}!";
            }
            else
            {
                message =
                    $@"Hello! FYI: The testing #{test.Id} of instrument ${test.Instrument.Title} has been cancelled. 
{Environment.NewLine}Maybe you should try another time.";
            }

            await sender.SendEmailAsync(test.User.Email,
                "Testing status", message);

            await ctx.SaveChangesAsync();
        }

        // todo: refactor this and not only this but the whole damn project...

        public async Task<IEnumerable<TestingDTO>> GetTestings(string userId) => await ctx.Testings
            .Where(i => i.UserId == userId)
            .ProjectTo<TestingDTO>(mapper.ConfigurationProvider)
            .ToArrayAsync();

        public async Task<IEnumerable<TestingDTO>> GetTestings() => await ctx.Testings
            .ProjectTo<TestingDTO>(mapper.ConfigurationProvider)
            .ToArrayAsync();
    }
}