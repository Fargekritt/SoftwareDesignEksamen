namespace SoftwareDesignEksamen.ui;

public class Ui
{
    public int FontSize { get; set; }
    public ConsoleColor Color { get; set; }

    #region Methods

    public void PrintGameBoard()
    {
    }

    public void PrintStartMenu()
    {
    }

    public int PrintMultipleChoice(List<string> questions)
    {
        for (var i = 0; i < questions.Count; i++)
        {
            var question = questions[i];
            Message($"{i+1}. {question}");
        }

        while (true)
        {
            var readInt = ReadInt();
            if (readInt > 1 && readInt < questions.Count+1)
            {
                return readInt;
            }
            Message("Please enter a valid option");
        }

        return -1;
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

    public bool ReadBoolean(string question,string yes, string no)
    {
        while (true)
        {
            var answer = AskQuestion(question);
            if (answer == yes)
            {
                return true;
            }
            if (answer == no)
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

    // Print message to console

    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    #endregion
}