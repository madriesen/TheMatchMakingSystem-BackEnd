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
    public class TableWedstrijdController : ControllerBase
    {
        private readonly ApiContext _context;

        public TableWedstrijdController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/TableWedstrijd
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableWedstrijd>>> GetTableWedstrijds()
        {
            return await _context.TableWedstrijden.ToListAsync();
        }

        //GET: api/TableWedstrijd/{TableWedstrijdID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TableWedstrijd>> GetTableWedstrijdsByID(int id)
        {
            return await _context.TableWedstrijden.FindAsync(id);
        }
    }
}
