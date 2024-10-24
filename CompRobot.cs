using FrcScouting.JsonObjects.TeamYear;

namespace FrcScouting;

public class CompRobot(TeamYear teamYear)
{
    public TeamYear TeamYear = teamYear;
    public List<string> Comments = new List<string>();
}