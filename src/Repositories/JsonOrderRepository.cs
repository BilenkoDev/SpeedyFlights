using Newtonsoft.Json;
using SpeedyFlights.src.Entities;
using SpeedyFlights.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Repositories
{
    public class JsonOrderRepository : IOrderRepository
    {
        public Dictionary<string, Order> LoadOrders(string jsonFileName)
        {
            string dataFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string jsonFilePath = Path.Combine(dataFolderPath, jsonFileName);

            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"File '{jsonFileName}' not found in the specified location: '{jsonFilePath}'");
            }

            string json = File.ReadAllText(jsonFilePath);
            var ordersDict = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);

            if (ordersDict != null)
            {
                foreach (var key in ordersDict.Keys.ToList())
                {
                    ordersDict[key].OrderId = key;
                }
            }

            return ordersDict ?? new Dictionary<string, Order>();
        }
    }
}
