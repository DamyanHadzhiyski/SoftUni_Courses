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

        Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
    }

    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {

        var departments = context.Departments
                            .Select(d => new
                            {
                                d.Name,
                                d.Manager,
                                d.Employees
                            })
                            .Where(d => d.Employees.Count > 5)
                            .OrderBy(d => d.Employees.Count)
                            .ThenBy(d => d.Name);
                            .ToList();

        StringBuilder result = new();

        foreach (var department in departments)
        {
            result.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

            var employeesOrdered = department.Employees
                                    .Select(e => new
                                    {
                                        e.FirstName,
                                        e.LastName,
                                        e.JobTitle
                                    })
                                    .OrderBy(e => e.FirstName)
                                    .ThenBy(e => e.LastName);

            foreach (var employee in department.Employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }

        return result.ToString().Trim();
    }
}