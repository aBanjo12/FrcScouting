using FrcScouting.JsonObjects.TeamYear;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace FrcScouting;

public class Comp
{
    public Comp(string key)
    {
        this.key = key;
        string[] teamids = BlueApiInterface.getTeams(key).Result.ParsedResponse;
        foreach (var teamId in teamids)
        {
            var team = StatboticsApiInterface.getTeam(int.Parse(teamId));
            if (team.Result.Result)
            {
                robots.Add((CompRobot)team.Result.ParsedResponse);
                Console.WriteLine("found team");
            }
        }

        Console.WriteLine("Comp finished");
}
    public List<CompRobot> robots = new List<CompRobot>();
    public string key { get; set; }
}