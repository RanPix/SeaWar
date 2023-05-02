namespace SeaWarLauncher;

public struct GameConfig
{
    public string profile1;
    public string profile2;

    public int gameMode;
    public int botDifficulty;

    public GameConfig(string profile1, string profile2, int gameMode, int botDifficulty)
    {
        this.profile1 = profile1;
        this.profile2 = profile2;

        this.gameMode = gameMode;
        this.botDifficulty = botDifficulty;
    }
}
