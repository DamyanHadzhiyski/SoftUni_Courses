using SoftUni.Data;
using SoftUni.Models;
using System.Linq;

public class StartUp
{
    private static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(AddNewAddressToEmployee(context));
    }

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        context.Addresses.Add(address);

        var employee = context.Employees
                        .FirstOrDefault(e => e.LastName == "Nakov");

        if(employee != null)
        {
            employee.Address = address;
        }

        context.SaveChanges();

        var employees = context.Employees
                       .Select(e => new
                       {
                           e.AddressId,
                           e.Address.AddressText
                       })
                       .OrderByDescending(e => e.AddressId)
                       .Take(10)
                       .ToList();

        string result = string.Join(Environment.NewLine,
                                employees.Select(e => $"{e.AddressText}"));

        return result;
    }

}