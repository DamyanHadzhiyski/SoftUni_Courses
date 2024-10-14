using E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal Create(string[] arguments);
    }
}
