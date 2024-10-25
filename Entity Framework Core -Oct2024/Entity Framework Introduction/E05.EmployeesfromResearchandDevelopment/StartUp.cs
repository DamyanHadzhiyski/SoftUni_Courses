using SoftUni.Data;

public class StartUp
{
    private static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
    }

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.Department.Name,
                            e.Salary
                        })
                        .Where(e => e.Name == "Research and Development")
                        .OrderBy(e => e.Salary)
                        .ThenByDescending(e => e.FirstName)
                        .ToList();

        string result = string.Join(Environment.NewLine,
                                employees.Select(e => $"{e.FirstName} {e.LastName} from {e.Name} " +
                                $"- ${e.Salary:F2}"));

        return result;
    }
}