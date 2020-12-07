using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Table
    {
        public long TableID { get; set; }
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string Adres { get; set; }

        //Relations
        public int UserID { get; set; }
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}
