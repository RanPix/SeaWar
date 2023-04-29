using System;

namespace SeaWar.Tools;

public static class IntExtention
{
    public static void Loop(this ref int n, int min, int max)
    {
        n = n > max ? min : 
            n < min ? max : n;
    }

    public static bool ValidateInt(this string str)
    {
        try
        {
            int.Parse(str);
            return false;
        }
        catch
        {
            return true;
        }
    }
}
