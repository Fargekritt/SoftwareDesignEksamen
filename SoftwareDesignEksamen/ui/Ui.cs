namespace SoftwareDesignEksamen.ui;

public class Ui
{
    public string ReadString()
    {
        return Console.ReadLine();
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
}