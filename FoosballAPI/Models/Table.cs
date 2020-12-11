using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Table
    {
        public int TableID { get; set; }
        public string Name { get; set; }

        //Relations
        public int UserID { get; set; }
        public User User { get; set; }
        public int? PloegID { get; set; }
        public Ploeg Ploeg { get; set; }
        [JsonIgnore]
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}
