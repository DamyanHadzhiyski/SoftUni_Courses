using E04.PizzaCalories;

string[] pizza = Console.ReadLine()
    .Split(" ");

string[] dough = Console.ReadLine()
    .Split(" ");

Dough newDough;
Pizza newPizza;

try
{
    newDough = new(dough[1], dough[2], int.Parse(dough[3]));
    newPizza = new(pizza[1], newDough);

    string input = string.Empty;

    while ((input = Console.ReadLine()) != "END")
    {
        string[] inArray = input.Split(" ");

        Topping newTopping = new(inArray[1], int.Parse(inArray[2]));
        newPizza.AddTopping(newTopping);
    }

    Console.WriteLine(newPizza.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}