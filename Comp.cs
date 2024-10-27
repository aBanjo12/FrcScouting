using System.Security.Cryptography.Xml;
using FrcScouting.JsonObjects.TeamYear;
using FrcScouting.JsonObjects.Year;
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
        year = CompEvent.Year;
    }

    public Comp(string[] numbers, int year)
    {
        isTeamList = true;
        this.numbers = numbers;
        this.year = year;
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
        Console.WriteLine("ranking teams");
        if (robots == null)
            throw new Exception("robot list null");

        Year yearObj;
        if (!YearData.Years.TryGetValue(CompEvent.Year, out yearObj))
        {
            yearObj = await YearData.getYear(2024);
        }

        var keys = yearObj.breakdown.getPoints().Keys;
        foreach (string str in keys)
        {
            Ranks.Add(str, robots.Select(x => x.teamMeanStandards[str].mean).ToArray());
        }

        foreach (var robot in robots)
        {
            foreach (var str in keys)
            {
                Console.WriteLine(str + robot.TeamYear.name);
                robot.relativeRanks[str] = Array.IndexOf(Ranks[str], robot.teamMeanStandards[str]);
            }
        }
        Console.WriteLine("ranking teams complete " + robots.Count + " teams" + keys.Count);
    }

    public int year;
    public bool isTeamList = false;
    public Dictionary<string, double[]> Ranks = new Dictionary<string, double[]>();
    public string[] numbers;
    public Event CompEvent;
    public List<CompRobot>? robots;
    public string key { get; set; }
}