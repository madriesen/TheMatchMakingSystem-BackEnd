using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoosballAPI.Data;
using FoosballAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FoosballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PloegController : ControllerBase
    {
        private readonly ApiContext _context;

        public PloegController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/Ploeg
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ploeg>>> GetPloegs()
        {
            return await _context.Ploegen.ToListAsync();
        }

        //GET: api/Ploeg/{PloegID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ploeg>> GetPloegsByID(int id)
        {
            return await _context.Ploegen.FindAsync(id);
        }
        
        //GET: api/Ploeg/{PloegID}


        //POST: api/Ploeg
        [HttpPost]
        public async Task<ActionResult<Ploeg>> PostPloeg(Ploeg ploeg)
        {
            _context.Ploegen.Add(ploeg);
            await _context.SaveChangesAsync();

            return Ok(ploeg);
        }

        // PUT: api/Ploeg/{PloegID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Ploeg>> PutPloeg(int id, Ploeg ploeg)
        {
            if (id != ploeg.PloegID)
            {
                return BadRequest();
            }

            _context.Entry(ploeg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PloegExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return ploeg;
        }

        //DELETE: api/Ploeg/{PloegID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Ploeg>> DeletePloeg(int id)
        {
            var Ploeg = await _context.Ploegen.FindAsync(id);
            if (Ploeg == null)
            {
                return NotFound();
            }

            _context.Ploegen.Remove(Ploeg);
            await _context.SaveChangesAsync();

            return Ploeg;
        }

        private bool PloegExists(int id)
        {
            return _context.Ploegen.Any(e => e.PloegID == id);
        }
    }
}
