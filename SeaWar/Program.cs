using SeaWar.Core;
using SeaWar.Tools;

namespace SeaWar;

class Program
{
    static void Main(string[] args)
    {
        int player1Wins = 0;
        int player2Wins = 0;

        (bool player1AI, bool player2AI) players = GetGamemode();

        while (!(player1Wins >= 3 || player2Wins >= 3))
        {
            Game game = new Game(players.player1AI , players.player2AI, player1Wins, player2Wins);
            game.Run();

            player1Wins += game.playerWon.player1Won ? 1 : 0;
            player2Wins += game.playerWon.player2Won ? 1 : 0;
        }
    }

    static (bool player1AI, bool player2AI) GetGamemode()
    {
        (bool player1AI, bool player2AI) players;

        int player1Input = 0;
        int player2Input = 0;

        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Colors.GetColor(255, 255, 255) + "Who you want to play against? '0' for player, '1' for AI");

            Console.WriteLine("                                                         ");
            Console.SetCursorPosition(0, 1);

            try
            {
                player1Input = int.Parse(Console.ReadLine());
                player2Input = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(Colors.GetColor(255, 0, 0) + "WRONG INPUT");

                continue;
            }

            player1Input = Math.Clamp(player1Input, 0, 1);
            player2Input = Math.Clamp(player2Input, 0, 1);

            players.player1AI = player1Input == 1 ? true : false;
            players.player2AI = player2Input == 1 ? true : false;

            break;
        }

        return players;
    }
}