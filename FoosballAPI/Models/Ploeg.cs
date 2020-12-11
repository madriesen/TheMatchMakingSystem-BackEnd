using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Ploeg
    {
        public int PloegID { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }

        //Relations
        [ForeignKey("User")]
        public int? UserID { get; set; }   
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<User> Players { get; set; }
        [JsonIgnore]
        public ICollection<Team> Teams { get; set; }
    }
}
