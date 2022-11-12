namespace CWLB;

public struct LeaderboardScore
{
    public string playerName;
    public int score;

    public LeaderboardScore(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}