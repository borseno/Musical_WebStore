using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Musical_WebStore_BlazorApp.Server.Data;
using Models = Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.AspNetCore.Identity;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestEnrollingController : Controller
    {
        private readonly ITestEnrollingService service;
        private readonly UserManager<Models.User> manager;

        public TestEnrollingController(ITestEnrollingService service, UserManager<Models.User> manager)
        {
            this.service = service;
            this.manager = manager;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestEnrollingModel model)
            => Ok(await service.EnrollToTest(model,  await manager.FindByEmailAsync(User.Identity.Name)));
    }

    public class TestEnrollingService : ITestEnrollingService
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly IAdminNotificationService notificationService;

        public TestEnrollingService(MusicalShopIdentityDbContext ctx, IAdminNotificationService notificationService)
        {
            this.ctx = ctx;
            this.notificationService = notificationService;
        }

        public async Task<TestEnrollingResult> EnrollToTest(TestEnrollingModel model, Models.User user)
        {
            var notifyTask = NotifyAdmins(model, user);

            var testing = new Models.Testing
            {
                Comment = model.Comment,
                DateTime = model.DateTime,
                InstrumentId = model.GoodId,
                User = user,
                //UserId = user.Id
            };

            var res = await ctx.Testings.AddAsync(testing);

            await ctx.SaveChangesAsync();

            await notifyTask;

            return new TestEnrollingResult
            {
                IsSuccessful = true,
                TestId = res.Entity.Id
            };
        }

        private Task NotifyAdmins(TestEnrollingModel testing, Models.User user)
        {
            var nl = Environment.NewLine;

            var text =
                $"the user named {user.UserName} " +
                $"has left a ticket to test instrument #{testing.GoodId} " +
                $"at {testing.DateTime.ToString("MM/dd/yyyy")} (m/d/y){nl}" +
                $"Comment to the ticket: {testing.Comment}";

            return notificationService.Notify(text);
        }
    }

    public class TelegramBotNotificationService : IAdminNotificationService
    {
        private readonly TelegramBotClient client;
        private readonly long adminGroupId;

        public TelegramBotNotificationService(TelegramBotClient client, long adminGroupId)
        {
            this.client = client;
            this.adminGroupId = adminGroupId;
        }

        public Task Notify(string info)
            => client.SendTextMessageAsync(adminGroupId, info);
    }
}
