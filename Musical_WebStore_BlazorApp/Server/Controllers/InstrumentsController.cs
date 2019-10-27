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
                yield return new Guitar
                {
                    Id = i,
                    Title = $"guitarTest{i}",
                    Price = i,
                    Quantity = i,
                    Description = $"test desc{i}",
                    Image = "test.jpg"
                };
            }
            for (int i = 1; i <= 10; i++)
            {
                yield return new Amplifier
                {
                    Id = i,
                    Title = $"guitarTest{i}",
                    Price = i,
                    Quantity = i,
                    Description = $"test desc{i}",
                    Image = "test.jpg"
                };
            }
            for (int i = 1; i <= 10; i++)
            {
                yield return new Pedal
                {
                    Id = i,
                    Title = $"guitarTest{i}",
                    Price = i,
                    Quantity = i,
                    Description = $"test desc{i}",
                    Image = "test.jpg"
                };
            }
        }

        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return GetInstruments().ToList();
        }
    }
}

