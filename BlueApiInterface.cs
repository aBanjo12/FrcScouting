using System.Net.Http.Headers;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Newtonsoft.Json;

namespace FrcScouting;

public static class BlueApiInterface
{
    public static HttpClient client = new HttpClient();
    static BlueApiInterface()
    {
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("X-TBA-Auth-Key", File.ReadAllText("tbakey"));
        client.BaseAddress = new Uri("https://www.thebluealliance.com/api/v3/");

    }
    
    private static async Task<ApiRequest<T>> makeRequest<T>(string uri)
    {
        // Make the GET request
        HttpResponseMessage response = await client.GetAsync(uri);
        
        if (response.IsSuccessStatusCode)
        {
            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            return new ApiRequest<T>(JsonConvert.DeserializeObject<T>(responseBody), true);
        }

        Console.WriteLine("request for " + typeof(T) + " failed");
        return new ApiRequest<T>(JsonConvert.DeserializeObject<T>(""), false);
    }

    public static async Task<ApiRequest<string[]>> getTeams(string id)
    {
        return await makeRequest<string[]>($"event/{id}/teams/keys");
    }
}