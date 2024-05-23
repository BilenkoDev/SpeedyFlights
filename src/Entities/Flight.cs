using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Entities
{
    public class Flight
    {
        public int FlightNumber { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public int Capacity { get; private set; }
        public List<Order> AssignedOrders { get; private set; }
        public int Day { get; private set; }

        public Flight(int flightNumber, DateTime dateTime, string origin, string destination, int capacity, int day)
        {
            FlightNumber = flightNumber;
            DateTime = dateTime;
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Capacity = capacity;
            Day = day;
            AssignedOrders = new List<Order>();
        }

        public bool AddOrder(Order order)
        {
            if (AssignedOrders.Count < Capacity)
            {
                AssignedOrders.Add(order);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {Origin}, arrival: {Destination}, day: {Day}";
        }
    }
}
