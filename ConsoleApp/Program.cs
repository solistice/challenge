using Domain;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Application.Queries;
using MediatR;
using Application;

namespace ConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide the file path");
            return;
        }

        var filePath = args[0];

        if (args.Length < 2 || !Int32.TryParse(args[1], out var targetLength))
            targetLength = 6; // Default value

        if (args.Length != 3 || !Int32.TryParse(args[2], out var maxCombinations))
            maxCombinations = 6; // Default value

        var serviceProvider = new ServiceCollection()
            .AddTransient<IWordRepository, WordFileReader>()
            .AddSingleton(new ChallengeOptions { FilePath = filePath })
            .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(FindAllMatchesQuery).Assembly))
            .BuildServiceProvider();

        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var allMatches = await mediator.Send(new FindAllMatchesQuery(targetLength, maxCombinations));

        foreach (var match in allMatches)
            Console.WriteLine(match);
    }
}
