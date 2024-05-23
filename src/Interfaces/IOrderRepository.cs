using SpeedyFlights.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Interfaces
{
    public interface IOrderRepository
    {
        Dictionary<string, Order> LoadOrders(string jsonFileName);
    }
}
