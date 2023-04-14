using System;

namespace SeaWar.Tools;

public static class Rand
{
    public static int Next(int min, int max)
        => new Random().Next(min, max);
}
