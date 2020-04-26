using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MASB.MyAirport.EF;

namespace MyAirportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVol()
        {
            return await _context.Vol.ToListAsync();
        }

        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery] bool bagages = false)
        {
            /*
                        var vol = await _context.Vol.FindAsync(id);
                        var volwithBag= await _context.Vol.Include(v => v.mesBagages).Where(v => v.VolID == id).FirstAsync();
                        if (vol == null)
                        {
                            return NotFound();
                        }
                        if(bagages)
                        {
                            return vol;
                            //return vol + bagage
                        }

                        return vol;*/

            Vol volsRes;
            if (bagages)
            {
                volsRes= await _context.Vol.Include(v => v.mesBagages).Where(v => v.VolID == id).FirstAsync();
            }
            else 
                volsRes= await _context.Vol.FindAsync(id);

            if(volsRes == null)
            {
                return NotFound();
            }
            return volsRes;


        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolID)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vol.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolID }, vol);
        }

        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vol.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vol.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vol.Any(e => e.VolID == id);
        }
    }
}
