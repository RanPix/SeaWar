using System;

namespace SeaWar;

public class Input
{
    public static ConsoleKey? latestInput;

    public void GetInput()
    {
        if (latestInput != null)
            latestInput = null;

        if (!Console.KeyAvailable)
            return;

        latestInput = Console.ReadKey().Key;
    }
}
