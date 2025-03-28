﻿using E03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E03.Raiding.Models
{
    public abstract class Hero : IHero
    {
        protected Hero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
