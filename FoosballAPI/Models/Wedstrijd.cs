using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Wedstrijd
    {
        public int WedstrijdID { get; set; }
        public DateTime Date { get; set; }
        public int RondeNummer { get; set; }
        
        //Relations
        public int WedstrijdTypeID { get; set; }
        public WedstrijdType WedstrijdType { get; set; }
        public int TournooiID { get; set; }
        public Tournooi Tournooi { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }

        public int Team1ID { get; set; }
        public Team Team1 { get; set; }
     
        public int? Team2ID { get; set; }
        public Team Team2 { get; set; }
        [JsonIgnore]
        public ICollection<Score> Scores { get; set; }
    }
}
