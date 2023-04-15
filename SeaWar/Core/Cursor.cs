using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Cursor
{
    public int cursorX { get; private set; }
    public int cursorY { get; private set; }

    public void MoveCursor()
    {
        if (Input.latestInput == null)
            return;

        (int deltaX, int deltaY) = Input.GetMovementInput();

        cursorX = Math.Clamp(cursorX + deltaX, 0, 9);
        cursorY = Math.Clamp(cursorY + deltaY, 0, 9);
    }
}