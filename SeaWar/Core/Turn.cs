using SeaWar.Tools;

namespace SeaWar.Core;

public class Turn
{
    public int playerTurn = 0;

    public bool nextTurn;

    public void NextTurn()
    {
        playerTurn++;
        playerTurn.Loop(0, 1);

        nextTurn = false;
    }
}
