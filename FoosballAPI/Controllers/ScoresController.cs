using FoosballAPI.Data;
using FoosballAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace FoosballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly ApiContext _context;

        public ScoresController(ApiContext context)
        {
            _context = context;
        }
        //GET: api/Score
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _context.Scores.ToListAsync();
        }

        // GET: api/Score/{scoreid}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Score>> GetScoreByID(int id)
        {
            return await _context.Scores.FindAsync(id);
        }
        //POST: api/Score
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {

            _context.Scores.Add(score);
            await _context.SaveChangesAsync();

            return Ok(score);
        }
        // PUT: api/Scores/scoreID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Score>> PutScore(int id, Score score)
        {
           

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return score;
        }

        //DELETE: api/Scores/{scoreID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Score>> DeleteScore(int id)
        {
            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(score);
            await _context.SaveChangesAsync();

            return score;
        }

        private bool ScoreExists(int id)
        {
            return _context.Scores.Any(e => e.ScoreID == id);
        }
      
    }
}
