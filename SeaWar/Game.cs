using System;

namespace SeaWar;

public class Game
{
    private Input input = new Input();
    private Renderer render = new Renderer();

    private char[,] map = new char[9,9];

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
        input.GetInput();
    }
}
