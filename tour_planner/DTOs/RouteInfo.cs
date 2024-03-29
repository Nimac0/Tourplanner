using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour_planner.DTOs
{
    public class RouteInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Distance { get; set; }
        public string EstimateTime { get; set; }
        public string PictureFilePath { get; set; }
    }
}
