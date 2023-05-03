using Newtonsoft.Json;
using SeaWar.Enums;

namespace SeaWar.Core;

public static class SaveLoad
{
    private static string profilesDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents") + @"\seawarUserData.json";
    private static string gameConfigurationDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents") + @"\seawarConfigData.json";

    public static void SaveProfiles(Profiles profiles)
    {
        StreamWriter currentJsonFileStream = new StreamWriter(profilesDataDirectory);
        
        string serializedData = JsonConvert.SerializeObject(profiles, Formatting.Indented);
        currentJsonFileStream.WriteLine(serializedData);

        currentJsonFileStream.Close();
    }

    public static Profiles LoadProfiles()
    {
        try
        {
            Profiles profiles = JsonConvert.DeserializeObject<Profiles>(File.ReadAllText(profilesDataDirectory));

            if (profiles == null)
                return new Profiles(new List<Profile>()
                {
                    new Profile() { name = "BOT Joseph" },
                    new Profile() { name = "BOT Ceasar" }
                });

            return profiles;
        }
        catch
        {
            return new Profiles(new List<Profile>()
            {
                new Profile() { name = "BOT Joseph" },
                new Profile() { name = "BOT Ceasar" }
            });
        }
    }

    public static GameConfig LoadConfig()
    {
            return JsonConvert.DeserializeObject<GameConfig>(File.ReadAllText(gameConfigurationDataDirectory));
        try
        {
        }
        catch
        {
            throw new Exception("You broke a fucking config file");
            //return new GameConfig("Player1", "Player2", 2, 1);
        }
    }
}
