using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E09.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badgesCount;
        private List<Pokemon> pokemons = new List<Pokemon>();

        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            BadgesCount = 0;
            Pokemons = pokemon;
        }

        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public Pokemon Pokemons
        {
            set
            {
                AddPokemon(value);
            }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public void RemovePokemon(Pokemon pokemon)
        {
            pokemons.Remove(pokemon);
        }

        public bool ContainsPokemonWithElement(string element)
        {
            foreach (var pokemon in pokemons)
            {
                if (pokemon.Element == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void ReducePokemonsHealth(int pointToReduce)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                pokemons[i].Health -= pointToReduce;

                if (pokemons[i].Health <= 0)
                {
                    RemovePokemon(pokemons[i]);
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"{Name} {BadgesCount} {pokemons.Count}");
        }
    }
}
