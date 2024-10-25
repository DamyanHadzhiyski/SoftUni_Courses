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

        Console.WriteLine(IncreaseSalaries(context));
    }

    public static string IncreaseSalaries(SoftUniContext context)
    {
        var employees = context.Employees
                         .Select(e => new
                         {
                             e.EmployeeId,
                             e.FirstName,
                             e.LastName,
                             e.Salary,
                             e.Department
                         })
                         .Where(d => d.Department.Name == "Engineering" || d.Department.Name == "Tool Design"
                                        || d.Department.Name == "Marketing" || d.Department.Name == "Information Services")
                         .OrderBy(e => e.FirstName)
                         .ThenBy(e => e.LastName)
                         .ToList();


        foreach (var employee in employees)
        {
            Employee employeeToIncrease = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            employeeToIncrease.Salary = employeeToIncrease.Salary * 1.12m;
        }

        context.SaveChanges();

        StringBuilder result = new();

        foreach (var id in employees)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.EmployeeId == id.EmployeeId);
            result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
        }

        return result.ToString().TrimEnd();
    }
}