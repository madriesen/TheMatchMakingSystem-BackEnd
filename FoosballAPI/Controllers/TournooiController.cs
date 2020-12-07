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
    public class TournooiController : ControllerBase
    {
        private readonly ApiContext _context;

        public TournooiController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/Tournooi
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournooi>>> GetTournoois()
        {
            return await _context.Tournooien.ToListAsync();
        }

        //GET: api/Tournooi/{TournooiID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournooi>> GetTournooisByID(int id)
        {
            return await _context.Tournooien.FindAsync(id);
        }

        //POST: api/Tournooi
        [HttpPost]
        public async Task<ActionResult<Tournooi>> PostTournooi(Tournooi tournooi)
        {
            _context.Tournooien.Add(tournooi);
            await _context.SaveChangesAsync();

            return Ok(tournooi);
        }

        // PUT: api/Tournooi/{TournooiID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Tournooi>> PutTournooi(int id, Tournooi tournooi)
        {
            if (id != tournooi.TournooiID)
            {
                return BadRequest();
            }

            _context.Entry(tournooi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournooiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return tournooi;
        }

        //DELETE: api/Tournooi/{TournooiID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Tournooi>> DeleteTournooi(int id)
        {
            var Tournooi = await _context.Tournooien.FindAsync(id);
            if (Tournooi == null)
            {
                return NotFound();
            }

            _context.Tournooien.Remove(Tournooi);
            await _context.SaveChangesAsync();

            return Tournooi;
        }

        private bool TournooiExists(int id)
        {
            return _context.Tournooien.Any(e => e.TournooiID == id);
        }
    }
}
