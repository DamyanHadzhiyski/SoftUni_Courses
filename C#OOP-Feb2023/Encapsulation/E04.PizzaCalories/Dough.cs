using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.PizzaCalories
{
    public class Dough
    {
        private const double baseCalories = 2;
        private int weight;
        private string bakingType;
        private string flourType;

        public Dough(string flourType, string bakingType, int weight)
        {
            FlourType = flourType;
            BakingType = bakingType;
            Weight = weight;
        }

        private int Weight
        {
            set 
            { 
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value; 
            }
        }

        private string BakingType
        {
            set 
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingType = value.ToLower(); 
            }
        }

        private string FlourType
        {
            set 
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value.ToLower(); 
            }
        }

        public double GetCalories()
        {
            return baseCalories * weight * FlourTypeModifier() * BakingTypeModifier();
        }

        private double FlourTypeModifier()
        {
            double result = 1;

            switch (flourType)
            {
                case "white":
                    result = 1.5;
                    break;
                case "wholegrain":
                    result = 1.0;
                    break;
            }

            return result;
        }
        private double BakingTypeModifier()
        {
            double result = 1.0;

            switch (bakingType)
            {
                case "crispy":
                    result = 0.9;
                    break;
                case "chewy":
                    result = 1.1;
                    break;
                case "homemade":
                    result = 1.0;
                    break;
            }

            return result;
        }
    }
}
