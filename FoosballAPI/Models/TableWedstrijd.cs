using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class TableWedstrijd
    {
        public int WestrijdID { get; set; }
        public Wedstrijd Wedstrijd { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }
    }
}
