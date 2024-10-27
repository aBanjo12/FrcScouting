using FrcScouting.JsonObjects.TeamYear;
using FrcScouting.JsonObjects.Year;

namespace FrcScouting;

public class CompRobot(TeamYear teamYear)
{
    public TeamYear TeamYear = teamYear;
    public List<string> Comments = new List<string>();
    public Dictionary<string, int> relativeRanks = new();
    public Dictionary<string, Mean_Standard> teamMeanStandards = new();
    public List<TeamData> teamData = new();
}