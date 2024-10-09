using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E07.RawData
{
    public class Tire
    {
        private int age;
        private decimal pressure;

        public Tire(decimal pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }

        public int Age { get; set; }
        public decimal Pressure { get; set; }
    }
}
