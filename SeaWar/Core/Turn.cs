using SeaWar.Tools;

namespace SeaWar.Core;

public class Turn
{
    public int playerTurn;

    public bool beginNextTurn;

    public void NextTurn()
    {
        playerTurn++;
        playerTurn.Loop(0, 1);

        beginNextTurn = false;
    }

    public int GetEnemyPlayer()
    {
        int enemyPlayer = playerTurn + 1;
        enemyPlayer.Loop(0, 1);

        return enemyPlayer;
    }
}
