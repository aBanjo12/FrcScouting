// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.Reflection;

namespace FrcScouting.JsonObjects.TeamYear;

public class TeamYear
{
    public string team { get; set; }
    public int year { get; set; }
    public string name { get; set; }
    public string country { get; set; }
    public string state { get; set; }
    public object district { get; set; }
    public bool offseason { get; set; }
    public Epa epa { get; set; }
    public Record record { get; set; }
    public object district_points { get; set; }
    public object district_rank { get; set; }
    public Competing competing { get; set; }
}

public class Epa
{
    public Total_points total_points { get; set; }
    public double unitless { get; set; }
    public double norm { get; set; }
    public double[] conf { get; set; }
    public Breakdown breakdown { get; set; }
    public Stats stats { get; set; }
    public Ranks ranks { get; set; }
}

public class Total_points
{
    public double mean { get; set; }
    public double sd { get; set; }
}

public class Breakdown
{
    public Total_points1 total_points { get; set; }
    public Auto_points auto_points { get; set; }
    public Teleop_points teleop_points { get; set; }
    public Endgame_points endgame_points { get; set; }
    public Melody_rp melody_rp { get; set; }
    public Harmony_rp harmony_rp { get; set; }
    public Tiebreaker_points tiebreaker_points { get; set; }
    public Auto_leave_points auto_leave_points { get; set; }
    public Auto_notes auto_notes { get; set; }
    public Auto_note_points auto_note_points { get; set; }
    public Teleop_notes teleop_notes { get; set; }
    public Teleop_note_points teleop_note_points { get; set; }
    public Amp_notes amp_notes { get; set; }
    public Amp_points amp_points { get; set; }
    public Speaker_notes speaker_notes { get; set; }
    public Speaker_points speaker_points { get; set; }
    public Amplified_notes amplified_notes { get; set; }
    public Total_notes total_notes { get; set; }
    public Total_note_points total_note_points { get; set; }
    public Endgame_park_points endgame_park_points { get; set; }
    public Endgame_on_stage_points endgame_on_stage_points { get; set; }
    public Endgame_harmony_points endgame_harmony_points { get; set; }
    public Endgame_trap_points endgame_trap_points { get; set; }
    public Endgame_spotlight_points endgame_spotlight_points { get; set; }
    public Rp_1 rp_1 { get; set; }
    public Rp_2 rp_2 { get; set; }

    public Dictionary<string, Mean_Standard> getPoints()
    {
        Mean_Standard?[] mean_standards = GetType().GetProperties().Where(p => p.GetValue(this) != null).Select(p => p.GetValue(this) as Mean_Standard).ToArray();
        
        object obj = this;
        PropertyInfo[] properties = obj.GetType().GetProperties();

        Dictionary<string, Mean_Standard> result = new Dictionary<string, Mean_Standard>();
        
        for (int i = 0; i < mean_standards.Length; i++)
        {
            result.Add(properties[i].Name, mean_standards[i]);
        }

        Console.WriteLine(result.Count + " " + mean_standards.Length + " " + this.GetType().GetProperties().Length);
        return result;
    }
}

public class Mean_Standard
{
    public double mean { get; set; }
    public double sd { get; set; }
}

public class Total_points1 : Mean_Standard
{
}

public class Auto_points : Mean_Standard
{
}

public class Teleop_points : Mean_Standard
{
}

public class Endgame_points : Mean_Standard
{
}

public class Melody_rp : Mean_Standard
{
}

public class Harmony_rp : Mean_Standard
{
}

public class Tiebreaker_points : Mean_Standard
{
}

public class Auto_leave_points : Mean_Standard
{
}

public class Auto_notes : Mean_Standard
{
}

public class Auto_note_points : Mean_Standard
{
}

public class Teleop_notes : Mean_Standard
{
}

public class Teleop_note_points : Mean_Standard
{
}

public class Amp_notes : Mean_Standard
{
}

public class Amp_points : Mean_Standard
{
}

public class Speaker_notes : Mean_Standard
{
}

public class Speaker_points : Mean_Standard
{
}

public class Amplified_notes : Mean_Standard
{
}

public class Total_notes : Mean_Standard
{
}

public class Total_note_points : Mean_Standard
{
}

public class Endgame_park_points : Mean_Standard
{
}

public class Endgame_on_stage_points : Mean_Standard
{
}

public class Endgame_harmony_points : Mean_Standard
{
}

public class Endgame_trap_points : Mean_Standard
{
}

public class Endgame_spotlight_points : Mean_Standard
{
}

public class Rp_1 : Mean_Standard
{
}

public class Rp_2 : Mean_Standard
{
}

public class Stats
{
    public double start { get; set; }
    public double pre_champs { get; set; }
    public double max { get; set; }
}

public class Ranks
{
    public Total total { get; set; }
    public Country country { get; set; }
    public State state { get; set; }
    public District district { get; set; }
}

public class Total
{
    public int rank { get; set; }
    public double percentile { get; set; }
    public int team_count { get; set; }
}

public class Country
{
    public int rank { get; set; }
    public double percentile { get; set; }
    public int team_count { get; set; }
}

public class State
{
    public int rank { get; set; }
    public double percentile { get; set; }
    public int team_count { get; set; }
}

public class District
{
    public int rank { get; set; }
    public double percentile { get; set; }
    public int team_count { get; set; }
}

public class Record
{
    public Season season { get; set; }
    public Full full { get; set; }
}

public class Season
{
    public int wins { get; set; }
    public int losses { get; set; }
    public int ties { get; set; }
    public int count { get; set; }
    public double winrate { get; set; }
}

public class Full
{
    public int wins { get; set; }
    public int losses { get; set; }
    public int ties { get; set; }
    public int count { get; set; }
    public double winrate { get; set; }
}

public class Competing
{
    public bool this_week { get; set; }
    public object next_event_key { get; set; }
    public object next_event_name { get; set; }
    public object next_event_week { get; set; }
}