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


        Console.WriteLine(DeleteProjectById(context));
    }

    public static string DeleteProjectById(SoftUniContext context)
    {
        var project = context.Projects.Find(2);

        var employeesOnProject = context.EmployeesProjects
                                 .Select(p => new { p.ProjectId, p.EmployeeId })
                                 .Where(p => p.ProjectId == 2)
                                 .ToList();

        foreach (var record in employeesOnProject)
        {
            EmployeeProject employeeProject = context.EmployeesProjects
                                              .FirstOrDefault(ep => ep.EmployeeId == record.EmployeeId);
            context.EmployeesProjects.Remove(employeeProject);
        }

        context.Projects.Remove(project);

        context.SaveChanges();

        string result = string.Join(Environment.NewLine, 
                                        context.Projects
                                        .Select(p => p.Name)
                                        .Take(10));
        return result;
    }
}