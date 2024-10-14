using E03.Raiding.Factories.Interfaces;
using E03.Raiding.Models;
using E03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E03.Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new InvalidDataException("Invalid hero!");
            }
        }
    }
}
