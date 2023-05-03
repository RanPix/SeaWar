using SeaWar.Enums;
using SeaWar.Tools;

namespace SeaWar.Core;

public class Lobby
{
    private Profiles playersProfiles;

    private int player1Wins = 0;    
    private int player2Wins = 0;

    private (bool player1AI, bool player2AI) playersAreAI;
    private GameMode gameMode;

    public void Start()
    {
        playersProfiles = SaveLoad.LoadProfiles();

        //playersAreAI = GetPlayers();
        GameConfig gameConfig = SaveLoad.LoadConfig();
        ParseGameConfig(gameConfig);
        //GameMode gameMode = GetGameMode(playersAreAI);

        while (!(player1Wins >= 3 || player2Wins >= 3))
        {
            Match match = new Match(playersAreAI.player1AI, playersAreAI.player2AI, player1Wins, player2Wins, gameMode);
            match.Run();

            CheckWinner(match.matchResult, gameConfig);
        }
    }

    private void CheckWinner(MatchResult matchResult, GameConfig gameConfig)
    {
        switch (matchResult)
        {
            case MatchResult.Player1Won:
                player1Wins++;

                playersProfiles.GetProfile(gameConfig.profile1).roundsWon++;
                playersProfiles.GetProfile(gameConfig.profile2).roundsLost++;
                break;

            case MatchResult.Player2Won:
                player2Wins++;

                playersProfiles.GetProfile(gameConfig.profile2).roundsWon++;
                playersProfiles.GetProfile(gameConfig.profile1).roundsLost++;
                break;

            case MatchResult.Draw:
                break;

            default:
                //how
                break;
        }

        SaveLoad.SaveProfiles(playersProfiles);
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

    private void ParseGameConfig(GameConfig config)
    {
        switch ((GameMode)config.gameMode)
        {
            case GameMode.PvP:
                playersAreAI.player1AI = false;
                playersAreAI.player2AI = false;
                break;

            case GameMode.PvE:
                playersAreAI.player1AI = false;
                playersAreAI.player2AI = true;
                break;

            case GameMode.EvE:
                playersAreAI.player1AI = true;
                playersAreAI.player2AI = true;
                break;
        }

        gameMode = (GameMode)config.gameMode;
    }
}
