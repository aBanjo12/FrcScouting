using System.Runtime.InteropServices.Marshalling;
using Newtonsoft.Json;

namespace FrcScouting;

public class CompList : Dictionary<string, Comp>
{
    static string dir = Directory.GetCurrentDirectory();
    public static CompList List;

    static CompList()
    {
        Console.WriteLine(dir);
        if (File.Exists(dir + "/comps.json"))
        {
            List = JsonConvert.DeserializeObject<CompList>(File.ReadAllText(dir + "/comps.json"));
            return;
        }
        List = new CompList();
        List.WriteToFile();
    }
    
    public static CompList CompsFromFile()
    {
        if (File.Exists(dir + "/comps.json"))
            return JsonConvert.DeserializeObject<CompList>(File.ReadAllText(dir + "/comps.json"));
        return new CompList();
    }

    public void WriteToFile()
    {
        File.WriteAllText(dir + "/comps.json", JsonConvert.SerializeObject(this));
    }

    public void Add(string id, Comp comp)
    {
        base.Add(id, comp);
        WriteToFile();
    }
}