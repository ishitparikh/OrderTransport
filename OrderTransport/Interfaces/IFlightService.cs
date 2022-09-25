using OrderTransport.Models;
using System.Collections.Generic;

namespace OrderTransport.Interfaces
{
    public interface IFlightService
    {
        List<FlightViewModel> GetFlights();
    }
}
