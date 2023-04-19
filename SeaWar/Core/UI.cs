using SeaWar.Core.Graphics;
using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class UI
{
    public void WriteBuffer(GraphicsBuffer buffer, GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.None:

                break;

            case GameMode.PvP:
                InGameUI(buffer);
                break;
        }    
        
    }

    private void InGameUI(GraphicsBuffer buffer)
    {
        buffer.Write(0, 0, Colors.GetColor(0, 255, 0) + "Your map");
        buffer.Write(0, 1, Colors.GetColor(255, 255, 255) + "  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 10; i++)
            buffer.Write(0, i + 2, Colors.GetColor(255, 255, 255) + (char)('A' + i));


        buffer.Write(0, 15, Colors.GetColor(255, 0, 0) + "Enemy map");
        buffer.Write(0, 16, Colors.GetColor(255, 255, 255) + "  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 10; i++)
            buffer.Write(0, i + 17, Colors.GetColor(255, 255, 255) + (char)('A' + i));
    }
}
