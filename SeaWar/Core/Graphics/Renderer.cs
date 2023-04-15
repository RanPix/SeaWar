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
}
