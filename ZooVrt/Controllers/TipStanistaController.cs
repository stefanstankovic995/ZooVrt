using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooVrt.Domain.Entities;
using ZooVrt.Persistance.Database;

namespace ZooVrt.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipStanistaController : Controller
    {
        public ZooVrtContext Context { get; set; }

        [HttpGet]
        public async Task<List<TipStanista>> GetAll()
        {
            return await Context.TipoviStanista
                .ToListAsync();
        }

        [HttpPost]
        public async Task<int> Add([FromBody] TipStanista tipStanista)
        {
            Context.TipoviStanista
                .Add(tipStanista);
            await Context.SaveChangesAsync();

            return tipStanista.Id;
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
