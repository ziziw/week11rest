using System;

namespace Rocket_Elevators_REST_API.Models
{
    public class Building_Detail
    {
        public int id { get; set; }
        public int building_id { get; set; }
        public string information_key { get; set; }
        public string value { get; set; }
    }
}
