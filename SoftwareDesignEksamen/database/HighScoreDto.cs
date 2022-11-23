namespace SoftwareDesignEksamen.database;

public class HighScoreDto
{
    public string? Username { get; set; }
    public int TotalScore { get; set; }
    public int HighestScore { get; set; }
    public int GamesPlayed { get; set; }
    public int GamesWon { get; set; }
}