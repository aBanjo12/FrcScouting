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
        CompList.List.WriteToFile();
    }

    public string[] numbers;
    public Event CompEvent;
    public List<CompRobot>? robots;
    public string key { get; set; }
}