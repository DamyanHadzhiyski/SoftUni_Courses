using E03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IHero Create(string type, string name);
    }
}
