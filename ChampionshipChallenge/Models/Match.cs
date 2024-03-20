using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipChallenge.Models
{
    public class Match
    {
        public string Team1Name { get; }
        public string Team2Name { get; }
        public int Team1Score { get; }
        public int Team2Score { get; }

        public Match(string team1Name, string team2Name, int team1Score, int team2Score)
        {
            Team1Name = team1Name;
            Team2Name = team2Name;
            Team1Score = team1Score;
            Team2Score = team2Score;
        }

        public bool IsTie() => Team1Score == Team2Score;
        public bool Team1Wins() => Team1Score > Team2Score;
        public bool Team2Wins() => Team2Score > Team1Score;
    }

}
