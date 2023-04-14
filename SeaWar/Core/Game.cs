using SeaWar.Tools;

namespace SeaWar.Core;

public class Game : Player
{
    private Renderer render = new Renderer();
    private Player player = new Player();
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

        map.PlaceShip();
    }

    private void Update()
    {
        Input.UpdateInput();

        if (turn.beginNextTurn)
            turn.NextTurn();

        player.MoveCursor();
        turn.beginNextTurn = player.Shoot(turn.playerTurn, ref map.playerMap[turn.GetEnemyPlayer()]);

        map.RebuildTileMap(turn.playerTurn);
        render.Draw(0, map.tileMap, (player.cursorX, player.cursorY));

        map.RebuildEnemyTileMap(turn.GetEnemyPlayer());
        render.Draw(12, map.tileMap, (player.cursorX, player.cursorY));
    }

    
}
