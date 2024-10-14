using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.PizzaCalories
{
    public class Pizza
    {
		private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new();
        }

        public string Name
		{
			get { return name; }
			private set 
            { 
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
		}
        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        private double GetCalories()
        {
            double result = 0;

            result += dough.GetCalories();

            foreach (var topping in toppings) 
            {
                result += topping.GetCalories();
            }

            return result;
        }

        public override string ToString()
        {
            return $"{name} - {GetCalories():F2} Calories.";
        }
    }
}
