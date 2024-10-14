using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.PizzaCalories
{
    public class Topping
    {
		private const double baseCalories = 2;
		private int weight;
		private string toppingType;

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        private string ToppingType
		{
			set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {char.ToUpper(value[0]) + value.Substring(1).ToLower()} on top of your pizza.");
                }

                toppingType = char.ToUpper(value[0]) + value.Substring(1).ToLower(); 
            }
		}
		private int Weight
		{
			set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                weight = value; 
            }
		}

        public double GetCalories()
        {
            return baseCalories * weight * ToppingTypeModifier();
        }

        private double ToppingTypeModifier()
        {
            double result = 1;

            switch (toppingType)
            {
                case "Meat":
                    result = 1.2;
                    break;
                case "Veggies":
                    result = 0.8;
                    break;
                case "Cheese":
                    result = 1.1;
                    break;
                case "Sauce":
                    result = 0.9;
                    break;
            }

            return result;
        }
    }
}
