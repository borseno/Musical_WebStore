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
using AutoMapper;
using Musical_WebStore_BlazorApp.Shared.DTOs;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentsController : Controller
    {
        private readonly MusicalShopIdentityDbContext ctx;
        private readonly IMapper _mapper;

        public InstrumentsController(MusicalShopIdentityDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            _mapper = mapper;
        }

        private Task<Instrument[]> GetInstrumentsAsync() => ctx.Instruments.ToArrayAsync();

        [HttpGet]
        public async Task<IEnumerable<InstrumentDTO>> Get()
        {
            var instruments = await GetInstrumentsAsync();
            var instrumentsDTO = instruments.Select(i => _mapper.Map<InstrumentDTO>(i)).ToList();
            for(int x = 0; x < instrumentsDTO.Count(); x ++)
            {
                var stars = ctx.Stars.Where(s => s.InstrumentId == instrumentsDTO[x].Id);
                if(stars.Count() != 0)
                {   
                    instrumentsDTO[x].AvgMark = (float)stars.Average(i => i.Mark);
                }
                else
                {
                    instrumentsDTO[x].AvgMark = 0;
                }
            }

            return instrumentsDTO;
        }
    }
}

