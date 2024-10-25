using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

public class StartUp
{
    private static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(RemoveTown(context));
    }

    public static string RemoveTown(SoftUniContext context)
    {
        var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

        var townAddressesID = context.Addresses
                                 .Select(a => new
                                 {
                                     a.AddressId,
                                     a.Town
                                 })
                                 .Where(a => a.Town == town)
                                 .ToList();

        int addressesFound = townAddressesID.Count;

        foreach (var addressId in townAddressesID)
        {
            foreach (var employee in context.Employees)
            {
                if (employee.AddressId == addressId.AddressId)
                {
                    employee.AddressId = null;
                }
            }

            Address address = context.Addresses.FirstOrDefault(a => a.AddressId == addressId.AddressId);
            context.Addresses.Remove(address);
        }

        context.Towns.Remove(town);
        context.SaveChanges();

        string result = $"{addressesFound} addresses in Seattle were deleted";
        return result;
    }
}