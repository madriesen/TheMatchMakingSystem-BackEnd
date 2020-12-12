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
    public class TeamController : ControllerBase
    {
        private readonly ApiContext _context;

        public TeamController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/Team
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }
        //GET: api/Team/MyTeams
        [Authorize]
        [HttpGet("myTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetMyTeams()
        {
            int userID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            return await _context.Teams.Where(u => u.Player1ID == userID || u.Player2ID == userID).ToListAsync();
        }
        //GET: api/Team/{TeamID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeamsByID(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        //POST: api/Team
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return Ok(team);
        }

        // PUT: api/Team/{TeamID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Team>> PutTeam(int id, Team team)
        {
            if (id != team.TeamID)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return team;
        }

        //DELETE: api/Team/{TeamID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}
