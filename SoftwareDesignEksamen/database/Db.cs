using Microsoft.Data.Sqlite;

namespace SoftwareDesignEksamen.database;

public class Db
{

    private string _dataBase;

    public Db(string dataBase)
    {
        _dataBase = dataBase;
    }
    public void CreateDbAndTable()
    {
        using SqliteConnection connection = new("Data Source = "+_dataBase+".db");
        connection.Open();

        SqliteCommand command = connection.CreateCommand();

        command.CommandText = @"
             CREATE TABLE IF NOT EXISTS leader_board (
               id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
               username TEXT UNIQUE NOT NULL,
               total_score INTEGER DEFAULT 0,
               highest_score INTEGER DEFAULT 0,
               games_played INTEGER DEFAULT 0,
               games_won INTEGER DEFAULT 0
             );          
         ";
        command.ExecuteNonQuery();
    }


    public void UpdateScoreBoard(string username, int score, bool winner)
    {
        if (!CheckIfUserExists(username))
        {
            AddNewScore(username, score, winner);
        }
        else
        {
            UpdateScore(username, score, winner);
        }
    }

    private bool CheckIfUserExists(string username)
    {
        using SqliteConnection connection = new("Data Source ="+_dataBase+".db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            SELECT * FROM leader_board WHERE username =$username
        ";
        command.Parameters.AddWithValue("$username", username);
        SqliteDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return true;
        }

        return false;
    }

    private void UpdateScore(string username, int score, bool winner)
    {
        using SqliteConnection connection = new("Data Source = "+_dataBase+".db");
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE leader_board SET total_score = total_score + $score, highest_score = MAX($score, highest_score), games_played = games_played + 1, games_won = games_won + $gameWon
            WHERE username = $username
        ";
        command.Parameters.AddWithValue("$score", score);
        command.Parameters.AddWithValue("$username", username);
        if (winner)
        {
            command.Parameters.AddWithValue("$gameWon", 1);
        }
        else
        {
            command.Parameters.AddWithValue("$gameWon", 0);
        }

        command.ExecuteNonQuery();
    }

    private void AddNewScore(string username, int score, bool winner)
    {
        using SqliteConnection connection = new("Data Source = "+_dataBase+".db");
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO leader_board (username, total_score, highest_score, games_won,games_played)
            VALUES ($username,$score,$score,$gamesWon,1);
        ";
        command.Parameters.AddWithValue("$username", username);
        command.Parameters.AddWithValue("$score", score);
        if (winner)
        {
            command.Parameters.AddWithValue("$gamesWon", 1);
        }
        else
        {
            command.Parameters.AddWithValue("$gamesWon", 0);
        }

        command.ExecuteNonQuery();
    }

    public List<HighScoreDto> GetLeaderBoard()
    {
        var leaderBoard = new List<HighScoreDto>();


        using SqliteConnection connection = new("Data Source = "+_dataBase+".db");
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
        SELECT * FROM leader_board ORDER BY highest_score DESC";

        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var dto = new HighScoreDto();
            dto.Username = reader.GetString(1);
            dto.TotalScore = reader.GetInt32(2);
            dto.HighestScore = reader.GetInt32(3);
            dto.GamesPlayed = reader.GetInt32(4);
            dto.GamesWon = reader.GetInt32(5);
            leaderBoard.Add(dto);
        }

        return leaderBoard;
    }
}