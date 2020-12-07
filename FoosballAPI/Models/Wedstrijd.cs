using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Wedstrijd
    {
        public long WedstrijdID { get; set; }
        public DateTime Date { get; set; }
        public int RondeNummer { get; set; }
        
        //Relations
        public int UserID { get; set; }
        public User User { get; set; }
        public int WedstrijdTypeID { get; set; }
        public WedstrijdType WedstrijdType { get; set; }
        public int TournooiID { get; set; }
        public Tournooi Tournooi { get; set; }
        [JsonIgnore]
        public ICollection<TableWedstrijd> TableWedstrijden { get; set; }
    }
}
