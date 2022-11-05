// See https://aka.ms/new-console-template for more information

using Example;

var pagedModelExample = new PagedModelExample();
await pagedModelExample.RunAsync();

var timeZoneTest = new TimeZoneTest();
timeZoneTest.OnWindows();

Console.WriteLine("Hit a ENTER (or RETURN) key to exit.");
Console.ReadLine();
