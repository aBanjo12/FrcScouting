using FrcScouting.JsonObjects.TeamYear;

namespace FrcScouting;

public class Comp
{
    public static List<Comp> Comps = new();
    
    public List<CompRobot> robots = new List<CompRobot>();
    public string id { get; set; }
    public string key { get; set; }
}