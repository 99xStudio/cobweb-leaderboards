using BepInEx;
using BepInEx.Logging;
using CWLB;
using HarmonyLib;
#pragma warning disable CS8618

namespace CWLB
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string ModName = "Cobweb Leaderboards";
        public const string ModAuthor  = "reddust9";
        public const string ModGuid = "com.cobwebsh.leaderboards";
        public const string ModVersion = "1.0.0";
        internal Harmony Harmony;
        internal void Awake()
        {
            Harmony = new Harmony(ModGuid);
            Harmony.PatchAll();
        }
    }
}
