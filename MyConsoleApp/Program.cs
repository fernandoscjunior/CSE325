Console.WriteLine("Hello, World!");
Console.WriteLine($"The current time is {DateTime.Now} ");

DateTime christmas = new(DateTime.Now.Year, 12, 25);
DateTime today = DateTime.Now;
TimeSpan daysLeft = christmas - today;
double result = daysLeft.TotalDays;

Console.WriteLine($"There are {Math.Round(result)} days until the next Christmas.");