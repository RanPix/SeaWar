using SeaWar.Core.Graphics;

namespace SeaWar.Core;

public class Game : Cursor
{
    private Renderer render = new Renderer();
    private GraphicsBuffer graphicsBuffer = new GraphicsBuffer();
    private Cursor cursor = new Cursor();
    private Map map = new Map();
    private Turn turn = new Turn();
    
    public void Run()
    {
        Start();

        while (true)
            Update();
    }

    private void Start()
    {
        render.Start();

        map.PlaceShips();
    }

    private void Update()
    {
        Input.UpdateInput();

        if (turn.beginNextTurn)
            turn.NextTurn();

        cursor.MoveCursor();
        turn.beginNextTurn = map.Shoot(turn.enemyPlayer, cursor.cursorX, cursor.cursorY);

        map.BuildGraphicsBuffer(graphicsBuffer, cursor.cursorX, cursor.cursorY, turn.playerTurn, turn.enemyPlayer);

        render.Draw(graphicsBuffer.buffer);
    }
}
