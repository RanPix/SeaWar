using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SeaWar;

public class Renderer
{
    private char[,] screenBuffer = new char[0, 0];

    #region DLL
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    private static IntPtr Screen;

    private void SetupDLL()
    {
        var handle = GetStdHandle(-11);
        int mode;
        GetConsoleMode(handle, out mode);
        SetConsoleMode(handle, mode | 0x4);
    }
    #endregion

    public void Start()
    {
        SetupDLL();

        Console.CursorVisible = false;
    }

    public void Draw(Tiles[,] tileMap)
    {
        int xLength = tileMap.GetLength(0);
        int yLength = tileMap.GetLength(1);

        StringBuilder screenBuffer = new StringBuilder();

        Console.SetCursorPosition(0, 0);

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                screenBuffer.Append(GetTileGraphic(tileMap[x, y]));
            }
            screenBuffer.Append('\n');
        }

        Console.Write(screenBuffer);
    }

    private string GetTileGraphic(Tiles tile)
        => tile switch
        {
            Tiles.Water => Color(30, 30, 200) + '~',
            Tiles.Ship => Color(200, 200, 200) + '#',
            Tiles.Occupied => Color(30, 30, 200) + '~',
            Tiles.DestroyedShip => Color(155, 30, 30) + 'x',
            Tiles.MissedShot => Color(100, 100, 100) + 'o',

            _ => "n"
        };

    private string Color(byte r, byte g, byte b)
        => $"\x1b[38;2;{r};{g};{b}m";
}
