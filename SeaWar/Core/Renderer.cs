using SeaWar.Tools;
using System.Runtime.InteropServices;
using System.Text;
using SeaWar.Enums;

namespace SeaWar.Core;

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

    public void Draw(int yRenderOffset, Tiles[,] tileMap, (int cursorX, int cursorY) cursorPos)
    {
        int xLength = tileMap.GetLength(0);
        int yLength = tileMap.GetLength(1);

        StringBuilder screenBuffer = new StringBuilder();

        Console.SetCursorPosition(0, yRenderOffset);

        screenBuffer.Append($"{Color(255, 255, 255)}  0 1 2 3 4 5 6 7 8 9");

        for (int y = 0; y < yLength; y++)
        {
            screenBuffer.Append('\n');
            screenBuffer.Append($"{Color(255, 255, 255)}{y}");

            for (int x = 0; x < xLength; x++)
            {
                if ((x, y) == cursorPos)
                    screenBuffer.Append(' ' + "\x1b[48;2;150;150;150m" + GetTileGraphic(tileMap[x, y]) + "\x1b[48;2;0;0;0m");
                else
                    screenBuffer.Append(' ' + GetTileGraphic(tileMap[x, y]));
            }
        }

        Console.Write(screenBuffer);
    }

    public void Clear()
        => Console.Clear();

    private string GetTileGraphic(Tiles tile)
        => tile switch
        {
            Tiles.Water => Color(50, 50, (byte)Rand.Next(125, 255)) + '~',
            Tiles.Ship => Color(255, 255, 255) + '#',
            Tiles.Occupied => Color(40, 40, 40) + '0',//Color(40, 40, (byte)Rand.Next(150, 225)) + '~',
            Tiles.DestroyedShip => Color(155, 30, 30) + 'x',
            Tiles.MissedShot => Color(100, 100, 100) + 'o',

            _ => "n"
        };

    private string Color(byte r, byte g, byte b)
        => $"\x1b[38;2;{r};{g};{b}m";
}
