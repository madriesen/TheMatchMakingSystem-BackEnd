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
    public class WedstrijdTypeController : ControllerBase
    {
        private readonly ApiContext _context;

        public WedstrijdTypeController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/WedstrijdType
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WedstrijdType>>> GetWedstrijdTypes()
        {
            return await _context.WedstrijdTypes.ToListAsync();
        }

        //GET: api/WedstrijdType/{WedstrijdTypeID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<WedstrijdType>> GetWedstrijdTypesByID(int id)
        {
            return await _context.WedstrijdTypes.FindAsync(id);
        }
    }
}
