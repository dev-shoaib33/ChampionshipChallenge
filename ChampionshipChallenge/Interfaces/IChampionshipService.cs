using ChampionshipChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipChallenge.Interfaces
{
    public interface IChampionshipService
    {
        void ProcessMatches(List<Match> matches);
        Team GetOrCreateTeam(string teamName);
        void DisplayScores();
    }
}
