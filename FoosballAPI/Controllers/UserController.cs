using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoosballAPI.Models;
using FoosballAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using FoosballAPI.Data;

namespace FoosballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly ApiContext _context;

        public UserController(IUserService userService, ApiContext context)
        {
            _userService = userService;
            _context = context;
        }

        //GET: api/User
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == "Username").Value;
            return await _context.Users.ToListAsync();
        }

        //GET: api/User/{userID}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsersByID(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //GET: api/User/admins
        [Authorize]
        [HttpGet("journalists")]
        public async Task<ActionResult<IEnumerable<User>>> getAdmins()
        {
            var users = await _context.Users.ToListAsync();
            var admins = new ObservableCollection<User>();
            foreach (var user in users)
            {
                if (user.RoleID == 1)
                {
                    admins.Add(user);
                }
            }
            return admins;
        }

        //POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
      


            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        
        //api/User/authenticate
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
         
            return Ok(user);
        }

        // PUT: api/User/{userID}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return user;
        }

        //DELETE: api/User/{userID}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
