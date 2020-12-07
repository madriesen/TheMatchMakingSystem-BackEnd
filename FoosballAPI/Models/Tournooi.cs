﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class Tournooi
    {
        public long TournooiID { get; set; }
        public string Name { get; set; }

        //Relations
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}