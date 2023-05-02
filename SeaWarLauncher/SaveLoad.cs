using Newtonsoft.Json;
using SeaWarLauncher.Enums;

namespace SeaWarLauncher;

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
                return new Profiles(new List<Profile>());
            
            return profiles;
        }
        catch
        {                   
            return new Profiles(new List<Profile>());
        }
    }

    public static void SaveConfig(string profile1, string profile2, int gameMode, int botDifficulty)
    {
        GameConfig gameConfig = new GameConfig(profile1, profile2, gameMode, botDifficulty);
        StreamWriter currentJsonFileStream = new StreamWriter(gameConfigurationDataDirectory);

        string serializedData = JsonConvert.SerializeObject(gameConfig, Formatting.Indented);
        currentJsonFileStream.WriteLine(serializedData);

        currentJsonFileStream.Close();
    }
}
