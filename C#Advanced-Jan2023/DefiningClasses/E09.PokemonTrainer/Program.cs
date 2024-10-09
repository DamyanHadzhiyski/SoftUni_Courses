using E09.PokemonTrainer;

//create a list with all the trainers
List<Trainer> trainers = new List<Trainer>();

//read the input
string input = string.Empty;

while ((input = Console.ReadLine()) != "Tournament")
{
    //split the input
    string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string trainerName = splitInput[0];
    string pokemonName = splitInput[1];
    string pokemonElement = splitInput[2];
    int pokemonHealth = int.Parse(splitInput[3]);

    //create the new pokemon
    Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

    //check if the trainer exist
    bool trainerExists = false;

    for (int i = 0; i < trainers.Count; i++)
    {
        if (trainers[i].Name == trainerName)
        {
            trainers[i].AddPokemon(newPokemon);
            trainerExists = true;
        }
    }

    if (!trainerExists)
    {
        Trainer newTrainer = new Trainer(trainerName, newPokemon);
        trainers.Add(newTrainer);
    }
}

//start the battle
string batleCommands = string.Empty;

while((batleCommands = Console.ReadLine()) != "End")
{
    foreach (var trainer in trainers)
    {
        if (trainer.ContainsPokemonWithElement(batleCommands))
        {
            trainer.BadgesCount++;
        }
        else
        {
            trainer.ReducePokemonsHealth(10);
        }
    }
}

trainers = trainers.OrderByDescending(t => t.BadgesCount).ToList();

foreach (var trainer in trainers)
{
    trainer.Print();
}