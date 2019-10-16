using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musical_WebStore_BlazorApp.Shared;


namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentsController : Controller
    {
        private IEnumerable<Instrument> GetInstruments()
        {
            yield return new Instrument(1, "test0", 3, 3, "test desc");
            yield return new Instrument(2, "test1", 5, 5, "test desc");
            yield return new Instrument(3, "test2", 7, 7, "test desc");
        }
        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return GetInstruments().ToList();
        }
    }
}

