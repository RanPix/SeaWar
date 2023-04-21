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

    private Player[] players = new Player[] { new Player(false), new Player(false) };

    public const int maxShips = 20;
    private int enemyPlayer = 1;

    private bool endGame;
    public (bool player1Won, bool player2Won) playerWon;
    private (int player1Wins, int player2Wins) playerWins;

    public Game(bool player1AI, bool player2AI, int player1Wins, int player2Wins)
    {
        players[0] = new Player(player1AI);
        players[1] = new Player(player2AI);

        playerWins.player1Wins = player1Wins;
        playerWins.player2Wins = player2Wins;
    }
    
    public void Run()
    {
        Start();

        while (!endGame)
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
            enemyPlayer = turn.currentPlayer;
            turn.NextTurn();
            Thread.Sleep(500);
        }

        CheckWinner();
        cursor.MoveCursor();
        turn.nextTurn = players[turn.currentPlayer].Shoot(cursor.cursorX, cursor.cursorY, players[enemyPlayer].map); // я не знаю як то інакше зробити :(

        graphicsBuffer.Clear();
        ui.WriteBuffer(graphicsBuffer, turn.currentPlayer, enemyPlayer, playerWins.player1Wins, playerWins.player2Wins);
        graphicsBuffer.WriteTileMaps(cursor.cursorX, cursor.cursorY, players[turn.currentPlayer].GetTileMap(false), players[enemyPlayer].GetTileMap(true));
    }

    private void CheckWinner()
    {
        playerWon.player2Won = players[0].CheckLost();
        playerWon.player1Won = players[1].CheckLost();

        endGame = playerWon.player1Won || playerWon.player2Won;
    }
}
