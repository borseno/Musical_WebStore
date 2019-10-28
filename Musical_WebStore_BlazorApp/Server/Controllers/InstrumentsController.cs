using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musical_WebStore_BlazorApp.Shared;
using Musical_WebStore_BlazorApp.Client;


namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentsController : Controller
    {
        private IEnumerable<Instrument> GetInstruments()
        {
                for (int i = 1; i <= 10; i++)
                {
                    yield return new Guitar(i, $"guitarTest{i}", i, i, $"test desc{i}", "test.jpg");
                }
                for (int i = 1; i <= 10; i++)
                {
                    yield return new Amplifier(i, $"amplifierTest{i}", i, i, $"test desc{i}", "test.jpg");
                }
                for (int i = 1; i <= 10; i++)
                {
                    yield return new Pedal(i, $"pedalTest{i}", i, i, $"test desc{i}", "test.jpg");
                }
        }
        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return GetInstruments().ToList();
        }
    }
}

