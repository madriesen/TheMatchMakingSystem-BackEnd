using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string token { get; set; }

        //Relations 
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
