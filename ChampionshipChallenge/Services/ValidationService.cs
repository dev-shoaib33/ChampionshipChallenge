using ChampionshipChallenge.Interfaces;
using ChampionshipChallenge.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipChallenge.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ILogger<ValidationService> _logger;

        public ValidationService(ILogger<ValidationService> logger)
        {
            _logger = logger;
        }

        public  List<Match> ReadMatchesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                _logger.LogError("File does not exist");
                throw new FileNotFoundException("File not found.", filePath);
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0 || string.IsNullOrWhiteSpace(lines[0]))
            {
                _logger.LogError("File is empty");
                throw new InvalidDataException("File is empty.");
            }

            List<Match> matches = new List<Match>();

            foreach (string line in lines)
            {
                string[] matchScores = line.Split(',');
                if (matchScores.Length != 2)
                {
                    _logger.LogError("Invalid format in file.");
                    throw new InvalidDataException("Invalid format in file.");
                }

                string team1Name = matchScores[0].Split()[0];
                string team2Name = matchScores[1].Split()[0];
                int team1Score = int.Parse(matchScores[0].Split()[1]);
                int team2Score = int.Parse(matchScores[1].Split()[1]);

                Match match = new Match(team1Name, team2Name, team1Score, team2Score);
                matches.Add(match);
            }

            return matches;
        }
    }
}
