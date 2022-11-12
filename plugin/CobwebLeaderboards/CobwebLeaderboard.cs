using BepInEx;
using CWLB.Json;

namespace CWLB;

public class CobwebLeaderboard
{
    private string modGuid;
    private string modName;

    public static CobwebLeaderboard FromPlugin(object pluginInstance)
    {
        var t = pluginInstance.GetType();
        var a = (BepInPlugin)Attribute.GetCustomAttribute(t, typeof(BepInPlugin));
        return new CobwebLeaderboard(a.GUID, a.Name);
    }

    public CobwebLeaderboard(string modGuid, string modName)
    {
        this.modGuid = modGuid;
        this.modName = modName;
    }

    public void AddEntry(LeaderboardScore score)
    {
        this.AddEntry(score.playerName, score.score);
    }

    public void AddEntry(string playerName, int score)
    {
        API.AddToLeaderboard(this.modGuid, this.modName, playerName, score);
    }
}