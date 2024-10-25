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

        Console.WriteLine(GetAddressesByTown(context));
    }

    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
                        .AsNoTracking()
                        .Select(a => new
                        {
                            a.Employees,
                            a.Town,
                            a.AddressText
                        })
                        .OrderByDescending(a => a.Employees.Count)
                        .ThenBy(a => a.Town.Name)
                        .ThenBy(a => a.AddressText)
                        .Take(10)
                        .ToList();


        string result = string.Join(Environment.NewLine,
                                        addresses.Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"));

        return result.Trim();
    }

}