using SeaWar.Core.Graphics;
using SeaWar.Enums;

namespace SeaWar.Core;

public class Match
{
    private GraphicsBuffer graphicsBuffer = new GraphicsBuffer();
    private Renderer renderer = new Renderer();
    private UI ui = new UI();
    private Cursor cursor = new Cursor();
    private Turn turn = new Turn();

    private Player[] players = new Player[] { new Player(false), new Player(false) };

    private GameMode gameMode;

    public const int maxShips = 1;
    private int enemyPlayer = 1;

    public MatchResult matchResult { get; private set; }
    private bool endGame;
    private (int player1Wins, int player2Wins) playerWins;

    public Match(bool player1AI, bool player2AI, int player1Wins, int player2Wins, GameMode gameMode)
    {
        players[0] = new Player(player1AI);
        players[1] = new Player(player2AI);

        playerWins.player1Wins = player1Wins;
        playerWins.player2Wins = player2Wins;

        this.gameMode = gameMode;
    }
    
    public void Run()
    {
        Start();

        while (!endGame)
        {
            Input.UpdateInput();
            Update();
            renderer.Draw(graphicsBuffer.buffer);
        }
    }

    private void Start()
    {
        renderer.Start();

        foreach (Player player in players)
            player.Start();
    }

    private void Update()
    {
        if (turn.nextTurn)
        {
            turn.WaitForNextTurn(gameMode);

            enemyPlayer = turn.currentPlayer;
            turn.NextTurn();
        }

        cursor.MoveCursor();
        turn.nextTurn = players[turn.currentPlayer].Shoot(cursor.cursorX, cursor.cursorY, players[enemyPlayer].map); // я не знаю як то інакше зробити :(

        CheckWinner();
        graphicsBuffer.Clear();
        ui.WriteBuffer(graphicsBuffer, turn.currentPlayer, enemyPlayer, playerWins.player1Wins, playerWins.player2Wins);
        graphicsBuffer.WriteTileMaps(cursor.cursorX, cursor.cursorY, players[turn.currentPlayer].GetTileMap(false), players[enemyPlayer].GetTileMap(false));
    }



    private void CheckWinner()
    {
        if (players[0].CheckWon())
            matchResult = MatchResult.Player1Won;

        if (players[1].CheckWon())
            matchResult = MatchResult.Player2Won;

        endGame = matchResult != MatchResult.Null;
    }
}
