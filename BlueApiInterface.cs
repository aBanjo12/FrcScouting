using System.Net.Http.Headers;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Newtonsoft.Json;

namespace FrcScouting;

public static class BlueApiInterface
{
    public static HttpClient client = new HttpClient();
    static BlueApiInterface()
    {
        Console.WriteLine(File.ReadAllText("tbakey"));
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("X-TBA-Auth-Key", File.ReadAllText("tbakey"));
        client.BaseAddress = new Uri("https://www.thebluealliance.com/api/v3/");
        Console.WriteLine("BlueApiInterface initialized");
    }
    
    private static async Task<ApiRequest<T>> makeRequest<T>(string uri)
    {
        Console.WriteLine("requesting " + uri);
        // Make the GET request
        HttpResponseMessage response = await client.GetAsync(uri);
        
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("request for " + typeof(T) + " succeeded");
            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            return new ApiRequest<T>(JsonConvert.DeserializeObject<T>(responseBody), true);
        }

        Console.WriteLine("request for " + typeof(T) + " failed");
        return new ApiRequest<T>(JsonConvert.DeserializeObject<T>(""), false);
    }

    public static async Task<ApiRequest<string[]>> getTeams(string id)
    {
        Console.WriteLine("getting teams for " + id);
        return await makeRequest<string[]>($"/event/{id}/teams/keys");
    }
}