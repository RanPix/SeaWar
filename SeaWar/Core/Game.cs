using SeaWar.Core.Graphics;
using SeaWar.Enums;

namespace SeaWar.Core;

public class Game
{
    private Renderer render = new Renderer();
    private GraphicsBuffer graphicsBuffer = new GraphicsBuffer();
    private UI ui = new UI();
    private Cursor cursor = new Cursor();
    private Turn turn = new Turn();

    private Player[] players = new Player[] { new Player(), new Player() };

    private int enemyPlayer = 1;

    public void Run()
    {
        Start();

        while (true)
        {
            Input.UpdateInput();
            Update();
            render.Draw(graphicsBuffer.buffer);
        }
    }

    private void Start()
    {
        render.Start();

        foreach (Player player in players)
            player.Start();
    }

    private void Update()
    {
        if (turn.nextTurn)
        {
            enemyPlayer = turn.playerTurn;
            turn.NextTurn();
        }

        cursor.MoveCursor();
        turn.nextTurn = players[enemyPlayer].Shoot(cursor.cursorX, cursor.cursorY); // я не знаю як то інакше зробити :(

        graphicsBuffer.Clear();
        ui.WriteBuffer(graphicsBuffer, GameMode.PvP);
        graphicsBuffer.WriteTileMaps(cursor.cursorX, cursor.cursorY, players[turn.playerTurn].GetTileMap(false), players[enemyPlayer].GetTileMap(true));
    }
}
