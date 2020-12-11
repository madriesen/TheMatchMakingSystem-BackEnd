using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        //Relations
        public int? PloegID { get; set; }
        public Ploeg Ploeg { get; set; }

        public int? Player1ID { get; set; }
        [ForeignKey("Player1ID")]
        public User Player1 { get; set; }
        
        public int? Player2ID { get; set; }
        [ForeignKey("Player2ID")]
        public User Player2 { get; set; }
        [JsonIgnore]
        [NotMapped]
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
        [JsonIgnore]
        public ICollection<Score> Scores { get; set; }
    }
}
