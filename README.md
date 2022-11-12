# cobweb-leaderboards
### A replacement leaderboard for SpiderHeck mods to use

[![Netlify Status](https://api.netlify.com/api/v1/badges/8a7abced-3976-4d92-9386-d4cde059b910/deploy-status)](https://app.netlify.com/sites/cobweb-leaderboards/deploys)

### Usage

Add a dependency in your mod class:
```cs
[BepInDependency("com.cobwebsh.leaderboards")]
public class Mod : BaseUnityPlugin {
```

Initialize leaderboards for your mod automatically:
```cs
var leaderboard = CobwebLeaderboard.FromPlugin(this);
```
using the BepInPlugin attribute, or manually with a GUID and name:
```cs
var leaderboard = new CobwebLeaderboard("com.reddust9.testmod", "Test Mod");
```

Add leaderboard entries using the AddEntry method:
```cs
leaderboard.AddEntry("player1", 1);

var score = new LeaderboardScore("player2",  2);
leaderboard.AddEntry(score);
```

### View the leaderboards at [cobweb-leaderboards.netlify.app](https://cobweb-leaderboards.netlify.app)
