using FrcScouting.JsonObjects.TeamYear;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using TBAAPI.V3Client.Model;

namespace FrcScouting;

public class Comp
{
    public Comp(string key)
    {
        this.key = key;
        CompEvent = BlueApiInterface.Event.GetEvent(key);
        numbers = BlueApiInterface.Event.GetEventTeamsKeys(key).ToArray();
    }

    public async void populateTeamsDataAsync()
    {
        Console.WriteLine("fetching robots");
        var tasks = numbers.Select(i => StatboticsApiInterface.getTeam(int.Parse(i.Substring(3))));
        robots = (await Task.WhenAll(tasks)).Select(x => new CompRobot(x.ParsedResponse)).ToList();
        RankTeams();
        CompList.List.WriteToFile();
    }

    public async void RankTeams()
    {
        if (robots == null)
            throw new Exception("robot list null");
        foreach (string str in robots[0].teamMeanStandards.Keys)
        {
            Ranks.Add(str, robots.Select(x => x.teamMeanStandards[str].mean).ToArray());
        }

        foreach (var robot in robots)
        {
            foreach (var str in Ranks.Keys)
            {
                robot.relativeRanks[str] = Array.IndexOf(Ranks[str], robot.teamMeanStandards[str]);
            }
        }
    }

    public Dictionary<string, double[]> Ranks = new Dictionary<string, double[]>();
    public string[] numbers;
    public Event CompEvent;
    public List<CompRobot>? robots;
    public string key { get; set; }
}