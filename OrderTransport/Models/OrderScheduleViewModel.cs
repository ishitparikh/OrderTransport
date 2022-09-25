using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTransport.Models
{
    public class OrderScheduleViewModel : OrderModel
    {
        public FlightViewModel FlightDetails { get; set; } = null;
    }
}
