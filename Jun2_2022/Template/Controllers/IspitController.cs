using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Template.Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IspitController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IspitController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("PreuzmiDostave/{cenaOd}/{cenaDo}")]
        [HttpPut]

        public async Task<ActionResult> preuzmidostave([FromBody] Dostava dostava,int cenaOd, int cenaDo)
        {   
            try{

            var rez = Context.Dostave.Where(p=>p.ZapreminaPaketa>=dostava.ZapreminaPaketa && p.TezinaPaketa>=p.TezinaPaketa && p.DatumPrijema.Date==dostava.DatumPrijema.Date && p.DatumDostave.Date==dostava.DatumDostave.Date && p.Cena>=cenaOd && p.Cena<=cenaDo)
                                     .Include(p=>p.KompanijaSpoj)
                                     .Include(p=>p.VoziloSpoj)
                                     .ThenInclude(p=>p.Prevoz);
            return Ok(await 
                rez.Select(p=>new{
                    Id = p.DostavaID,
                    Naziv=p.KompanijaSpoj.Naziv,
                    Tip=p.VoziloSpoj.Prevoz.Naziv,
                    Cena=p.Cena,
                    BrojAngazovanja=p.KompanijaSpoj.BrojAngazovanja,
                    Prihod = p.KompanijaSpoj.Prihod
                }).ToListAsync()
            );
        }catch(Exception e )
        {
            return BadRequest(e.Message);
        }
        }

        [Route("IsporuciDostavu/{dostavaID}")]
        [HttpPut]
        public async Task<ActionResult> isporuci(int dostavaID)
        {   
            try{
            
            var dostava = Context.Dostave
                        .Include(p=>p.KompanijaSpoj)
                        .Where(p=>p.DostavaID == dostavaID).FirstOrDefault();

        

            if(dostava == null)
            {
                return BadRequest("Ne postoji ovakav tip isporuke u bazi");
            }

               dostava.KompanijaSpoj.BrojAngazovanja++;
               dostava.KompanijaSpoj.Prihod+=dostava.Cena;

               Context.Update(dostava);
               await Context.SaveChangesAsync();

               return Ok("Uspesna isporuka");
            
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
