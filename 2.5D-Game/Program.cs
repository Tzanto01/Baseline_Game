namespace Core;

public static class Program
{
    public static CoreGame Game;
    public static void Main(string[] args)
    {
        Game = new CoreGame();
        Game.Run();
        Game.Dispose();
    }
}