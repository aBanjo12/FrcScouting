using FrcScouting.JsonObjects.Year;

namespace FrcScouting;

public static class YearData
{
    public static Dictionary<int, Year> Years = new Dictionary<int, Year>();

    public static async Task<Year> getYear(int year)
    {
        ApiRequest<Year> apiYear = await StatboticsApiInterface.getYear(2024);
        if (!apiYear.Result)
        {
            return null;
        }
        Years.Add(2024, apiYear.ParsedResponse);
        return Years[2024];
    }
}