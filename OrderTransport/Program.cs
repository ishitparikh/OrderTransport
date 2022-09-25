using Microsoft.Extensions.DependencyInjection;
using OrderTransport.Interfaces;
using OrderTransport.Models;
using OrderTransport.Services;
using System;

namespace OrderTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
            .AddSingleton<IFlightService, FlightService>()
            .AddSingleton<IOrderService, OrderService>()
            .BuildServiceProvider();

            var flightService = serviceProvider.GetService<IFlightService>();
            var orderService = serviceProvider.GetService <IOrderService>();

            var flights = flightService.GetFlights();
            Console.WriteLine("Flight list:");
            foreach(FlightViewModel vm in flights)
            {
                Console.WriteLine("Flight: " + vm.FlightNumber + ", departure: " + vm.DepartureCity + ", arrival: " + vm.ArrivalCity + ", day: " + vm.Day);
            }

            var ordersSchedule = orderService.GetOrderSchedule();
            Console.WriteLine();
            Console.WriteLine("Order Schedule:");
            foreach (OrderScheduleViewModel vm in ordersSchedule)
            {
                if (vm.FlightDetails != null)
                {
                    Console.WriteLine("order: " + vm.OrderNumber + ", flightNumber: " + vm.FlightDetails.FlightNumber + ", departure: " + vm.FlightDetails.DepartureCity
                        + ", arrival: " + vm.ArrivalCity + ", day: " + vm.FlightDetails.Day);
                }
                else
                {
                    Console.WriteLine("order: " + vm.OrderNumber + ", flightNumber: not scheduled");
                }
            }
            Console.ReadKey();
        }
    }
}
