using System;
using System.Threading.Tasks;
using Client;

var httpClientHandler = new MyHttpClientHandler();

Console.WriteLine("Task 1:");
string myNameResponse = await httpClientHandler.GetMyNameAsync();
Console.WriteLine(myNameResponse);
Console.WriteLine();

Console.WriteLine("Task 2:");
string informationResponse = await httpClientHandler.GetInformationAsync();
Console.WriteLine(informationResponse);
Console.WriteLine();

Console.WriteLine("Task 3:");
string successStatusCode = await httpClientHandler.GetStatusCodeAsync("Success");
Console.WriteLine(successStatusCode);
Console.WriteLine();

Console.WriteLine("Task 3:");
string redirectionStatusCode = await httpClientHandler.GetStatusCodeAsync("Redirection");
Console.WriteLine(redirectionStatusCode);
Console.WriteLine();

Console.WriteLine("Task 3:");
string clientErrorStatusCode = await httpClientHandler.GetStatusCodeAsync("ClientError");
Console.WriteLine(clientErrorStatusCode);
Console.WriteLine();

Console.WriteLine("Task 3:");
string serverErrorStatusCode = await httpClientHandler.GetStatusCodeAsync("ServerError");
Console.WriteLine(serverErrorStatusCode);
Console.WriteLine();

Console.WriteLine("Task 4:");
string nameFromHeader = await httpClientHandler.GetNameFromHeaderAsync();
Console.WriteLine(nameFromHeader);
Console.WriteLine();

Console.WriteLine("Task 5:");
string nameFromCookie = await httpClientHandler.GetNameFromCookieAsync();
Console.WriteLine(nameFromCookie);
Console.WriteLine();
 