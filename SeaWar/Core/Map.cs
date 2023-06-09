﻿using SeaWar.Core.Graphics;
using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Map
{
    public Tile[,] map { get; private set; } = new Tile[10, 10];

    public Tile[,] GetTileMap(bool shipsHidden)
    {
        Tile[,] newMap = new Tile[10, 10];

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

    private Tile GetTile(Tile tile, bool shipsHidden)
    {
        if (shipsHidden)
            return tile == Tile.Ship ? Tile.Water : tile;

        return tile;
    }

    public void GenerateShips()
    {
        int shipsSpawned = 0;

        while (shipsSpawned < Match.maxShips)
        {
            int shipX = Rand.Next(0, 10);
            int shipY = Rand.Next(0, 10);

            if (map[shipX, shipY] == Tile.Ship)
                continue;

            map[shipX, shipY] = Tile.Ship;

            shipsSpawned++;
        }
    }
}
