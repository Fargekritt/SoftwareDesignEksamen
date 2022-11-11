using Microsoft.Data.Sqlite;

namespace SoftwareDesignEksamen.database;

public class Db
{
    public void CreateDbAndTable()
    {
        using SqliteConnection connection = new("Data Source = exampleSqlite.db");
        connection.Open();

         SqliteCommand command = connection.CreateCommand();
         
         command.CommandText = @"
             CREATE TABLE IF NOT EXISTS leader_board (
               id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
               username TEXT NOT NULL,
               total_score INTEGER DEFAULT 0,
               highest_score INTEGER DEFAULT 0,
               games_played INTEGER DEFAULT 0,
               games_won INTEGER DEFAULT 0
             );          
         ";
         command.ExecuteNonQuery();
    }
    
    public int InsertUser(string name)
    {
        int generatedId = -1;

        using SqliteConnection connection = new("Data Source = exampleSqlite.db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
				INSERT INTO user (name)
				VALUES ($name);
			";
        command.Parameters.AddWithValue("$name", name);
        command.ExecuteNonQuery();
        command.CommandText = @"
				SELECT seq
				FROM sqlite_sequence
				WHERE name = 'user';
			";
        using SqliteDataReader reader = command.ExecuteReader();
        if (reader.Read()) {
            generatedId = reader.GetInt32(0);
        }

        return generatedId;
    }
}