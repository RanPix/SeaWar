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
}
