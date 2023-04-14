namespace SeaWar.Core;

public class Input
{
    public static ConsoleKey? latestInput;

    public static void UpdateInput()
    {
        latestInput = null;

        if (!Console.KeyAvailable)
            return;

        latestInput = Console.ReadKey(true).Key;
    }

    public static (int dx, int dy) GetMovementInput()
    {   
        int dx = latestInput == ConsoleKey.A ? -1 :
                 latestInput == ConsoleKey.D ? 1 : 0;

        int dy = latestInput == ConsoleKey.W ? -1 :
                 latestInput == ConsoleKey.S ? 1 : 0;

        return (dx, dy);
    }

    public static bool GetShootInput()
        => latestInput == ConsoleKey.T;

    public static bool GetNextPlayerReadyInput()
        => latestInput == ConsoleKey.R;
}
