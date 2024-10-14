using E03.Raiding.Core.Interfaces;
using E03.Raiding.Factories.Interfaces;
using E03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Raiding.Core
{
    public class Engine : IEngine
    {
        IHeroFactory heroFactory;
        public Engine(IHeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            //number of commands
            int neededHeros = int.Parse(Console.ReadLine());

            List<IHero> heros = new();

            while (heros.Count < neededHeros)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                IHero newHero = null;

                try
                {
                    newHero = heroFactory.Create(heroType, heroName);
                    heros.Add(newHero);
                }
                catch (InvalidDataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            //boss's power
            int bossPower = int.Parse(Console.ReadLine());

            int herosPower = 0;

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());
                herosPower += hero.Power;
            }

            if (bossPower <= herosPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
