using E01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double summerIncreasedConsumption = 0.9;

        public Car(double tankCapacity, double fuelQty, double fuelConsumption)
            : base(tankCapacity, fuelQty, fuelConsumption, summerIncreasedConsumption)
        {           
        }
    }
}
