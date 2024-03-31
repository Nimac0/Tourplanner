using System;
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
        public float Distance { get; set; }
    }
}
