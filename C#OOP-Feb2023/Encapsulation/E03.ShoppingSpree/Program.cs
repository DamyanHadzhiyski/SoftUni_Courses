using E03.ShoppingSpree;
using System.Text.RegularExpressions;
using System.Xml.Linq;

List<Person> persons = new();

string[] personsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

foreach (string pers in personsData)
{
    string[] info = pers.Split("=", StringSplitOptions.RemoveEmptyEntries);

    try
    {
        Person newPerson = new(info[0], int.Parse(info[1]));
        persons.Add(newPerson);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return;
    }
}

List<Product> products = new();

string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

foreach (string prod in productsData)
{
    string[] info = prod.Split("=", StringSplitOptions.RemoveEmptyEntries);

    try
    {
        Product newProduct = new(info[0], int.Parse(info[1]));

        products.Add(newProduct);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return;
    }
}


string inputCommand = string.Empty;

while ((inputCommand = Console.ReadLine()) != "END")
{
    string[] splitCommand = inputCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Person buyingPerson = persons.FirstOrDefault(x => x.Name == splitCommand[0]);
    Product productToBuy = products.FirstOrDefault(x => x.Name == splitCommand[1]);

    buyingPerson.BuyProduct(productToBuy);
}

foreach (var person in persons)
{
    Console.WriteLine(person.ToString());
}
