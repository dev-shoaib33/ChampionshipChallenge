namespace ChampionshipChallenge;
public class Program
{
    static void Main()
    {
        List<string> matchList = File.ReadAllLines("Matches.txt").ToList();
        Dictionary<string, int> scoresDic = new Dictionary<string, int>();

        foreach (string match in matchList)
        {
            string[] matchScores = match.Split(',');
            string team1 = matchScores[0].Split()[0];
            string team2 = matchScores[1].Split()[0];
            int t1Score = int.Parse(matchScores[0].Split()[1]);
            int t2Score = int.Parse(matchScores[1].Split()[1]);

            if (t1Score > t2Score)
            {
                UpdateTeamScore(scoresDic, team1, 3);
                UpdateTeamScore(scoresDic, team2, 0);
            }
            else if (t1Score < t2Score)
            {
                UpdateTeamScore(scoresDic, team1, 0);
                UpdateTeamScore(scoresDic, team2, 3);
            }
            else
            {
                UpdateTeamScore(scoresDic, team1, 1);
                UpdateTeamScore(scoresDic, team2, 1);
            }
        }

        var sortedTeams = scoresDic.OrderByDescending(x => x.Value);

        foreach (var team in sortedTeams)
        {
            Console.WriteLine($"{team.Key}: {team.Value} points");
        }
    }

    static void UpdateTeamScore(Dictionary<string, int> teamScores, string team, int points)
    {
        if (teamScores.ContainsKey(team))
        {
            teamScores[team] += points;
        }
        else
        {
            teamScores[team] = points;
        }
    }
}
