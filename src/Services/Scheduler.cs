using SpeedyFlights.src.Entities;
using SpeedyFlights.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Services
{
    public class Scheduler : IFlightScheduler
    {
        private List<Plane> _planes;
        private List<Flight> _flights;
        private Dictionary<string, Order> _orders;
        private IOrderRepository _orderRepository;

        public Scheduler(List<Plane> planes, IOrderRepository orderRepository)
        {
            _planes = planes ?? throw new ArgumentNullException(nameof(planes));
            _flights = new List<Flight>();
            _orders = new Dictionary<string, Order>();
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public void LoadFlightSchedule()
        {
            DateTime day1 = new DateTime();
            DateTime day2 = new DateTime();

            _flights.Add(new Flight(1, day1, "YUL", "YYZ", _planes[0].Capacity, 1));
            _flights.Add(new Flight(2, day1, "YUL", "YYC", _planes[1].Capacity, 1));
            _flights.Add(new Flight(3, day1, "YUL", "YVR", _planes[2].Capacity, 1));
            _flights.Add(new Flight(4, day2, "YUL", "YYZ", _planes[0].Capacity, 2));
            _flights.Add(new Flight(5, day2, "YUL", "YYC", _planes[1].Capacity, 2));
            _flights.Add(new Flight(6, day2, "YUL", "YVR", _planes[2].Capacity, 2));
        }

        public void LoadOrders(string jsonFileName)
        {
            _orders = _orderRepository.LoadOrders(jsonFileName);
        }

        public void DistributeOrders()
        {
            foreach (var order in _orders.Values)
            {
                foreach (var flight in _flights)
                {
                    if (flight.Destination == order.Destination && flight.AddOrder(order))
                    {
                        break;
                    }
                }
            }
        }

        public void DisplaySchedule(int storyNumber)
        {
            Console.WriteLine($"SpeedyAir Flight Schedule, User Story# {storyNumber.ToString()}");
            foreach (var flight in _flights)
            {
                Console.WriteLine(flight);

                foreach (var order in flight.AssignedOrders)
                {
                    Console.WriteLine($"order: {order.OrderId}, flightNumber: {flight.FlightNumber}, departure: {flight.Origin}, arrival: {flight.Destination}, day: {flight.Day}");
                }

                if (storyNumber == 2)
                {
                    Console.WriteLine();
                }

            }

            if (storyNumber == 1)
            {
                Console.WriteLine();
            }

            var unscheduledOrders = _orders.Values.Where(order => !_flights.Any(flight => flight.AssignedOrders.Contains(order))).ToList();
            if (unscheduledOrders.Count > 0)
            {
                Console.WriteLine("Unscheduled Orders:");
                foreach (var order in unscheduledOrders)
                {
                    Console.WriteLine($"order: {order.OrderId}, flightNumber: not scheduled");
                }
            }
        }
    }
}
