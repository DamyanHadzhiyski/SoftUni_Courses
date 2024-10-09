
using E05.DateModifier;

string startDate = Console.ReadLine();
string endDate = Console.ReadLine();

int difference = DateModifier.GetDifference(startDate, endDate);

DateTime startDateParsed = DateTime.Parse(startDate);
DateTime endDateParsed = DateTime.Parse(endDate);

Console.WriteLine(difference);
Console.WriteLine(startDateParsed - endDateParsed);