using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTransport.Models
{
    public class FlightViewModel
    {
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Day { get; set; }

        public int OrderCapacity { get; set; } = 20;

    }
}
