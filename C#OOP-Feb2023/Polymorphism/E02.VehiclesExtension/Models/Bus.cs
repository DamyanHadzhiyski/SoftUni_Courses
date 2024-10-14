using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01.Vehicles.Models.Interfaces;

namespace E01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double fullIncreasedConsumption = 1.4;

        public Bus(double tankCapacity, double fuelQty, double fuelConsumption) 
            : base(tankCapacity, fuelQty, fuelConsumption, fullIncreasedConsumption)
        {
        }
    }
}
