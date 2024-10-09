using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E07.RawData
{
    internal class Car
    {
        //fields
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires = new Tire[4];

        //constructors
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        //properties
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
