using SeaWar.Enums;

namespace SeaWar.Core;

public class Player
{
    private Map map = new Map();

    bool isAI;

    public Player(bool isAI)
    {
        this.isAI = isAI; 
    }

    public bool Shoot(int cursorX, int cursorY)
    {
        if (!Input.GetShootInput())
            return false;

        Tile enemyTile = map.map[cursorX, cursorY];
        Tile newEnemyTile;

        if (enemyTile is Tile.DestroyedShip or Tile.MissedShot)
            return false;

        if (enemyTile is Tile.Ship)
            newEnemyTile = Tile.DestroyedShip;
        else
            newEnemyTile = Tile.MissedShot;

        map.map[cursorX, cursorY] = newEnemyTile;

        return true;
    }

    public Tile[,] GetTileMap(bool shipsHidden)
        => map.GetTileMap(shipsHidden);

    public void Start()
    {
        map.GenerateShips();
    }
}
