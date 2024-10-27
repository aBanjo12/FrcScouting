using System.Security.Cryptography.Xml;
using FrcScouting.JsonObjects.TeamYear;
using FrcScouting.JsonObjects.Year;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using TBAAPI.V3Client.Model;

namespace FrcScouting;

public class Comp
{
    [JsonConstructor]
    public Comp(string key)
    {
        this.key = key;
        CompEvent = BlueApiInterface.Event.GetEvent(key);
        
        //cori teamlist
        numbers =
            "3201\n\n48\n\n695\n\n4028\n\n2399\n\n3324\n\n4467\n\n4269\n\n379\n\n677\n\n4611\n\n4150\n\n6834\n\n2252\n\n1014\n\n6964\n\n4601\n\n4121\n\n2603\n\n144\n\n325\n\n1787\n\n4145"
                .Split("\n\n");
        year = CompEvent.Year;
    }
    
    public async void populateTeamsDataAsync()
    {
        Console.WriteLine("fetching robots");
        var tasks = numbers.Select(i => StatboticsApiInterface.getTeam(int.Parse(i)));
        robots = (await Task.WhenAll(tasks)).Select(x => new CompRobot(x.ParsedResponse)).ToList();
        RankTeams();
        CompList.List.WriteToFile();
    }

    public async void RankTeams()
    {
        Console.WriteLine("ranking teams");
        if (robots == null)
            throw new Exception("robot list null");

        foreach (var robot in robots)
        {
            robot.teamMeanStandards = robot.TeamYear.epa.breakdown.getPoints();
        }

        var keys = robots[0].TeamYear.epa.breakdown.getPoints().Keys;
        foreach (string str in keys)
        {
            Console.WriteLine(str);
            try
            {
                double[] arr = robots.Select(x => x.teamMeanStandards[str].mean).ToArray();
                Array.Sort(arr);
                Ranks.Add(str, arr);
                
                Console.WriteLine(str);
            }
            catch (Exception e)
            {
                Console.WriteLine("not found");
            }
        }

        foreach (var robot in robots)
        {
            foreach (var str in keys)
            {
                Console.WriteLine(str + robot.TeamYear.name);
                robot.relativeRanks[str] = Array.IndexOf(Ranks[str], robot.teamMeanStandards[str].mean);
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