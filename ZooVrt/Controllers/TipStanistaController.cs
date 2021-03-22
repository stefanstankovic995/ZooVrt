using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooVrt.Common.Models;
using ZooVrt.Domain.Entities;
using ZooVrt.Persistance.Database;

namespace ZooVrt.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipStanistaController : Controller
    {
        public ZooVrtContext Context { get; set; }
        private readonly IMapper _mapper;

        public TipStanistaController(ZooVrtContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<List<TipStanistaModel>> GetAll()
        {
            var rez = await Context.TipoviStanista
                .ToListAsync();

            return _mapper.Map<List<TipStanistaModel>>(rez); ;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TipStanistaModel tipStanista)
        {
            Context.TipoviStanista
                .Add(_mapper.Map<TipStanista>(tipStanista));
            await Context.SaveChangesAsync();

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tipStanista = await Context.TipoviStanista.FindAsync(id);
                Context.Remove(tipStanista);
                await Context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(406);
            }

            return Ok();
        }
    }
}
