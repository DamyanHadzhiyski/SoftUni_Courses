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

        Console.WriteLine(GetEmployeesInPeriod(context));
    }

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
                        .AsNoTracking()
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.Manager,
                            projects = e.EmployeesProjects
                                        .Select(ep => new
                                        {
                                            ep.Project.Name,
                                            ep.Project.StartDate,
                                            ep.Project.EndDate
                                        })
                                        .Where(p => p.Name != null
                                                    && p.StartDate.Year >= 2001
                                                    && p.StartDate.Year <= 2003)
                                        .ToList(),
                        })
                        .Take(10)
                        .ToList();

        StringBuilder result = new StringBuilder();

        foreach (var employee in employees)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

            var projects = employee.projects;

            if (projects.Count > 0)
            {
                foreach (var project in projects)
                {
                    DateTime projectStartDate = project.StartDate;

                    string startDate = projectStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = "not finished";

                    if (project.EndDate != null)
                    {
                        DateTime projectEndDate = (DateTime)project.EndDate;
                        endDate = projectEndDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    }

                    result.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

        }

        return result.ToString().Trim();
    }

}