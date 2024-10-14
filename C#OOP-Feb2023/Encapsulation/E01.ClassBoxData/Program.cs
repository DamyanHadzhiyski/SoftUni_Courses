using _02_Encapsulation;

double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());


try
{
    Box newBox = new Box(length, width, height);

    Console.WriteLine($"Surface Area - {newBox.SurfaceArea():F2}");
    Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurfaceArea():F2}");
    Console.WriteLine($"Volume - {newBox.Volume():F2}");
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}