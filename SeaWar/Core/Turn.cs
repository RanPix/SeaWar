using SeaWar.Tools;

namespace SeaWar.Core;

public class Turn
{
    public int playerTurn;
    public int enemyPlayer;

    public bool beginNextTurn;

    public void NextTurn()
    {
        playerTurn++;
        playerTurn.Loop(0, 1);

        enemyPlayer = playerTurn + 1;
        enemyPlayer.Loop(0, 1);

        beginNextTurn = false;
    }
}
