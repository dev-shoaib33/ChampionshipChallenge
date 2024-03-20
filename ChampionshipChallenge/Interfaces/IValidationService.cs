using ChampionshipChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipChallenge.Interfaces
{
    public interface IValidationService
    {
        List<Match> ReadMatchesFromFile(string filePath);
    }
}
