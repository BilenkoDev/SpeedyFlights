using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Interfaces
{
    public interface IFlightScheduler
    {
        void LoadFlightSchedule();
        void LoadOrders(string jsonFileName);
        void DistributeOrders();
        void DisplaySchedule(int storyNumber);
    }
}
