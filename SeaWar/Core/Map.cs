using SeaWar.Core.Graphics;
using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Map
{
    public Tile[,] map { get; private set; } = new Tile[10, 10];

    public Tile[,] GetTileMap(bool shipsHidden)
    {
        Tile[,] newMap = CopyMap();

        int lengthX = newMap.GetLength(0);
        int lengthY = newMap.GetLength(1);

        for (int y = 0; y < lengthY; y++)
        {
            for (int x = 0; x < lengthX; x++)
            {
                newMap[x, y] = GetTile(map[x, y], shipsHidden);
            }
        }

        return newMap;
    }

    private Tile[,] CopyMap()  // ЧОМУ ЦЕ ЛАЙНО ЦЕ РЕФЕРЕНС ТАЙП НА*************
    {
        Tile[,] newMap = new Tile[10, 10];

        int lengthX = map.GetLength(0);
        int lengthY = map.GetLength(1);

        for (int y = 0; y < lengthY; y++)
        {
            for (int x = 0; x < lengthX; x++)
            {
                newMap[x, y] = map[x, y];
            }
        }

        return newMap;
    }

    private Tile GetTile(Tile tile, bool shipsHidden)
    {
        if (shipsHidden)
            return tile == Tile.Ship ? Tile.Water : tile;

        return tile;
    }

    public void GenerateShips()
    {
        for (int i = 0; i < 20; i++)
        {
            int shipX = Rand.Next(0, 10);
            int shipY = Rand.Next(0, 10);

            map[shipX, shipY] = Tile.Ship;
        }
    }
}
