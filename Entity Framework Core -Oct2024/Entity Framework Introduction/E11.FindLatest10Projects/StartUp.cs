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

        Console.WriteLine(GetLatestProjects(context));
    }

    public static string GetLatestProjects(SoftUniContext context)
    {

        var projects = context.Projects
                        .Select(p => new
                        {
                            p.Name,
                            p.Description,
                            p.StartDate
                        })
                        .OrderByDescending(p => p.StartDate)
                        .Take(10);

        var sortedProjects = projects
                             .Select(p => new
                             {
                                 p.Name,
                                 p.Description,
                                 p.StartDate
                             })
                             .OrderBy(p => p.Name)
                             .ToList();

        StringBuilder result = new();

        foreach (var project in sortedProjects)
        {
            result.AppendLine(project.Name);
            result.AppendLine(project.Description);
            result.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
        }

        return result.ToString().Trim();
    }
}