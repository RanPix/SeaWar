using SeaWar.Core.Graphics;
using SeaWar.Enums;
using SeaWar.Tools;

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

        Tiles[,] enemyTiles = playerMap[enemyPlayer];

        for (int y = 0; y < lengthX; y++)
        {
            for (int x = 0; x < lengthY; x++)
            {
                tileMap[x, y] = enemyTiles[x, y] == Tiles.Ship ? Tiles.Water : enemyTiles[x, y];
            }
        }
    }

    public void BuildGraphicsBuffer(GraphicsBuffer buffer, int cursorX, int cursorY, int currentPlayer, int enemyPlayer)
    {
        buffer.Write(0, 0, Colors.GetColor(0, 255, 0) + "Your map");
        buffer.Write(0, 1, Colors.GetColor(255, 255, 255) + "  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 10; i++)
            buffer.Write(0, i + 2, Colors.GetColor(255, 255, 255) + (char)('A' + i));

        RebuildTileMap(currentPlayer);
        buffer.WriteTileMap(1, 2, tileMap);

        buffer.WriteCursor(1, 2, cursorX, cursorY, tileMap);


        buffer.Write(0, 15, Colors.GetColor(255, 0, 0) + "Enemy map");
        buffer.Write(0, 16, Colors.GetColor(255, 255, 255) + "  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i < 10; i++)
            buffer.Write(0, i + 17, Colors.GetColor(255, 255, 255) + (char)('A' + i));

        RebuildEnemyTileMap(enemyPlayer);
        buffer.WriteTileMap(1, 17, tileMap);

        buffer.WriteCursor(1, 17, cursorX, cursorY, tileMap);
    }

    public void PlaceShips()
    {
        Random r = new Random();

        for (int i = 0; i < 20; i++)
        {
            r = new Random();

            int px = r.Next(0, 10);
            int py = r.Next(0, 10);

            playerMap[0][px, py] = Tiles.Ship;

            r = new Random();

            px = r.Next(0, 10);
            py = r.Next(0, 10);

            playerMap[1][px, py] = Tiles.Ship;
        }
    }

    public bool Shoot(int enemyPlayer, int cursorX, int cursorY)
    {
        if (!Input.GetShootInput())
            return false;

        Tiles[,] enemyMap = playerMap[enemyPlayer];

        Tiles enemyTile = enemyMap[cursorX, cursorY];
        Tiles newEnemyTile;

        if (enemyTile is Tiles.DestroyedShip or Tiles.MissedShot)
            return false;

        else if (enemyTile is Tiles.Ship)
            newEnemyTile = Tiles.DestroyedShip;
        else
            newEnemyTile = Tiles.MissedShot;

        enemyMap[cursorX, cursorY] = newEnemyTile;

        return true;
    }
}
