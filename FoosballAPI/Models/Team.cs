using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Team
    {
        public long  TeamID { get; set; }

        //Relations
        public int PloegID { get; set; }
        public Ploeg Ploeg { get; set; }
        public int Player1Id { get; set; }
        public User Player1 { get; set; }

        public int Player2ID { get; set; }
        public User Player2 { get; set; }
    }
}
