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

        Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
    }

    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle,
                            e.Salary
                        })
                        .Where(e => e.FirstName.Substring(0, 2).ToLower() == "sa")
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList();

        StringBuilder result = new();

        foreach (var employee in employees)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} " +
                                $"- {employee.JobTitle} - (${employee.Salary:F2})");
        }

        return result.ToString().TrimEnd();
    }
}