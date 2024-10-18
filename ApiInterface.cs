using FrcScouting.JsonObjects.TeamYear;
using Newtonsoft.Json;

namespace FrcScouting;

public static class ApiInterface
{
    public static async Task<TeamYear> get1014()
    {
        // Create an instance of HttpClient
        HttpClient client = new HttpClient();

        // Set the base address (optional)
        client.BaseAddress = new Uri("https://api.statbotics.io/");

        // Make the GET request
        HttpResponseMessage response = await client.GetAsync("v3/team_year/1014/2024");

        // Check the response status code
        if (response.IsSuccessStatusCode)
        {
            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return JsonConvert.DeserializeObject<TeamYear>(responseBody);
        }

        return null;
    }
}