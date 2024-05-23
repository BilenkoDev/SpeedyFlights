using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyFlights.src.Entities
{
    public class Plane
    {
        public string Id { get; private set; }
        public int Capacity { get; private set; }

        public Plane(string id, int capacity)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Capacity = capacity;
        }
    }
}
