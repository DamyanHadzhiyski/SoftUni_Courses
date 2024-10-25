using SoftUni.Data;

public class StartUp
{
    private static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(GetEmployeesFullInformation(context));
    }

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
                        .Select(e => new
                        {
                            e.EmployeeId,
                            e.FirstName,
                            e.LastName,
                            e.MiddleName,
                            e.JobTitle,
                            e.Salary
                        })
                        .OrderBy(e => e.EmployeeId)
                        .ToList();

        string result = string.Join(Environment.NewLine,
                                employees.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} " +
                                $"{e.JobTitle} {e.Salary:F2}"));

        return result;
    }
}