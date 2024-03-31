using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour_planner.DTOs
{
    public class TourInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ModeOfTransportation { get; set; }
        public List<TourLog> Tourlogs { get; set; }
        public RouteInfo RouteInfo { get; set; }
    }
}
