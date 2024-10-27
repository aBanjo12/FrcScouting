using System.ComponentModel.DataAnnotations;

namespace FrcScouting;

public class TeamData
{
    [Required]
    public bool underStage;
    [Required]
    public bool farFromSpeaker;
    [Required]
    public bool canShuttle;
    [Required]
    public bool canHarmonyClimb;
    [Required]
    public bool defense;
    [Required]
    public Speeds robotSpeed = Speeds.Average;
}

public enum Speeds
{
    Slow,
    Average,
    Fast
}