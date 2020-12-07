using FoosballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
