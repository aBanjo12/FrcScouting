using FrcScouting.JsonObjects.TeamYear;
using FrcScouting.JsonObjects.Year;
using Newtonsoft.Json;

namespace FrcScouting;

public static class StatboticsApiInterface
{
    public static async Task<ApiRequest<TeamYear>> getTeam(int teamNumber) 
    {
        Console.WriteLine("Making request");
        return await makeRequest<TeamYear>("v3/team_year/" + teamNumber + "/2024");
    }
    public static async Task<ApiRequest<Year>> getYear(int year)
    {
        return await makeRequest<Year>("v3/year/" + year);
    }

    private static async Task<ApiRequest<T>> makeRequest<T>(string uri)
    {
        // Create an instance of HttpClient
        HttpClient client = new HttpClient();

        // Set the base address (optional)
        client.BaseAddress = new Uri("https://api.statbotics.io/");

        Console.WriteLine("getting");

        // Make the GET request
        HttpResponseMessage response = await client.GetAsync(uri);
            
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("success");
            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            return new ApiRequest<T>(JsonConvert.DeserializeObject<T>(responseBody), true);
        }

        Console.WriteLine("request for " + typeof(T) + " failed");
        return new ApiRequest<T>(JsonConvert.DeserializeObject<T>(""), false);
    }

    public static async Task<ApiRequest<TeamYear>> get1014()
    {
        return await getTeam(1014);
    }
}