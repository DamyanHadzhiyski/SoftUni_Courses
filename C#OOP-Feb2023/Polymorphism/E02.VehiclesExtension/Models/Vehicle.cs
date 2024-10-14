using E01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace E01.Vehicles.Models
{
    public class Vehicle : IVehicle
    {
        private double fuelIncreasedConsumption;
        private double fuelQty;

        protected Vehicle(double tankCapacity, double fuelQty, double fuelConsumption, double fuelIncreasedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQty = fuelQty;
            FuelConsumption = fuelConsumption;
            this.fuelIncreasedConsumption = fuelIncreasedConsumption;
        }

        public double FuelQty
        {
            get => fuelQty;
            protected set
            {
                if (this.TankCapacity < value)
                {
                    this.fuelQty = 0;
                }
                else
                {
                    this.fuelQty = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public void Drive(double distance, bool isIncreasedConsumption = true)
        {
            double totalFuelConsumption = isIncreasedConsumption
                ? this.FuelConsumption + this.fuelIncreasedConsumption
                : this.FuelConsumption;

            double distanceCanDrive = this.FuelQty / totalFuelConsumption;

            if (distance <= distanceCanDrive)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQty -= distance * totalFuelConsumption;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double quantity)
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
                    this.FuelQty += quantity;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQty:F2}";
        }
    }
}
