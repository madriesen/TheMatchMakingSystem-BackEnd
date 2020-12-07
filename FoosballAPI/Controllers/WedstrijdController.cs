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
    public class WedstrijdController : ControllerBase
    {
        private readonly ApiContext _context;

        public WedstrijdController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/Wedstrijd
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wedstrijd>>> GetWedstrijds()
        {
            return await _context.Wedstrijden.ToListAsync();
        }

        //GET: api/Wedstrijd/{WedstrijdID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Wedstrijd>> GetWedstrijdsByID(int id)
        {
            return await _context.Wedstrijden.FindAsync(id);
        }

        //POST: api/Wedstrijd
        [HttpPost]
        public async Task<ActionResult<Wedstrijd>> PostWedstrijd(Wedstrijd wedstrijd)
        {
            _context.Wedstrijden.Add(wedstrijd);
            await _context.SaveChangesAsync();

            return Ok(wedstrijd);
        }

        // PUT: api/Wedstrijd/{WedstrijdID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Wedstrijd>> PutWedstrijd(int id, Wedstrijd wedstrijd)
        {
            if (id != wedstrijd.WedstrijdID)
            {
                return BadRequest();
            }

            _context.Entry(wedstrijd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WedstrijdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return wedstrijd;
        }

        //DELETE: api/Wedstrijd/{WedstrijdID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Wedstrijd>> DeleteWedstrijd(int id)
        {
            var wedstrijd = await _context.Wedstrijden.FindAsync(id);
            if (wedstrijd == null)
            {
                return NotFound();
            }

            _context.Wedstrijden.Remove(wedstrijd);
            await _context.SaveChangesAsync();

            return wedstrijd;
        }

        private bool WedstrijdExists(int id)
        {
            return _context.Wedstrijden.Any(e => e.WedstrijdID == id);
        }
    }
}
