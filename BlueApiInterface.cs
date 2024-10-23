using System.Net.Http.Headers;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Newtonsoft.Json;
using TBAAPI.V3Client.Api;
using TBAAPI.V3Client.Client;
using TBAAPI.V3Client.Model;

namespace FrcScouting;

public static class BlueApiInterface
{
    public static EventApi Event;
    public static MatchApi Match;
    public static TeamApi Team;
    public static DistrictApi District;
    public static ListApi List;
    static BlueApiInterface()
    {
        Configuration config = new Configuration();
        config.BasePath = "https://www.thebluealliance.com/api/v3";
        config.ApiKey.Add("X-TBA-Auth-Key", File.ReadAllText("tbakey"));
        
        Event = new EventApi(config);
        Match = new MatchApi(config);
        Team = new TeamApi(config);
        District = new DistrictApi(config);
        List = new ListApi(config);
    }
}