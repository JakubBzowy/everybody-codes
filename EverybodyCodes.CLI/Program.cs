// See https://aka.ms/new-console-template for more information
using EverybodyCodes.Application.Cameras;
using EverybodyCodes.Infrastructure.Repositories;

var csvFilePath = "../EverybodyCodes.Data/cameras-defb.csv";
var cameraRepository = new CamerasRepository(csvFilePath);
var cameraService = new CamerasService(cameraRepository);

if (args.Length == 2 && args[0] == "--name")
{
    var name = args[1];
    var searchResult = await cameraService.SearchForCamerasByNameAsync(name);

    if (searchResult.Count() > 0)
    {
        foreach (var result in searchResult)
        {
            Console.WriteLine($"{result.Number} | {result.Name} | {result.Latitude} | {result.Longitude}");
        }
    }
    else
    {
        Console.WriteLine($"Nothing found for name {name}.");
    }
}
else
{
    Console.WriteLine(@"Incorrect parameters were specified. Please provide the parameters according to the example ""dotnet Search --name Neude"".");
}