using ChampionshipChallenge.Interfaces;
using ChampionshipChallenge.Models;
using ChampionshipChallenge.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChampionshipChallenge
{
    public class Program
    {
        private static ILogger<Program> _logger;

        public Program(ILogger<Program> logger)
        {
            _logger = logger;
        }
        static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string filePath = configuration["FilePath"];

            try
            {
                var services = CreateServices();

                var validationService = services.GetRequiredService<IValidationService>();
                List<Match> matches = validationService.ReadMatchesFromFile(filePath);

                var championship = services.GetRequiredService<IChampionshipService>();
                championship.ProcessMatches(matches);
                championship.DisplayScores();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
            }
        }

        public static ServiceProvider CreateServices()
        {
            var serviceProvider = new ServiceCollection().
                AddLogging(options =>
                {
                    options.ClearProviders();
                    options.AddConsole();
                })
                .AddSingleton<IChampionshipService, ChampionshipService>()
                .AddSingleton<IValidationService, ValidationService>()
                .BuildServiceProvider();    

            return serviceProvider;
        }
    }
}
