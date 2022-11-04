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

    public int PrintultipleChoice()
    {
        return -1;
    }

    public int ReadInt()
    {
        return -1;
    }

    public string ReadString()
    {
        return Console.ReadLine();
    }

    public bool ReadBoolean()
    {
        return false;
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