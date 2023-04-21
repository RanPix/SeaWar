using SeaWar.Core.Graphics;
using SeaWar.Tools;

namespace SeaWar.Core;

public class UI
{
    public void WriteBuffer(GraphicsBuffer buffer, int currentPlayer, int enemyPlayer, int player1Wins, int player2Wins)
    {
        InGameUI(buffer, currentPlayer, enemyPlayer, player1Wins, player2Wins);
    }

    private void InGameUI(GraphicsBuffer buffer, int currentPlayer, int enemyPlayer, int player1Wins, int player2Wins)
    {
        buffer.Write(0, 0, $"{Colors.GetColor(255, 255, 255)}Player 0 wins: {player1Wins}   Player 1 wins: {player2Wins}                                    ");

        buffer.Write(0, 1, Colors.GetColor(0, 255, 0) + $"Player {currentPlayer} map");
        buffer.Write(0, 2, Colors.GetColor(255, 255, 255) + "  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 10; i++)
            buffer.Write(0, i + 3, Colors.GetColor(255, 255, 255) + (char)('A' + i));


        buffer.Write(0, 16, Colors.GetColor(255, 0, 0) + $"Player {enemyPlayer} map");
        buffer.Write(0, 17, Colors.GetColor(255, 255, 255) + "  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 10; i++)
            buffer.Write(0, i + 18, Colors.GetColor(255, 255, 255) + (char)('A' + i));
    }
}
