using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Entities
{
    public class Order
    {
        private string _orderId;

        public string OrderId
        {
            get => _orderId;
            set => _orderId = value ?? throw new ArgumentNullException(nameof(value), "OrderId cannot be null");
        }

        public string Destination { get; set; }
    }
}
