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
        foreach (var teamId in )
    }
    public List<CompRobot> robots = new List<CompRobot>();
    public string key { get; set; }
}