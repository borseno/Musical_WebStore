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
            for(int i = 1; i <= 25; i++)
            {
                yield return new Instrument(i, $"test{i}", i, i, $"test desc{i}");
            }
        }
        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return GetInstruments().ToList();
        }
    }
}

