namespace SeaWarLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LaunchGameButton = new System.Windows.Forms.Button();
            this.ProfileNameInputField = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SecondPlayerComboBox = new System.Windows.Forms.ComboBox();
            this.GamemodeComboBox = new System.Windows.Forms.ComboBox();
            this.AILevelComboBox = new System.Windows.Forms.ComboBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.PlayerNameTextField = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LaunchGameButton
            // 
            this.LaunchGameButton.Location = new System.Drawing.Point(150, 212);
            this.LaunchGameButton.Name = "LaunchGameButton";
            this.LaunchGameButton.Size = new System.Drawing.Size(94, 29);
            this.LaunchGameButton.TabIndex = 0;
            this.LaunchGameButton.Text = "Launch";
            this.LaunchGameButton.UseVisualStyleBackColor = true;
            this.LaunchGameButton.Click += new System.EventHandler(this.LaunchGameButton_Click);
            // 
            // ProfileNameInputField
            // 
            this.ProfileNameInputField.Location = new System.Drawing.Point(12, 56);
            this.ProfileNameInputField.MaxLength = 15;
            this.ProfileNameInputField.Name = "ProfileNameInputField";
            this.ProfileNameInputField.PlaceholderText = "Name";
            this.ProfileNameInputField.Size = new System.Drawing.Size(358, 27);
            this.ProfileNameInputField.TabIndex = 1;
            this.ProfileNameInputField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 89);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(150, 29);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SecondPlayerComboBox
            // 
            this.SecondPlayerComboBox.FormattingEnabled = true;
            this.SecondPlayerComboBox.Location = new System.Drawing.Point(12, 171);
            this.SecondPlayerComboBox.Name = "SecondPlayerComboBox";
            this.SecondPlayerComboBox.Size = new System.Drawing.Size(150, 28);
            this.SecondPlayerComboBox.TabIndex = 3;
            this.SecondPlayerComboBox.Text = "Player 2";
            this.SecondPlayerComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondPlayerComboBox_SelectedIndexChanged);
            // 
            // GamemodeComboBox
            // 
            this.GamemodeComboBox.FormattingEnabled = true;
            this.GamemodeComboBox.Items.AddRange(new object[] {
            "PvP",
            "PvE",
            "EvE"});
            this.GamemodeComboBox.Location = new System.Drawing.Point(120, 137);
            this.GamemodeComboBox.Name = "GamemodeComboBox";
            this.GamemodeComboBox.Size = new System.Drawing.Size(150, 28);
            this.GamemodeComboBox.TabIndex = 4;
            this.GamemodeComboBox.Text = "Gamemode";
            this.GamemodeComboBox.SelectedIndexChanged += new System.EventHandler(this.GamemodeComboBox_SelectedIndexChanged);
            // 
            // AILevelComboBox
            // 
            this.AILevelComboBox.FormattingEnabled = true;
            this.AILevelComboBox.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "ULTRAKILL"});
            this.AILevelComboBox.Location = new System.Drawing.Point(220, 171);
            this.AILevelComboBox.Name = "AILevelComboBox";
            this.AILevelComboBox.Size = new System.Drawing.Size(150, 28);
            this.AILevelComboBox.TabIndex = 5;
            this.AILevelComboBox.Text = "AI level";
            this.AILevelComboBox.SelectedIndexChanged += new System.EventHandler(this.AILevelComboBox_SelectedIndexChanged);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(220, 89);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(150, 29);
            this.RegisterButton.TabIndex = 7;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PlayerNameTextField
            // 
            this.PlayerNameTextField.Location = new System.Drawing.Point(12, 12);
            this.PlayerNameTextField.Name = "PlayerNameTextField";
            this.PlayerNameTextField.Size = new System.Drawing.Size(358, 29);
            this.PlayerNameTextField.TabIndex = 8;
            this.PlayerNameTextField.Text = "Player";
            this.PlayerNameTextField.UseVisualStyleBackColor = true;
            this.PlayerNameTextField.Click += new System.EventHandler(this.PlayerNameTextField_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.PlayerNameTextField);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.AILevelComboBox);
            this.Controls.Add(this.GamemodeComboBox);
            this.Controls.Add(this.SecondPlayerComboBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ProfileNameInputField);
            this.Controls.Add(this.LaunchGameButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LaunchGameButton;
        private TextBox ProfileNameInputField;
        private Button LoginButton;
        private ComboBox SecondPlayerComboBox;
        private ComboBox GamemodeComboBox;
        private ComboBox AILevelComboBox;
        private Button RegisterButton;
        private Button PlayerNameTextField;
    }
}