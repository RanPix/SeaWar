using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Player
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

    public bool Shoot(int playerTurn, ref Tiles[,] playerMap)
    {
        if (!Input.GetShootInput())
            return false;

        int enemyPlayer = playerTurn + 1;
        enemyPlayer.Loop(0, 1);

        Tiles enemyTile = playerMap[cursorX, cursorY];
        Tiles newEnemyTile;

        if (enemyTile is Tiles.DestroyedShip or Tiles.MissedShot)
            return false;

        else if (enemyTile is Tiles.Ship)
            newEnemyTile = Tiles.DestroyedShip;
        else
            newEnemyTile = Tiles.MissedShot;

        playerMap[cursorX, cursorY] = newEnemyTile;

        return true;
    }
}