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

    private void WriteTileMap(int writeX, int writeY, Tile[,] tileMap)
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

    private void WriteCursor(int offsetX, int offsetY, int writeX, int writeY, Tile[,] tileMap)
    {
        buffer[writeX + offsetX, writeY + offsetY] = ' ' + Colors.GetBGColor(150, 150, 150) + GetTileGraphic(tileMap[writeX, writeY]) + Colors.GetBGColor(0, 0, 0);
    }

    public void WriteTileMaps(int cursorX, int cursorY, params Tile[][,] maps) // я не знав куди то запхнути :((
    {
        WriteTileMap(1, 2, maps[0]);
        WriteCursor(1, 2, cursorX, cursorY, maps[0]);

        WriteTileMap(1, 17, maps[1]);
        WriteCursor(1, 17, cursorX, cursorY, maps[1]);
    }

    public void Clear()
        => buffer = new string[20, 30];

    private string GetTileGraphic(Tile tile)
        => tile switch
        {
            Tile.Water => Colors.GetColor(50, 50, (byte)Rand.Next(125, 255)) + '~',
            Tile.Ship => "\x1b[38;2;255;255;255m#",
            Tile.Occupied => "\x1b[38;2;40;40;40m0",
            Tile.DestroyedShip => "\x1b[38;2;155;30;30mx",
            Tile.MissedShot => "\x1b[38;2;100;100;100mo",

            _ => "n"
        };
}