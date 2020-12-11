using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        //Relations
        [ForeignKey("Team")]
        public int? WinnaarID { get; set; }

        public Team Winnaar { get; set; } 
        [ForeignKey("Wedstrijd")]
        public int? WedstrijdID { get; set; }
        public Wedstrijd Wedstrijd { get; set; }
       
    }
}
