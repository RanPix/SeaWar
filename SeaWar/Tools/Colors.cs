using System;

namespace SeaWar.Tools;

public static class Colors
{
    public static string GetColor(byte r, byte g, byte b)
        => $"\x1b[38;2;{r};{g};{b}m";

    public static string GetBGColor(byte r, byte g, byte b)
        => $"\x1b[48;2;{r};{g};{b}m";
}
