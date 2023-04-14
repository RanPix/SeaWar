using System;

namespace SeaWar.Tools;

public static class IntExtention
{
    public static void Loop(this ref int n, int min, int max)
    {
        n = n > max ? min : 
            n < min ? max : n;
    }
}
