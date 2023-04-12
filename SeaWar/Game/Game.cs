using System;

namespace SeaWar;

public class Game
{
    private Input input = new Input();
    private Renderer render = new Renderer();

    private Tiles[,] tileMap = new Tiles[9, 9];
    private Tiles[,] entityMap = new Tiles[9, 9];

    private int cursorX;
    private int cursorY;

    public void Launch()
    {
        Start();
        Update();
    }

    private void Start()
    {
        render.Start();
    }

    private void Update()
    {
        while (true)
        {
            input.UpdateInput();

            render.Draw(tileMap);
        }
    }

    private void MoveShip()
    {

    }

    private void PlaceShip()
    {
        int shipLength = 3;

        for (int i = 0; i < shipLength; i++)
        {
            
        }
    }
}
