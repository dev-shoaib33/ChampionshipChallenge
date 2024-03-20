using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipChallenge.Models
{
    public class Team
    {
        public string Name { get; }
        public int Points { get; private set; }

        public Team(string name)
        {
            Name = name;
        }

        public void AddPoints(int points)
        {
            Points += points;
        }
    }
}
