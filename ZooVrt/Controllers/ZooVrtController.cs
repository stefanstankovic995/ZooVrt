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
    public class ZooVrtController : ControllerBase
    {
        public ZooVrtContext Context { get; set; }
        private readonly IMapper _mapper;

        public ZooVrtController(ZooVrtContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ZooModel>> GetAll()
        {
            var rez = await Context.ZooVrt
                .Include(x => x.Lokacije)
                    .ThenInclude(x => x.Staniste)
                .ToListAsync();
            return _mapper.Map<List<ZooModel>>(rez); ;
        }

        [Route("DodajVrt")]
        [HttpPost]
        public async Task Add([FromBody] ZooModel zooVrt)
        {
            Context.ZooVrt
                .Add(_mapper.Map<Domain.Entities.ZooVrt>(zooVrt));
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update([FromBody] ZooModel zooVrt)
        {
            Context.Update<Domain.Entities.ZooVrt>(_mapper.Map<Domain.Entities.ZooVrt>(zooVrt));
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
        public async Task<IActionResult> UpisiLokaciju(int id, [FromBody] LokacijaModel lokacija)
        {
            var zooVrt = await Context.ZooVrt
                .Include(x => x.Lokacije)
                    .ThenInclude(x => x.Staniste)
                .SingleOrDefaultAsync(x => x.Id == id);

            var lok = _mapper.Map<Lokacija>(lokacija);
            var staniste = await Context.TipoviStanista.FindAsync(lokacija.Staniste.Id);
            lok.Staniste = staniste;

            if (zooVrt.M <= lokacija.X || zooVrt.N <= lokacija.Y)
            {
                return StatusCode(406);
            }

            Lokacija staraLokacija = zooVrt.Lokacije?.FirstOrDefault(x => x.X == lokacija.X && x.Y == lokacija.Y);

            if(staraLokacija == null)
            {
                if(lokacija.Zbir > zooVrt.Kapacitet)
                {
                    return StatusCode(406);
                }
                if (zooVrt.Lokacije == null)
                {
                    zooVrt.Lokacije = new List<Lokacija>();
                }
                zooVrt.Lokacije.Add(lok);
            }
            else
            {
                if(staraLokacija.Zbir + lok.Zbir > zooVrt.Kapacitet || 
                    staraLokacija.Vrsta != lok.Vrsta ||
                    staraLokacija.StanisteId != lok.Staniste.Id)
                {
                    return StatusCode(406);
                }
                staraLokacija.Zbir += lok.Zbir;
            }

            await Context.SaveChangesAsync();

            return Ok();
        }
    }
}
