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
        private int weight;
        private string color;

        //constructors
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        //properties
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        //methods
        public void Print()
        {
            Console.WriteLine($"{Model}:");
            Console.WriteLine($"  {Engine.Model}:");
            Console.WriteLine($"    Power: {Engine.Power}");
            if (Engine.Displacement != 0)
            {
                Console.WriteLine($"    Displacement: {Engine.Displacement}");
            }
            else
            {
                Console.WriteLine($"    Displacement: n/a");
            }
            Console.WriteLine($"    Efficiency: {Engine.Efficiency}");
            if (Weight != 0)
            {
                Console.WriteLine($"  Weight: {Weight}");
            }
            else
            {
                Console.WriteLine($"  Weight: n/a");
            }        
            Console.WriteLine($"  Color: {Color}");
        }
    }
}
