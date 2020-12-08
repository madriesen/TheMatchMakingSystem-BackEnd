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
        public int PloegID { get; set; }
        public Ploeg Ploeg { get; set; }
        public int Player1Id { get; set; }
        [NotMapped]
        public User Player1 { get; set; }

        public int? Player2ID { get; set; }
        public User Player2 { get; set; }
        [JsonIgnore]
        [NotMapped]
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}
