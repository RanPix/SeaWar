using SeaWar.Enums;
using SeaWar.Tools;
using System;

namespace SeaWar.Core;

public class Map
{
    public Tiles[,] tileMap { get; private set; } = new Tiles[10, 10];
    public Tiles[][,] playerMap { get; private set; } = new Tiles[][,] { new Tiles[10, 10], new Tiles[10, 10] };

    public void RebuildTileMap(int playerTurn)
    {
        int lengthX = playerMap[playerTurn].GetLength(0);
        int lengthY = playerMap[playerTurn].GetLength(1);

        for (int y = 0; y < lengthX; y++)
        {
            for (int x = 0; x < lengthY; x++)
            {
                tileMap[x, y] = playerMap[playerTurn][x, y];
            }
        }
    }

    public void RebuildEnemyTileMap(int enemyPlayer)
    {
        int lengthX = playerMap[enemyPlayer].GetLength(0);
        int lengthY = playerMap[enemyPlayer].GetLength(1);

        for (int y = 0; y < lengthX; y++)
        {
            for (int x = 0; x < lengthY; x++)
            {
                tileMap[x, y] = playerMap[enemyPlayer][x, y] == Tiles.Ship ? Tiles.Water : playerMap[enemyPlayer][x, y];
            }
        }
    }

    public void PlaceShip()
    {
        int shipLength = 10;

        Random r = new Random();

        for (int i = 0; i < shipLength; i++)
        {
            int px = r.Next(0, 10);
            int py = r.Next(0, 10);

            playerMap[0][px, py] = Tiles.Ship;

            px = r.Next(0, 10);
            py = r.Next(0, 10);

            playerMap[1][px, py] = Tiles.Ship;
        }
    }
}
