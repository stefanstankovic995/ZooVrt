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
    public class ZooVrtController : ControllerBase
    {
        public ZooVrtContext Context { get; set; }

        public ZooVrtController(ZooVrtContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<List<Domain.Entities.ZooVrt>> GetAll()
        {
            return await Context.ZooVrt
                .Include(x => x.Lokacije)
                    .ThenInclude(x => x.Staniste)
                .ToListAsync();
        }

        [Route("DodajVrt")]
        [HttpPost]
        public async Task Add([FromBody] Domain.Entities.ZooVrt zooVrt)
        {
            Context.ZooVrt
                .Add(zooVrt);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update([FromBody] Domain.Entities.ZooVrt zooVrt)
        {
            //var stariVrt = await Context.Vrtovi.FindAsync(vrt.ID);
            //stariVrt.Kapacitet = vrt.Kapacitet;
            //stariVrt.Naziv = vrt.Naziv;
            //stariVrt.M = vrt.M;
            //stariVrt.N = vrt.N;

            Context.Update<Domain.Entities.ZooVrt>(zooVrt);
            await Context.SaveChangesAsync();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            var zooVrt = await Context.ZooVrt.FindAsync(id);
            Context.Remove(zooVrt);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniLokaciju/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpisiLokaciju(int id, [FromBody] Lokacija lok)
        {
            var zooVrt = await Context.ZooVrt
                .FindAsync(id);
            lok.ZooVrt = zooVrt;

            if (Context.Lokacije.Any(p => p.Vrsta == lok.Vrsta && (p.X != lok.X || p.Y != lok.Y)))
            {
                var xy = Context.Lokacije.Where(p => p.Vrsta == lok.Vrsta).FirstOrDefault();
                return BadRequest(new { xy?.X, xy?.Y });
            }

            var thatLok = Context.Lokacije
                .Where(p => p.X == lok.X && p.Y == lok.Y)
                .FirstOrDefault();

            if (thatLok != null)
            {
                if (thatLok.ZooVrt.Kapacitet < thatLok.Zbir + lok.Zbir)
                {
                    return StatusCode(406);
                }
                else if (thatLok.Vrsta != lok.Vrsta)
                {
                    return StatusCode(406);
                }
                else
                {
                    thatLok.Zbir += lok.Zbir;
                    await Context.SaveChangesAsync();
                    return Ok();
                }
            }

            if ((thatLok != null && thatLok.Zbir == 0) || thatLok == null)
            {
                Context.Lokacije.Add(lok);
                await Context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return StatusCode(406);
            }
        }
    }
}
