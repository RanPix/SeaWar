using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core.Graphics;

public class GraphicsBuffer
{
    public string[,] buffer { get; private set; } = new string[20, 30];

    public void Write(int writeX, int writeY, string s) // я знаю що так не правильно але у мене голова плавиться
    {
        buffer[writeX, writeY] = s;
    }

    public void WriteTileMap(int writeX, int writeY, Tiles[,] tileMap)
    {
        int xLength = tileMap.GetLength(0) + writeX;
        int yLength = tileMap.GetLength(1) + writeY;

        for (int y = writeY; y < yLength; y++)
        {
            for (int x = writeX; x < xLength; x++)
            {
                buffer[x, y] = ' ' + GetTileGraphic(tileMap[x - writeX, y - writeY]);
            }
        }
    }

    public void WriteCursor(int offsetX, int offsetY, int writeX, int writeY, Tiles[,] tileMap)
    {
        buffer[writeX + offsetX, writeY + offsetY] = ' ' + Colors.GetBGColor(150, 150, 150) + GetTileGraphic(tileMap[writeX, writeY]) + Colors.GetBGColor(0, 0, 0);
    }

    private string GetTileGraphic(Tiles tile)
        => tile switch
        {
            Tiles.Water => Colors.GetColor(50, 50, (byte)Rand.Next(125, 255)) + '~',
            Tiles.Ship => Colors.GetColor(255, 255, 255) + '#',
            Tiles.Occupied => Colors.GetColor(40, 40, 40) + '0',//Color(40, 40, (byte)Rand.Next(150, 225)) + '~',
            Tiles.DestroyedShip => Colors.GetColor(155, 30, 30) + 'x',
            Tiles.MissedShot => Colors.GetColor(100, 100, 100) + 'o',

            _ => "n"
        };
}