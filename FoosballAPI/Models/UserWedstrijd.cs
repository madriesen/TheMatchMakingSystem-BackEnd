using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class UserWedstrijd
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int WedstrijdID { get; set; }
        public Wedstrijd Wedstrijd { get; set; }
    }
}
