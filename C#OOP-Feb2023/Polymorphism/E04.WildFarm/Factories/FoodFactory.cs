﻿using E04.WildFarm.Factories.Interfaces;
using E04.WildFarm.Models.Food;
using E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string type, int quantity)
        {
            switch (type)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid food type");
            }
        }
    }
}
