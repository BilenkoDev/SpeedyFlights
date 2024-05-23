using SpeedyFlights.src.Entities;
using SpeedyFlights.src.Interfaces;
using SpeedyFlights.src.Repositories;
using SpeedyFlights.src.Services;

namespace SpeedyFlights
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Plane> planes = new List<Plane>
                {
                    new Plane("Plane1", 20),
                    new Plane("Plane2", 20),
                    new Plane("Plane3", 20)
                };

            IOrderRepository orderRepository = new JsonOrderRepository();
            IFlightScheduler scheduler = new Scheduler(planes, orderRepository);

            
            scheduler.LoadFlightSchedule();

            //printing schedule for user story 1
            scheduler.DisplaySchedule(1);

            //user story 2, loading orders from json file
            string jsonFilePath = "coding-assigment-orders.json";
            scheduler.LoadOrders(jsonFilePath);

            scheduler.DistributeOrders();
            //printing schedule for user story 2
            scheduler.DisplaySchedule(2); 

        }
    }
}
