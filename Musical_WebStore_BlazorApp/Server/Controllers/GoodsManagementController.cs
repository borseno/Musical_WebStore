using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musical_WebStore_BlazorApp.Server.Data;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize("Admin")]
    public class GoodsManagementController : ControllerBase
    {
        private readonly MusicalShopIdentityDbContext ctx;

        public GoodsManagementController(MusicalShopIdentityDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddGood(AddGoodModel model)
        {
            ;
            ;
            ;

            return Ok();
        }
    }
}