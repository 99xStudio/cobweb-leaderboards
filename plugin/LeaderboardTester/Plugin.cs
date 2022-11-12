using BepInEx;
using CWLB;

namespace LeaderboardTester
{
    [BepInPlugin("com.reddust9.cwlb_tester", "Cobweb Leaderboard tester", "1.0.0")]
    [BepInDependency("com.cobwebsh.leaderboards")]
    public class Plugin : BaseUnityPlugin
    {
        internal CobwebLeaderboard leaderboard;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            leaderboard = CobwebLeaderboard.FromPlugin(this); 
            leaderboard.AddEntry("test1", 1);
            leaderboard.AddEntry(new LeaderboardScore("test2", 2));
        }
    }
}