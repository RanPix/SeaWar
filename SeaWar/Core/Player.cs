using SeaWar.Enums;
using SeaWar.Tools;
using System.Reflection;

namespace SeaWar.Core;

public class Player
{
    public Map map { get; private set; } = new Map();

    public bool isAI { get; private set; }

    private const int maxStreak = 3;
    private int streak = 0;

    private int shipsDestroyed = 20;

    public Player(bool isAI)
    {
        this.isAI = isAI;
    }

    public bool Shoot(int cursorX, int cursorY, Map enemyMap)
    {
        if (isAI)
            return IsHit(Rand.Next(0, 10), Rand.Next(0, 10), enemyMap);

        return IsHit(cursorX, cursorY, enemyMap);
    }

    private bool IsHit(int cursorX, int cursorY, Map enemyMap)
    {
        if (!isAI)
        {
            if (!Input.GetShootInput())
                return false;
        }


        Tile enemyTile = enemyMap.map[cursorX, cursorY];
        Tile newEnemyTile;

        if (enemyTile is Tile.DestroyedShip or Tile.MissedShot)
            return false;

        if (enemyTile is Tile.Ship)
        {
            streak++;
            newEnemyTile = Tile.DestroyedShip;
        }
        else
        {
            streak = 1337;
            newEnemyTile = Tile.MissedShot;
        }

        enemyMap.map[cursorX, cursorY] = newEnemyTile;

        if (streak >= maxStreak)
        {
            streak = 0;
            return true;
        }

        return false;
    }

    public Tile[,] GetTileMap(bool shipsHidden)
        => map.GetTileMap(shipsHidden);

    private int GetDestroyedShipsAmount()
    {
        int destroyedShipsAmount = 0;

        int lengthX = map.map.GetLength(0);
        int lengthY = map.map.GetLength(1);

        for (int y = 0; y < lengthY; y++)
        {
            for (int x = 0; x < lengthX; x++)
            {
                destroyedShipsAmount += map.map[x, y] == Tile.DestroyedShip ? 1 : 0;
            }
        }

        return destroyedShipsAmount;
    }

    public bool CheckLost()
    {
        shipsDestroyed = GetDestroyedShipsAmount();
        return shipsDestroyed >= Game.maxShips;
    }

    public void Start()
    {
        map.GenerateShips();
    }
}
