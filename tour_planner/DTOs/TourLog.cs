﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour_planner.DTOs
{
    public class TourLog
    {
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string Distance { get; set; }
        public string Difficulty { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
    }
}
