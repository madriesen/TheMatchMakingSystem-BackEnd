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
    public class TableController : ControllerBase
    {
        private readonly ApiContext _context;

        public TableController(ApiContext context)
        {
            _context = context;
        }

        //GET: api/Table
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        //GET: api/Table/ploeg/{ploegid}
        [Authorize]
        [HttpGet("ploeg/{ploegid}")]
        public async Task<ActionResult<IEnumerable<Table>>> GetTablesByPloegID(int ploegid)
        {
            return await _context.Tables.Where(u=>u.PloegID==ploegid).ToListAsync();
        }
        //GET: api/Table/{TableID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTablesByID(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        //POST: api/Table
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return Ok(table);
        }

        // PUT: api/Table/{TableID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Table>> PutTable(int id, Table table)
        {
            if (id != table.TableID)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return table;
        }

        //DELETE: api/Table/{TableID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Table>> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return table;
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.TableID == id);
        }
    }
}
