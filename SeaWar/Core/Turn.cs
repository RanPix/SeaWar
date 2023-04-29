using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Turn
{
    public int currentPlayer = 0;

    public bool nextTurn;

    public void NextTurn()
    {
        currentPlayer++;
        currentPlayer.Loop(0, 1);

        nextTurn = false;
    }

    public void WaitForNextTurn(GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.PvP:
                Console.Clear();
                Console.WriteLine("Now give the controls to the other player and press 'N' to continue");
                
                while (!Input.GetNextTurnInput()) { }
                return;

            case GameMode.PvE:
                return;

            case GameMode.EvE:
                Thread.Sleep(500);
                return;
        }
    }
}
