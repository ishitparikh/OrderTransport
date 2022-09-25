using Newtonsoft.Json;
using OrderTransport.Enums;
using OrderTransport.Interfaces;
using OrderTransport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderTransport.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFlightService _flightService;
        public OrderService(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public List<OrderScheduleViewModel> GetOrderSchedule()
        {
            var orderScheduleList = new List<OrderScheduleViewModel>();
            var flights = _flightService.GetFlights();
            var orders = this.GetOrders();

            foreach (OrderModel order in orders)
            {
                var orderSchedule = new OrderScheduleViewModel();
                orderSchedule.OrderNumber = order.OrderNumber;
                orderSchedule.ArrivalCity = order.ArrivalCity;

                if (flights.Any(x => x.ArrivalCity == order.ArrivalCity))
                {
                    var arrivalFlight = this.GetFlightForOrderSchedule(order.ArrivalCity, flights);
                    if (arrivalFlight != null)
                    {
                        arrivalFlight.OrderCapacity -= 1;
                    }
                    orderSchedule.FlightDetails = arrivalFlight;
                }

                orderScheduleList.Add(orderSchedule);
            }

            return orderScheduleList;
        }

        private List<OrderModel> GetOrders()
        {
            var filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/DataFiles/coding-assigment-orders.json";
            var ordersString = File.ReadAllText(filePath);
            var ordersData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(ordersString);
            var orders = (from o in ordersData
                          select new OrderModel()
                          {
                              OrderNumber = o.Key,
                              ArrivalCity = o.Value.FirstOrDefault().Value
                          }).ToList();

            return orders;
        }

        private FlightViewModel GetFlightForOrderSchedule(string arrivalCity, List<FlightViewModel> flights)
        {
            for(var i = 1; i <= 2; i++)
            {
                if(flights.Any(x => x.ArrivalCity == arrivalCity && x.Day == i && x.OrderCapacity - 1 > -1))
                {
                    var flight = flights.Where(x => x.ArrivalCity == arrivalCity && x.Day == i && x.OrderCapacity - 1 > -1).FirstOrDefault();
                    return flight;
                }
            }

            return null;
        }
    }
}
