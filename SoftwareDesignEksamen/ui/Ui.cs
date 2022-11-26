using SoftwareDesignEksamen.database;

namespace SoftwareDesignEksamen.ui;

public class Ui : IUi
{
    
    private static Ui? _ui;

    #region Methods

    private Ui()
    {
    }

    public static Ui CreateInstance()
    {
        return _ui ??= new Ui();
    }


    public void PrintLeaderBoard(List<HighScoreDto> leaderBoard)
    {
        Message("                              Leader Board!", ConsoleColor.DarkBlue);
        Message("+-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=-=-=-+", ConsoleColor.DarkBlue);
        Message("|", ConsoleColor.DarkBlue, false);
        Message("   Username   | Total score | Highscore | Games played | Games won ", false);
        Message("|", ConsoleColor.DarkBlue);
        foreach (var highScore in leaderBoard)
        {
            string username = highScore.Username.PadRight(14).Substring(0, 14);
            string totalScore = highScore.TotalScore.ToString().PadLeft(13).Substring(0, 13);
            string highestScore = highScore.HighestScore.ToString().PadLeft(11).Substring(0, 11);
            string gamesPlayed = highScore.GamesPlayed.ToString().PadLeft(14).Substring(0, 14);
            string gamesWon = highScore.GamesWon.ToString().PadLeft(11).Substring(0, 11);
            Message("+--------------+-------------+-----------+--------------+-----------+");
            Message("|", ConsoleColor.DarkBlue, false);
            Message(username, false);
            Message("|", false);
            Message(totalScore, false);
            Message("|", false);
            Message(highestScore, false);
            Message("|", false);
            Message(gamesPlayed, false);
            Message("|", false);
            Message(gamesWon, false);
            Message("|", ConsoleColor.DarkBlue);

            /*Message(
                "|" + username +
                "|" + totalScore+
                "|" + highestScore +
                "|" + gamesPlayed +
                "|" + gamesWon + "|"
            );*/
        }

        Message("+-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=-=-=-+", ConsoleColor.DarkBlue);
    }

    public void PrintGameBoard()
    {
    }

    public int PrintStartMenu()
    {
        var alternatives = new List<string>()
        {
            "Start Game.",
            "Print Leaderboard."
        };
        Message("           Start Menu", ConsoleColor.DarkBlue);
        
        return PrintMultipleChoice(alternatives);
        
    }

    public int PrintMultipleChoice(List<string> questions)
    {
        Message("+-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=+", ConsoleColor.DarkBlue);
        for (var i = 0; i < questions.Count; i++)
        {
            var question = questions[i];
            Message($"{i + 1}. {question}");
        }

        Message("+-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=+", ConsoleColor.DarkBlue);
        while (true)
        {
            var readInt = ReadInt();
            if (readInt >= 1 && readInt < questions.Count + 1)
            {
                return readInt;
            }

            Message("Please enter a valid option");
        }
    }

    public int ReadInt()
    {
        var readString = ReadString();
        int.TryParse(readString, out var n);
        return n;
    }

    public string ReadString()
    {
        var readString = Console.ReadLine();
        return readString ?? "";
    }

    public bool ReadBoolean(string question, string yes, string no)
    {
        while (true)
        {
            var answer = AskQuestion(question + " " + yes + " / " + no).ToLower();
            if (answer == yes.ToLower())
            {
                return true;
            }

            if (answer == no.ToLower())
            {
                return false;
            }

            Message("Invalid Input");
        }
    }

    public string AskQuestion(string question)
    {
        Message(question);
        return ReadString();
    }

    public void PressToContinue()
    {
        Message("Press any key to continue",ConsoleColor.DarkMagenta);
        Console.ReadKey(true);
        Message("");
    }

    // Print message to console

    public void Message(string message, bool newLine = true)
    {
        if (newLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }
    }

    public void Message(string message, ConsoleColor color, bool newLine = true)
    {
        Console.ForegroundColor = color;
        Message(message, newLine);
        Console.ResetColor();
    }


    public void Clear()
    {
        Console.Clear();
    }

    #endregion
}