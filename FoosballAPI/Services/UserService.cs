using FoosballAPI.Data;
using FoosballAPI.Helpers;
using FoosballAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoosballAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApiContext _Context;

        public UserService(IOptions<AppSettings> appSettings, ApiContext context)
        {
            _appSettings = appSettings.Value;
            _Context = context;
        }

        public User Authenticate(string email, string password)
        {
            var user = _Context.Users.Include(r=>r.Role).SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", user.UserID.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("RoleID", user.RoleID.ToString()),
                    //new Claim("Role", user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

    }
}
