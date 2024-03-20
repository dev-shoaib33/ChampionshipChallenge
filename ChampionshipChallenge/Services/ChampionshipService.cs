using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionshipChallenge.Interfaces;
using ChampionshipChallenge.Models;
using Microsoft.Extensions.Logging;

namespace ChampionshipChallenge.Services
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly ILogger<ChampionshipService> _logger;

        public ChampionshipService(ILogger<ChampionshipService> logger)
        {
            _logger = logger;
        }

        private List<Team> teams = new List<Team>();
        public void ProcessMatches(List<Match> matches)
        {
            foreach (var match in matches)
            {
                var team1 = GetOrCreateTeam(match.Team1Name);
                var team2 = GetOrCreateTeam(match.Team2Name);

                if (match.Team1Wins())
                {
                    team1.AddPoints(3);
                }
                else if (match.Team2Wins())
                {
                    team2.AddPoints(3);
                }
                else // Tie
                {
                    team1.AddPoints(1);
                    team2.AddPoints(1);
                }
            }
        }
        public Team GetOrCreateTeam(string teamName)
        {
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                team = new Team(teamName);
                teams.Add(team);
            }
            return team;
        }

        public void DisplayScores()
        {
            var sortedTeams = teams.OrderByDescending(t => t.Points);
            foreach (var team in sortedTeams)
            {
                Console.WriteLine($"{team.Name}: {team.Points} points");
            }
        }
    }
}
