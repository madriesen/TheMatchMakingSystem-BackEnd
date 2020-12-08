using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Ploeg
    {
        public int PloegID { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        //Relations
        [NotMapped]
        public int CaptainID { get; set; }
        [NotMapped]
        public User Captain { get; set; }
        public ICollection<User> Players { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
