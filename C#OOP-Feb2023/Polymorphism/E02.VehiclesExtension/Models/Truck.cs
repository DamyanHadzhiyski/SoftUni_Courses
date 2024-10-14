using E01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double summerIncreasedConsumption = 1.6;
     
        public Truck(double tankCapacity, double fuelQty, double fuelConsumption)
            : base (tankCapacity, fuelQty, fuelConsumption, summerIncreasedConsumption)
        {
        }
        public override void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double freeTankCapacity = this.TankCapacity - this.FuelQty;

                if (quantity <= freeTankCapacity)
                {
                    this.FuelQty += quantity * 0.95;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
            }
        }

    }
}
