using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E06.SpeedRacing
{
    public class Car
    {
        //field
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        //constructor
        public Car(string model, double fuelAmmount, double fuelConsumptionPerKilometer)
        {
            TravelledDistance = 0;
            Model = model;
            FuelAmount = fuelAmmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        //properties
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        //methods
        public void Drive(double kmToDrive)
        {
            if(kmToDrive * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= kmToDrive * FuelConsumptionPerKilometer;
                TravelledDistance += kmToDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
