using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Team
    {
        public long  TeamID { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Foto { get; set; }

        //Relations
        public int CaptainID { get; set; }
        public User Captain { get; set; }

        //Max 2 personen per team, daarom geen lijst van users
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
