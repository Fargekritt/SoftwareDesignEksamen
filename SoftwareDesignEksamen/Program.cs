// See https://aka.ms/new-console-template for more information
using SoftwareDesignEksamen.gameManager;

namespace SoftwareDesignEksamen;

internal static class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new();
        gameManager.StartGame();
        
        
    }
}