namespace SeaWar.Core;

public class Profiles
{
    public List<Profile> profiles = new List<Profile>();

    public Profiles() { }

    public Profiles(List<Profile> profiles)
    {
        this.profiles = profiles;
    }

    public bool ProfileExists(string name)
    {
        foreach (var profile in profiles)
        {
            if (profile.name == name) 
                return true;
        }

        return false;
    }

    public Profile GetProfile(string name)
    {
        foreach (var profile in profiles)
        {
            if (profile.name == name)
                return profile;
        }

        return null;
    }
}
