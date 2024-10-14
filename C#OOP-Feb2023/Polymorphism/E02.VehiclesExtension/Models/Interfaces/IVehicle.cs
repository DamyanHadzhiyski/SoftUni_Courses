using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E01.Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQty { get; }
        public double FuelConsumption { get; }

        public void Drive(double distance, bool isIncreasedConsumption = true);
        public void Refuel(double qunatity);
    }
}
