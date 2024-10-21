using FrcScouting.JsonObjects.TeamYear;
using FrcScouting.JsonObjects.Year;
using Newtonsoft.Json;

namespace FrcScouting;

public static class ApiInterface
{
    public static Dictionary<int, Year> years = new Dictionary<int, Year>();
    public static async Task<TeamYear> getTeam(int teamNumber)
    {
        // Create an instance of HttpClient
        HttpClient client = new HttpClient();

        // Set the base address (optional)
        client.BaseAddress = new Uri("https://api.statbotics.io/");

        // Make the GET request
        HttpResponseMessage response = await client.GetAsync("v3/team_year/" + teamNumber + "/2024");

        // Check the response status code
        if (response.IsSuccessStatusCode)
        {
            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TeamYear>(responseBody);
        }

        return null;
    }
    
    public static async Task<Year> getYear(int year)
    {
        // Create an instance of HttpClient
        HttpClient client = new HttpClient();

        // Set the base address (optional)
        client.BaseAddress = new Uri("https://api.statbotics.io/");

        // Make the GET request
        HttpResponseMessage response = await client.GetAsync("v3/year/" + year);

        // Check the response status code
        if (response.IsSuccessStatusCode)
        {
            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return JsonConvert.DeserializeObject<Year>(responseBody);
        }

        return null;
    }

    public static async Task<TeamYear> get1014()
    {
        return await getTeam(1014);
    }
    
    
}