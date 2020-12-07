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
    public class UserWedstrijdController : ControllerBase
    {
        private readonly ApiContext _context;

        public UserWedstrijdController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/UserWedstrijd
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWedstrijd>>> GetUserWedstrijds()
        {
            return await _context.UserWedstrijden.ToListAsync();
        }

        //GET: api/UserWedstrijd/{UserWedstrijdID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserWedstrijd>> GetUserWedstrijdsByID(int id)
        {
            return await _context.UserWedstrijden.FindAsync(id);
        }
    }
}
