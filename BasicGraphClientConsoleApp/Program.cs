// See https://aka.ms/new-console-template for more information
using BasicGraphClientConsoleApp;

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("Some basic implementation of the Graph Client.");
Console.WriteLine("It uses application authorized access to the Graph API.");

var graphClient = GraphClientFactory.GetGraphClient();
var users = await graphClient.Users.GetAsync();

if (users == null || users.Value == null)
{
    Console.WriteLine("There is a null reference. WTF!");
    return;
}

Console.WriteLine($"Found {users.Value.Count} Users!");

foreach (var user in users.Value)
{
    Console.WriteLine(user.DisplayName);
}

Console.ReadLine();