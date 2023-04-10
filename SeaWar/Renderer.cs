using System;
using System.Runtime.InteropServices;

namespace SeaWar; 

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
    }

    public void Render()
    {

    }
}
