// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

using System.Reflection;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace FrcScouting.JsonObjects.Year;

public class Year
{
    public int year { get; set; }
    public double score_mean { get; set; }
    public double score_sd { get; set; }
    public Percentiles percentiles { get; set; }
    public Breakdown breakdown { get; set; }
    public Metrics metrics { get; set; }
}

public class Percentiles
{
    public Total_points total_points { get; set; }
    public Auto_points auto_points { get; set; }
    public Teleop_points teleop_points { get; set; }
    public Endgame_points endgame_points { get; set; }
    public Melody_rp melody_rp { get; set; }
    public Harmony_rp harmony_rp { get; set; }
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
    
    public Dictionary<string, Percentile> getPoints()
    {
        Percentile[] mean_standards = GetType().GetProperties().Where(p => p.GetValue(this) != null).Select(p => p.GetValue(this) as Percentile).ToArray();
        
        object obj = this;
        PropertyInfo[] properties = obj.GetType().GetProperties();

        Dictionary<string, Percentile> result = new Dictionary<string, Percentile>();
        
        for (int i = 0; i < mean_standards.Length; i++)
        {
            result.Add(properties[i].Name, mean_standards[i]);
        }

        return result;
    }
}

public abstract class Percentile
{
    public double p99 { get; set; }
    public double p90 { get; set; }
    public double p75 { get; set; }
    public double p25 { get; set; }
}

public class Total_points : Percentile
{
}

public class Auto_points : Percentile
{
}

public class Teleop_points : Percentile
{
}

public class Endgame_points : Percentile
{
}

public class Melody_rp : Percentile
{
}

public class Harmony_rp : Percentile
{
}

public class Auto_leave_points : Percentile
{
}

public class Auto_notes : Percentile
{
}

public class Auto_note_points : Percentile
{
}

public class Teleop_notes : Percentile
{
}

public class Teleop_note_points : Percentile
{
}

public class Amp_notes : Percentile
{
}

public class Amp_points : Percentile
{
}

public class Speaker_notes : Percentile
{
}

public class Speaker_points : Percentile
{
}

public class Amplified_notes : Percentile
{
}

public class Total_notes : Percentile
{
}

public class Total_note_points : Percentile
{
}

public class Endgame_park_points : Percentile
{
}

public class Endgame_on_stage_points : Percentile
{
}

public class Endgame_harmony_points : Percentile
{
}

public class Endgame_trap_points : Percentile
{
}

public class Endgame_spotlight_points : Percentile
{
}

public class Rp_1 : Percentile
{
}

public class Rp_2 : Percentile
{
}

public class Breakdown
{
    public double total_points_mean { get; set; }
    public double foul_mean { get; set; }
    public double no_foul_mean { get; set; }
    public double auto_points_mean { get; set; }
    public double teleop_points_mean { get; set; }
    public double endgame_points_mean { get; set; }
    public double melody_rp_mean { get; set; }
    public double harmony_rp_mean { get; set; }
    public double tiebreaker_points_mean { get; set; }
    public double auto_leave_points_mean { get; set; }
    public double auto_notes_mean { get; set; }
    public double auto_note_points_mean { get; set; }
    public double teleop_notes_mean { get; set; }
    public double teleop_note_points_mean { get; set; }
    public double amp_notes_mean { get; set; }
    public double amp_points_mean { get; set; }
    public double speaker_notes_mean { get; set; }
    public double speaker_points_mean { get; set; }
    public double amplified_notes_mean { get; set; }
    public double total_notes_mean { get; set; }
    public double total_note_points_mean { get; set; }
    public double endgame_park_points_mean { get; set; }
    public double endgame_on_stage_points_mean { get; set; }
    public double endgame_harmony_points_mean { get; set; }
    public double endgame_trap_points_mean { get; set; }
    public double endgame_spotlight_points_mean { get; set; }
    public double rp_1_mean { get; set; }
    public double rp_2_mean { get; set; }
    
    public Dictionary<string, double> getPoints()
    {
        double?[] mean_standards = GetType().GetProperties().Where(p => p.GetValue(this) != null).Select(p => p.GetValue(this) as double?).ToArray();
        
        object obj = this;
        PropertyInfo[] properties = obj.GetType().GetProperties();

        Dictionary<string, double> result = new Dictionary<string, double>();
        
        for (int i = 0; i < mean_standards.Length; i++)
        {
            result.Add(properties[i].Name, mean_standards[i].Value);
        }

        return result;
    }
}

public class Metrics
{
    public Win_prob win_prob { get; set; }
    public Score_pred score_pred { get; set; }
    public Rp_pred rp_pred { get; set; }
}

public class Win_prob
{
    public Season season { get; set; }
    public Champs champs { get; set; }
}

public class Season
{
    public int count { get; set; }
    public double conf { get; set; }
    public double acc { get; set; }
    public double mse { get; set; }
}

public class Champs
{
    public int count { get; set; }
    public double conf { get; set; }
    public double acc { get; set; }
    public double mse { get; set; }
}

public class Score_pred
{
    public Season1 season { get; set; }
    public Champs1 champs { get; set; }
}

public class Season1
{
    public int count { get; set; }
    public double rmse { get; set; }
    public double mae { get; set; }
    public double error { get; set; }
}

public class Champs1
{
    public int count { get; set; }
    public double rmse { get; set; }
    public double mae { get; set; }
    public double error { get; set; }
}

public class Rp_pred
{
    public Season2 season { get; set; }
    public Champs2 champs { get; set; }
}

public class Season2
{
    public int count { get; set; }
    public Melody_rp1 melody_rp { get; set; }
    public Harmony_rp1 harmony_rp { get; set; }
}

public class Melody_rp1
{
    public double error { get; set; }
    public double acc { get; set; }
    public double ll { get; set; }
    public double f1 { get; set; }
}

public class Harmony_rp1
{
    public double error { get; set; }
    public double acc { get; set; }
    public double ll { get; set; }
    public double f1 { get; set; }
}

public class Champs2
{
    public int count { get; set; }
    public Melody_rp2 melody_rp { get; set; }
    public Harmony_rp2 harmony_rp { get; set; }
}

public class Melody_rp2
{
    public double error { get; set; }
    public double acc { get; set; }
    public double ll { get; set; }
    public double f1 { get; set; }
}

public class Harmony_rp2
{
    public double error { get; set; }
    public double acc { get; set; }
    public double ll { get; set; }
    public double f1 { get; set; }
}

