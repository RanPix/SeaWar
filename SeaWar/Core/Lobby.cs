using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Lobby
{
    private int player1Wins = 0;
    private int player2Wins = 0;

    public void Start()
    {
        (bool player1AI, bool player2AI) players = GetPlayers();
        GameMode gameMode = GetGameMode(players);

        while (!(player1Wins >= 3 || player2Wins >= 3))
        {
            Match match = new Match(players.player1AI, players.player2AI, player1Wins, player2Wins, gameMode);
            match.Run();

            CheckWinner(match.matchResult);
        }
    }

    private void CheckWinner(MatchResult matchResult)
    {
        switch (matchResult)
        {
            case MatchResult.Player1Won:
                player1Wins++;
                return;

            case MatchResult.Player2Won:
                player2Wins++;
                return;

            case MatchResult.Draw:
                return;

            default:
                //how
                return;
        }
    }

    private GameMode GetGameMode((bool player1AI, bool player2AI) players)
    {
        if (!players.player1AI && !players.player2AI)
            return GameMode.PvP;

        else if (players.player1AI && players.player2AI)
            return GameMode.EvE;

        else
            return GameMode.PvE;
    }

    private (bool player1AI, bool player2AI) GetPlayers()
    {
        (bool player1AI, bool player2AI) players;

        int player1Input;
        int player2Input;

        bool inputCrashed = false;

        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Colors.GetColor(255, 255, 255) + "Who do you want to play against? '0' for player, '1' for AI");

            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");

            if (inputCrashed)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(Colors.GetColor(255, 0, 0) + "WRONG INPUT" + Colors.GetColor(255, 255, 255));
            }
            Console.SetCursorPosition(0, 1);

            player1Input = GetPlayer(out inputCrashed);

            if (inputCrashed)
                continue;

            player2Input = GetPlayer(out inputCrashed);

            if (inputCrashed)
                continue;

            
            break;
        }

        return (player1Input == 1, player2Input == 1);
    }

    private int GetPlayer(out bool crashed)
    {
        string input = Console.ReadLine();

        crashed = input.ValidateInt();

        if (crashed)
            return -404;

        return Math.Clamp(int.Parse(input), 0, 1);
    }
}
