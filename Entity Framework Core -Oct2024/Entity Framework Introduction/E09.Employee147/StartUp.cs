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

        Console.WriteLine(GetEmployee147(context));
    }
 
    public static string GetEmployee147(SoftUniContext context)
    {
        var employee = context.Employees
                       .Select(e => new
                       {
                           e.EmployeeId,
                           e.FirstName,
                           e.LastName,
                           e.JobTitle,
                           projects = e.EmployeesProjects
                                      .Select(ep => new { ep.Project.Name })
                                      .OrderBy(ep => ep.Name)
                                      .ToList()
                       })
                       .Where(e => e.EmployeeId == 147)
                       .ToList();

        StringBuilder result = new StringBuilder();

        result.AppendLine($"{employee[0].FirstName} {employee[0].LastName} - {employee[0].JobTitle}");

        var projects = employee[0].projects;

        foreach (var project in projects)
        {
            result.AppendLine(project.Name);
        }

        return result.ToString().Trim();
    }
}