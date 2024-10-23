using FrcScouting.JsonObjects.TeamYear;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace FrcScouting;

public class Comp
{
    public Comp(string key)
    {
        this.key = key;
        numbers = BlueApiInterface.Event.GetEventTeamsKeys(key).ToArray();
    }

    public async void populateTeamsDataAsync()
    {
        var tasks = numbers.Select(i => StatboticsApiInterface.getTeam(int.Parse(i.Substring(3))));
        var results = await Task.WhenAll(tasks);
    }
    public string[] numbers;
    public List<ApiRequest<TeamYear>> TeamRequests = new();
    
    public List<CompRobot> robots = new List<CompRobot>();
    public string key { get; set; }
}