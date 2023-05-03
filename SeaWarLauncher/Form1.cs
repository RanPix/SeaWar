using SeaWarLauncher.Enums;
using System.Diagnostics;

namespace SeaWarLauncher;

public partial class Form1 : Form
{
    private string gameFileDirectory;

    Profile currentProfile = new Profile();
    Profiles allProfiles;

    private GameMode gameMode;
    private int botDifficulty;

    public Form1()
    {
        InitializeComponent();

        gameFileDirectory = Directory.GetCurrentDirectory() + @"\SeaWar\SeaWar.exe";

        allProfiles = SaveLoad.LoadProfiles();

        UpdateSecondPlayerComboboxItems();
    }

    private void LaunchGameButton_Click(object sender, EventArgs e)
    {
        SaveLoad.SaveConfig(currentProfile.name, SecondPlayerComboBox.SelectedItem.ToString(), (int)gameMode, botDifficulty);
        Process.Start(gameFileDirectory);
    }


    private void RegisterButton_Click(object sender, EventArgs e)
    {
        if (allProfiles.ProfileExists(ProfileNameInputField.Text))
        {
            MessageBox.Show("Profile with this name already exists!");
            return;
        }

        currentProfile = new Profile { name = ProfileNameInputField.Text };
        allProfiles.profiles.Add(currentProfile);

        PlayerNameTextField.Text = ProfileNameInputField.Text;
        ProfileNameInputField.Text = "";

        UpdateSecondPlayerComboboxItems();
        SaveLoad.SaveProfiles(allProfiles);
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        if (currentProfile.name == ProfileNameInputField.Text)
        {
            MessageBox.Show("You are already Logged in");
            return;
        }
        if (!allProfiles.ProfileExists(ProfileNameInputField.Text))
        {
            MessageBox.Show("This profile does not exist!");
            return;
        }

        currentProfile = allProfiles.GetProfile(ProfileNameInputField.Text);

        PlayerNameTextField.Text = ProfileNameInputField.Text;
        ProfileNameInputField.Text = "";

        UpdateSecondPlayerComboboxItems();
    }



    private void GamemodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        gameMode = (GameMode)GamemodeComboBox.SelectedIndex + 1;

        SecondPlayerComboBox.Visible = gameMode == GameMode.PvP;
        AILevelComboBox.Visible = gameMode != GameMode.PvP;
    }

    private void SecondPlayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void UpdateSecondPlayerComboboxItems()
    {
        SecondPlayerComboBox.Items.Clear();

        foreach (Profile info in allProfiles.profiles)
        {
            if (currentProfile.name != info.name)
                SecondPlayerComboBox.Items.Add(info.name);
        }

        SecondPlayerComboBox.SelectedIndex = 0;
    }

    private void AILevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        botDifficulty = AILevelComboBox.SelectedIndex;
    }


    private void PlayerNameTextField_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"Rounds Won {currentProfile.roundsWon}");
    }
}