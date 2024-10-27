using System.ComponentModel.DataAnnotations;

namespace FrcScouting;

public class TeamData(bool under, bool speaker, bool shuttle, bool climb, bool def, Speeds robotspeed)
{
    [Required]
    public bool underStage = under;
    [Required]
    public bool farFromSpeaker = speaker;
    [Required]
    public bool canShuttle = shuttle;
    [Required]
    public bool canHarmonyClimb = climb;
    [Required]
    public bool defense = def;
    [Required]
    public Speeds robotSpeed = robotspeed;
}

public enum Speeds
{
    Slow,
    Average,
    Fast
}