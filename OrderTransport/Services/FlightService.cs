using OrderTransport.Enums;
using OrderTransport.Interfaces;
using OrderTransport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTransport.Services
{
    public class FlightService : IFlightService
    {
        public List<FlightViewModel> GetFlights()
        {
            var flights = new List<FlightViewModel>();

            var flightNumber = 1;
            for (var i = 1; i <= 2; i++)
            {
                foreach (ArrivalCityEnum arrivalCity in Enum.GetValues(typeof(ArrivalCityEnum)))
                {
                    flights.Add(new FlightViewModel()
                    {
                        FlightNumber = flightNumber,
                        DepartureCity = DepartureCityEnum.YUL.ToString(),
                        ArrivalCity = arrivalCity.ToString(),
                        Day = i
                    });
                    flightNumber++;
                }
            }

            return flights;
        }
    }
}
