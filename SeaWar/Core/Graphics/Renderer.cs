using SeaWar.Tools;
using System.Runtime.InteropServices;
using System.Text;
using SeaWar.Enums;

namespace SeaWar.Core.Graphics;

public class Renderer
{
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
    
    public void Draw(string[,] graphicsBuffer)
    {
        int xLength = graphicsBuffer.GetLength(0);
        int yLength = graphicsBuffer.GetLength(1);

        StringBuilder screenBuffer = new StringBuilder();

        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                screenBuffer.Append(graphicsBuffer[x, y]);
            }

            screenBuffer.Append("\n");
        }

        Console.Write(screenBuffer);
    }

    public void Clear()
        => Console.Clear();

    private string GetTileGraphic(Tiles tile)
        => tile switch
        {
            Tiles.Water => Colors.GetColor(50, 50, (byte)Rand.Next(125, 255)) + '~',
            Tiles.Ship => Colors.GetColor(255, 255, 255) + '#',
            Tiles.Occupied => Colors.GetColor(40, 40, 40) + '0',//Color(40, 40, (byte)Rand.Next(150, 225)) + '~',
            Tiles.DestroyedShip => Colors.GetColor(155, 30, 30) + 'x',
            Tiles.MissedShot => Colors.GetColor(100, 100, 100) + 'o',

            _ => "n"
        };
}
