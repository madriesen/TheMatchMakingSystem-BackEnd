using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Tournooi
    {
        public int TournooiID { get; set; }
        public string Name { get; set; }
        public int? Ploeg1ID { get; set; }

        public Ploeg Ploeg1 { get; set; }

        public int? Ploeg2ID { get; set; }

        public Ploeg Ploeg2 { get; set; }
        //Relations
        [JsonIgnore]
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}
