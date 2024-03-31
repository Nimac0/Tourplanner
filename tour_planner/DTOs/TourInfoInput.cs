using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour_planner.DTOs
{
    public class TourInfoInput
    {
        public string Tourname { get; set; }
        public string Description { get; set; }
        public string Transportation { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public bool Modify { get; set; } = false;
    }
}
