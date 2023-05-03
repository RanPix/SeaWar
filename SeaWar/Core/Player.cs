using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Player
{
    public Map map { get; private set; } = new Map();

    public bool isAI { get; private set; }

    private const int maxStreak = 3;
    private int streak = 0;

    private int shipsDestroyed = 0;

    private string name;

    public Player(bool isAI)
    {
        this.isAI = isAI;
    }

    public void Start()
    {
        map.GenerateShips();
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
            shipsDestroyed++;
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


    public bool CheckWon()
        => shipsDestroyed >= Match.maxShips;
}
