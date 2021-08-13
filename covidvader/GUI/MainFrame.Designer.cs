using covidvader.Properties;
using System.Drawing;
using System;
using System.Windows.Forms;


namespace CovidVader.GUI
{
    partial class MainFrame
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelStartScreen = new System.Windows.Forms.Panel();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonOptions = new System.Windows.Forms.Button();
            this.ButtonApplyOptions = new System.Windows.Forms.Button();
            this.ButtonCancelOptions = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.TitleStartScreen = new System.Windows.Forms.Label();
            this.TrackBarMasterVolume = new System.Windows.Forms.TrackBar();
            this.TrackBarMasterMusicVolume = new System.Windows.Forms.TrackBar();
            this.TrackBarMasterFxVolume = new System.Windows.Forms.TrackBar();
            this.ButtonTabOptionsSound = new System.Windows.Forms.Button();
            this.ButtonTabOptionsKeyboard = new System.Windows.Forms.Button();
            this.PanelOptionsScreen = new System.Windows.Forms.Panel();
            this.PanelOptionsSound = new System.Windows.Forms.Panel();
            this.PanelOptionsKeyboard = new System.Windows.Forms.Panel();
            this.TextBoxKeyUp = new System.Windows.Forms.TextBox();
            this.TextBoxKeyDown = new System.Windows.Forms.TextBox();
            this.TextBoxKeyLeft = new System.Windows.Forms.TextBox();
            this.TextBoxKeyRight = new System.Windows.Forms.TextBox();
            this.TextBoxKeyShoot = new System.Windows.Forms.TextBox();
            this.TextBoxKeyBulletTime = new System.Windows.Forms.TextBox();
            this.PanelEndScreen = new System.Windows.Forms.Panel();
            this.LabelScoreEndScreen = new System.Windows.Forms.Label();
            this.ButtonRestartEndScreen = new System.Windows.Forms.Button();
            this.ButtonExitEndScreen = new System.Windows.Forms.Button();
            this.PictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.PictureBoxGame = new System.Windows.Forms.PictureBox();
            this.LabelMasterVolume = new System.Windows.Forms.Label();
            this.LabelMasterVolumeNumber = new System.Windows.Forms.Label();
            this.LabelMasterMusicVolume = new System.Windows.Forms.Label();
            this.LabelMasterMusicVolumeNumber = new System.Windows.Forms.Label();
            this.LabelMasterFxVolume = new System.Windows.Forms.Label();
            this.LabelMasterFxVolumeNumber = new System.Windows.Forms.Label();
            this.LabelInputKeyUp = new System.Windows.Forms.Label();
            this.LabelInputKeyDown = new System.Windows.Forms.Label();
            this.LabelInputKeyLeft = new System.Windows.Forms.Label();
            this.LabelInputKeyRight = new System.Windows.Forms.Label();
            this.LabelInputKeyShoot = new System.Windows.Forms.Label();
            this.LabelInputKeyBulletTime = new System.Windows.Forms.Label();
            this.LabelPanelOptions = new System.Windows.Forms.Label();
            this.LabelScore = new System.Windows.Forms.Label();
            this.LabelX = new System.Windows.Forms.Label();
            this.LabelY = new System.Windows.Forms.Label();
            this.LabelHP = new System.Windows.Forms.Label();
            this.LabelSP = new System.Windows.Forms.Label();
            this.LabelHpIcon = new System.Windows.Forms.Label();
            this.LabelSpIcon = new System.Windows.Forms.Label();
            this.LabelFP = new System.Windows.Forms.Label();
            this.LabelFpIcon = new System.Windows.Forms.Label();
            this.LabelLevel = new System.Windows.Forms.Label();
            this.PanelStartScreen.SuspendLayout();
            this.PanelOptionsScreen.SuspendLayout();
            this.PanelEndScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBackground)).BeginInit();
            this.PictureBoxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGame)).BeginInit();
            this.PictureBoxGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelStartScreen
            // 
            this.PanelStartScreen.BackColor = System.Drawing.Color.Transparent;
            this.PanelStartScreen.Controls.Add(this.ButtonStart);
            this.PanelStartScreen.Controls.Add(this.ButtonOptions);
            this.PanelStartScreen.Controls.Add(this.ButtonExit);
            this.PanelStartScreen.Controls.Add(this.TitleStartScreen);
            this.PanelStartScreen.Location = new System.Drawing.Point(0, 0);
            this.PanelStartScreen.Name = "PanelStartScreen";
            this.PanelStartScreen.Size = new System.Drawing.Size(1020, 768);
            this.PanelStartScreen.TabIndex = 3;
            // 
            // ButtonStart
            // 
            this.ButtonStart.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonStart.Location = new System.Drawing.Point(341, 365);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(304, 66);
            this.ButtonStart.TabIndex = 4;
            this.ButtonStart.Text = "START";
            this.ButtonStart.UseCompatibleTextRendering = true;
            this.ButtonStart.UseVisualStyleBackColor = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonOptions
            // 
            this.ButtonOptions.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonOptions.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ButtonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonOptions.Location = new System.Drawing.Point(341, 465);
            this.ButtonOptions.Name = "ButtonOptions";
            this.ButtonOptions.Size = new System.Drawing.Size(304, 66);
            this.ButtonOptions.TabIndex = 4;
            this.ButtonOptions.Text = "OPTIONS";
            this.ButtonOptions.UseCompatibleTextRendering = true;
            this.ButtonOptions.UseVisualStyleBackColor = false;
            this.ButtonOptions.Click += new System.EventHandler(this.ButtonOptions_Click);
            // 
            // ButtonApplyOptions
            // 
            this.ButtonApplyOptions.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonApplyOptions.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonApplyOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonApplyOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonApplyOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonApplyOptions.Location = new System.Drawing.Point(390, 540);
            this.ButtonApplyOptions.Name = "ButtonApplyOptions";
            this.ButtonApplyOptions.Size = new System.Drawing.Size(90, 40);
            this.ButtonApplyOptions.TabIndex = 4;
            this.ButtonApplyOptions.Text = "APPLY";
            this.ButtonApplyOptions.UseCompatibleTextRendering = true;
            this.ButtonApplyOptions.UseVisualStyleBackColor = false;
            this.ButtonApplyOptions.Click += new System.EventHandler(this.ButtonApplyOptions_Click);
            // 
            // ButtonCancelOptions
            // 
            this.ButtonCancelOptions.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonCancelOptions.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonCancelOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancelOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCancelOptions.Location = new System.Drawing.Point(280, 540);
            this.ButtonCancelOptions.Name = "ButtonCancelOptions";
            this.ButtonCancelOptions.Size = new System.Drawing.Size(100, 40);
            this.ButtonCancelOptions.TabIndex = 4;
            this.ButtonCancelOptions.Text = "CANCEL";
            this.ButtonCancelOptions.UseCompatibleTextRendering = true;
            this.ButtonCancelOptions.UseVisualStyleBackColor = false;
            this.ButtonCancelOptions.Click += new System.EventHandler(this.ButtonExitOptions_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonExit.Location = new System.Drawing.Point(341, 565);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(304, 66);
            this.ButtonExit.TabIndex = 4;
            this.ButtonExit.Text = "EXIT";
            this.ButtonExit.UseCompatibleTextRendering = true;
            this.ButtonExit.UseVisualStyleBackColor = false;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // TitleStartScreen
            // 
            this.TitleStartScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleStartScreen.ForeColor = System.Drawing.Color.SlateGray;
            this.TitleStartScreen.Location = new System.Drawing.Point(200, 150);
            this.TitleStartScreen.Name = "TitleStartScreen";
            this.TitleStartScreen.Size = new System.Drawing.Size(1020, 388);
            this.TitleStartScreen.TabIndex = 5;
            this.TitleStartScreen.Text = "Hello World";
            this.TitleStartScreen.UseCompatibleTextRendering = true;
            // 
            // LabelPanelOptions
            //
            this.LabelPanelOptions.AutoSize = true;
            this.LabelPanelOptions.BackColor = System.Drawing.Color.Transparent;
            this.LabelPanelOptions.ForeColor = System.Drawing.Color.White;
            this.LabelPanelOptions.Location = new System.Drawing.Point(350, 20);
            this.LabelPanelOptions.Name = "LabelPanelOptions";
            this.LabelPanelOptions.Text = "Options";
            this.LabelPanelOptions.Size = new System.Drawing.Size(0, 16);
            this.LabelPanelOptions.TabIndex = 1;
            this.LabelPanelOptions.UseCompatibleTextRendering = true;
            // 
            // PanelOptionsScreen
            // 
            this.PanelOptionsScreen.BackColor = System.Drawing.Color.SlateGray;
            this.PanelOptionsScreen.Controls.Add(this.ButtonTabOptionsSound);
            this.PanelOptionsScreen.Controls.Add(this.ButtonTabOptionsKeyboard);
            this.PanelOptionsScreen.Controls.Add(this.PanelOptionsSound);
            this.PanelOptionsScreen.Controls.Add(this.PanelOptionsKeyboard);
            this.PanelOptionsScreen.Controls.Add(this.LabelPanelOptions);
            this.PanelOptionsScreen.Controls.Add(this.ButtonApplyOptions);
            this.PanelOptionsScreen.Controls.Add(this.ButtonCancelOptions);
            this.PanelOptionsScreen.Location = new System.Drawing.Point(this.Width - (this.PanelOptionsScreen.Size.Width /4), this.Height /4);
            this.PanelOptionsScreen.Name = "PanelOptionsScreen";
            this.PanelOptionsScreen.Size = new System.Drawing.Size(500, 600);
            this.PanelOptionsScreen.TabIndex = 3;
            // 
            // ButtonTabOptionsSound
            // 
            this.ButtonTabOptionsSound.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonTabOptionsSound.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonTabOptionsSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTabOptionsSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTabOptionsSound.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonTabOptionsSound.Location = new System.Drawing.Point(20, 61);
            this.ButtonTabOptionsSound.Name = "ButtonTabOptionsSound";
            this.ButtonTabOptionsSound.Size = new System.Drawing.Size(90, 40);
            this.ButtonTabOptionsSound.TabIndex = 4;
            this.ButtonTabOptionsSound.Text = "SOUND";
            this.ButtonTabOptionsSound.UseCompatibleTextRendering = true;
            this.ButtonTabOptionsSound.UseVisualStyleBackColor = false;
            this.ButtonTabOptionsSound.Click += new System.EventHandler(this.ButtonTabOptionsSound_Click);
            // 
            // PanelOptionsSound
            //
            this.PanelOptionsSound.Controls.Add(this.TrackBarMasterVolume);
            this.PanelOptionsSound.Controls.Add(this.TrackBarMasterMusicVolume);
            this.PanelOptionsSound.Controls.Add(this.TrackBarMasterFxVolume);
            this.PanelOptionsSound.Controls.Add(this.LabelMasterVolume);
            this.PanelOptionsSound.Controls.Add(this.LabelMasterMusicVolume);
            this.PanelOptionsSound.Controls.Add(this.LabelMasterVolumeNumber);
            this.PanelOptionsSound.Controls.Add(this.LabelMasterMusicVolumeNumber);
            this.PanelOptionsSound.Controls.Add(this.LabelMasterFxVolume);
            this.PanelOptionsSound.Controls.Add(this.LabelMasterFxVolumeNumber);
            this.PanelOptionsSound.Location = new System.Drawing.Point(20, 100);
            this.PanelOptionsSound.Name = "PanelOptionsSound";
            this.PanelOptionsSound.Size = new System.Drawing.Size(460, 420);
            this.PanelOptionsSound.TabIndex = 3;
            this.PanelOptionsSound.Paint += new System.Windows.Forms.PaintEventHandler(BorderPanelOptions_Paint);
            // 
            // LabelMasterVolume
            //
            this.LabelMasterVolume.AutoSize = true;
            this.LabelMasterVolume.BackColor = System.Drawing.Color.Transparent;
            this.LabelMasterVolume.ForeColor = System.Drawing.Color.White;
            this.LabelMasterVolume.Location = new System.Drawing.Point(20, 60);
            this.LabelMasterVolume.Name = "LabelMasterVolume";
            this.LabelMasterVolume.Text = "Main Volume";
            this.LabelMasterVolume.Size = new System.Drawing.Size(0, 16);
            this.LabelMasterVolume.TabIndex = 1;
            this.LabelMasterVolume.UseCompatibleTextRendering = true;
            // 
            // TrackBarMasterVolume
            //
            this.TrackBarMasterVolume.BackColor = System.Drawing.Color.SlateGray;
            this.TrackBarMasterVolume.TickStyle = TickStyle.None;
            this.TrackBarMasterVolume.Location = new System.Drawing.Point(20, 90);
            this.TrackBarMasterVolume.ValueChanged += new System.EventHandler(OnMasterVolumeUpdated);
            this.TrackBarMasterVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarMasterVolume.Name = "TrackBarMasterVolume";
            this.TrackBarMasterVolume.Size = new System.Drawing.Size(300, 2);
            this.TrackBarMasterVolume.TabIndex = 3;
            // 
            // LabelMasterVolumeNumber
            //
            this.LabelMasterVolumeNumber.AutoSize = true;
            this.LabelMasterVolumeNumber.BackColor = System.Drawing.Color.Transparent;
            this.LabelMasterVolumeNumber.ForeColor = System.Drawing.Color.White;
            this.LabelMasterVolumeNumber.Location = new System.Drawing.Point(320, 90);
            this.LabelMasterVolumeNumber.Name = "LabelMasterVolumeNumber";
            this.LabelMasterVolumeNumber.Size = new System.Drawing.Size(0, 16);
            this.LabelMasterVolumeNumber.TabIndex = 1;
            this.LabelMasterVolumeNumber.UseCompatibleTextRendering = true;
            // 
            // LabelMasterMusicVolume
            //
            this.LabelMasterMusicVolume.AutoSize = true;
            this.LabelMasterMusicVolume.BackColor = System.Drawing.Color.Transparent;
            this.LabelMasterMusicVolume.ForeColor = System.Drawing.Color.White;
            this.LabelMasterMusicVolume.Location = new System.Drawing.Point(20, 140);
            this.LabelMasterMusicVolume.Name = "LabelMasterMusicVolume";
            this.LabelMasterMusicVolume.Text = "Music Volume";
            this.LabelMasterMusicVolume.Size = new System.Drawing.Size(0, 16);
            this.LabelMasterMusicVolume.TabIndex = 1;
            this.LabelMasterMusicVolume.UseCompatibleTextRendering = true;
            // 
            // TrackBarMasterMusicVolume
            //
            this.TrackBarMasterMusicVolume.BackColor = System.Drawing.Color.SlateGray;
            this.TrackBarMasterMusicVolume.TickStyle = TickStyle.None;
            this.TrackBarMasterMusicVolume.Location = new System.Drawing.Point(20, 170);
            this.TrackBarMasterMusicVolume.ValueChanged += new System.EventHandler(OnMasterMusicVolumeUpdated);
            this.TrackBarMasterMusicVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarMasterMusicVolume.Name = "TrackBarMasterMusicVolume";
            this.TrackBarMasterMusicVolume.Size = new System.Drawing.Size(300, 5);
            this.TrackBarMasterMusicVolume.TabIndex = 3;
            // 
            // LabelMasterMusicVolumeNumber
            //
            this.LabelMasterMusicVolumeNumber.AutoSize = true;
            this.LabelMasterMusicVolumeNumber.BackColor = System.Drawing.Color.Transparent;
            this.LabelMasterMusicVolumeNumber.ForeColor = System.Drawing.Color.White;
            this.LabelMasterMusicVolumeNumber.Location = new System.Drawing.Point(320, 170);
            this.LabelMasterMusicVolumeNumber.Name = "LabelMasterMusicVolumeNumber";
            this.LabelMasterMusicVolumeNumber.Size = new System.Drawing.Size(0, 16);
            this.LabelMasterMusicVolumeNumber.TabIndex = 1;
            this.LabelMasterMusicVolumeNumber.UseCompatibleTextRendering = true;
            // 
            // LabelMasterFxVolume
            //
            this.LabelMasterFxVolume.AutoSize = true;
            this.LabelMasterFxVolume.BackColor = System.Drawing.Color.Transparent;
            this.LabelMasterFxVolume.ForeColor = System.Drawing.Color.White;
            this.LabelMasterFxVolume.Location = new System.Drawing.Point(20, 220);
            this.LabelMasterFxVolume.Name = "LabelMasterFxVolume";
            this.LabelMasterFxVolume.Text = "Effect Volume";
            this.LabelMasterFxVolume.Size = new System.Drawing.Size(0, 16);
            this.LabelMasterFxVolume.TabIndex = 1;
            this.LabelMasterFxVolume.UseCompatibleTextRendering = true;
            // 
            // TrackBarMasterFxVolume
            //
            this.TrackBarMasterFxVolume.BackColor = System.Drawing.Color.SlateGray;
            this.TrackBarMasterFxVolume.TickStyle = TickStyle.None;
            this.TrackBarMasterFxVolume.Location = new System.Drawing.Point(20, 250);
            this.TrackBarMasterFxVolume.ValueChanged += new System.EventHandler(OnMasterFxVolumeUpdated);
            this.TrackBarMasterFxVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarMasterFxVolume.Name = "TrackBarMasterFxVolume";
            this.TrackBarMasterFxVolume.Size = new System.Drawing.Size(300, 5);
            this.TrackBarMasterFxVolume.TabIndex = 3;
            // 
            // LabelMasterMusicVolumeNumber
            //
            this.LabelMasterFxVolumeNumber.AutoSize = true;
            this.LabelMasterFxVolumeNumber.BackColor = System.Drawing.Color.Transparent;
            this.LabelMasterFxVolumeNumber.ForeColor = System.Drawing.Color.White;
            this.LabelMasterFxVolumeNumber.Location = new System.Drawing.Point(320, 250);
            this.LabelMasterFxVolumeNumber.Name = "LabelMasterFxVolumeNumber";
            this.LabelMasterFxVolumeNumber.Size = new System.Drawing.Size(0, 16);
            this.LabelMasterFxVolumeNumber.TabIndex = 1;
            this.LabelMasterFxVolumeNumber.UseCompatibleTextRendering = true;
            // 
            // ButtonTabOptionsKeyboard
            // 
            this.ButtonTabOptionsKeyboard.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonTabOptionsKeyboard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonTabOptionsKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTabOptionsKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTabOptionsKeyboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonTabOptionsKeyboard.Location = new System.Drawing.Point(110, 61);
            this.ButtonTabOptionsKeyboard.Name = "ButtonTabOptionsKeyboard";
            this.ButtonTabOptionsKeyboard.Size = new System.Drawing.Size(100, 40);
            this.ButtonTabOptionsKeyboard.TabIndex = 4;
            this.ButtonTabOptionsKeyboard.Text = "KEYBOARD";
            this.ButtonTabOptionsKeyboard.UseCompatibleTextRendering = true;
            this.ButtonTabOptionsKeyboard.UseVisualStyleBackColor = false;
            this.ButtonTabOptionsKeyboard.Click += new System.EventHandler(this.ButtonTabOptionsKeyboard_Click);
            // 
            // PanelOptionsKeyboard
            //
            this.PanelOptionsKeyboard.Location = new System.Drawing.Point(20, 100);
            this.PanelOptionsKeyboard.Controls.Add(this.LabelInputKeyUp);
            this.PanelOptionsKeyboard.Controls.Add(this.LabelInputKeyDown);
            this.PanelOptionsKeyboard.Controls.Add(this.LabelInputKeyLeft);
            this.PanelOptionsKeyboard.Controls.Add(this.LabelInputKeyRight);
            this.PanelOptionsKeyboard.Controls.Add(this.LabelInputKeyShoot);
            this.PanelOptionsKeyboard.Controls.Add(this.LabelInputKeyBulletTime);
            this.PanelOptionsKeyboard.Controls.Add(this.TextBoxKeyUp);
            this.PanelOptionsKeyboard.Controls.Add(this.TextBoxKeyDown);
            this.PanelOptionsKeyboard.Controls.Add(this.TextBoxKeyLeft);
            this.PanelOptionsKeyboard.Controls.Add(this.TextBoxKeyRight);
            this.PanelOptionsKeyboard.Controls.Add(this.TextBoxKeyShoot);
            this.PanelOptionsKeyboard.Controls.Add(this.TextBoxKeyBulletTime);
            this.PanelOptionsKeyboard.Name = "PanelOptionsSound";
            this.PanelOptionsKeyboard.Size = new System.Drawing.Size(460, 420);
            this.PanelOptionsKeyboard.TabIndex = 3;
            this.PanelOptionsKeyboard.Paint += new System.Windows.Forms.PaintEventHandler(BorderPanelOptions_Paint);
            // 
            // LabelInputKeyUp
            //
            this.LabelInputKeyUp.AutoSize = true;
            this.LabelInputKeyUp.BackColor = System.Drawing.Color.Transparent;
            this.LabelInputKeyUp.ForeColor = System.Drawing.Color.White;
            this.LabelInputKeyUp.Location = new System.Drawing.Point(50, 60);
            this.LabelInputKeyUp.Name = "LabelInputKeyUp";
            this.LabelInputKeyUp.Text = "Forward";
            this.LabelInputKeyUp.Size = new System.Drawing.Size(0, 16);
            this.LabelInputKeyUp.TabIndex = 1;
            this.LabelInputKeyUp.UseCompatibleTextRendering = true;
            this.LabelInputKeyUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //
            // Input KeyUp
            //
            this.TextBoxKeyUp.Size = new System.Drawing.Size(60, 20);
            this.TextBoxKeyUp.Location = new System.Drawing.Point(200, 60);
            this.TextBoxKeyUp.MaxLength = 1;
            this.TextBoxKeyUp.KeyDown += TextBoxUserKeyUp_KeyDown;
            this.TextBoxKeyUp.BackColor = System.Drawing.Color.SlateGray;
            this.TextBoxKeyUp.ForeColor = System.Drawing.Color.White;
            this.TextBoxKeyUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LabelInputKeyDown
            //
            this.LabelInputKeyDown.AutoSize = true;
            this.LabelInputKeyDown.BackColor = System.Drawing.Color.Transparent;
            this.LabelInputKeyDown.ForeColor = System.Drawing.Color.White;
            this.LabelInputKeyDown.Location = new System.Drawing.Point(50, 120);
            this.LabelInputKeyDown.Name = "LabelInputKeyDown";
            this.LabelInputKeyDown.Text = "Backward";
            this.LabelInputKeyDown.Size = new System.Drawing.Size(0, 16);
            this.LabelInputKeyDown.TabIndex = 1;
            this.LabelInputKeyDown.UseCompatibleTextRendering = true;
            this.LabelInputKeyDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //
            // Input KeyDown
            //
            this.TextBoxKeyDown.Size = new System.Drawing.Size(60, 20);
            this.TextBoxKeyDown.Location = new System.Drawing.Point(200, 120);
            this.TextBoxKeyDown.MaxLength = 1;
            this.TextBoxKeyDown.KeyDown += TextBoxUserKeyDown_KeyDown;
            this.TextBoxKeyDown.BackColor = System.Drawing.Color.SlateGray;
            this.TextBoxKeyDown.ForeColor = System.Drawing.Color.White;
            this.TextBoxKeyDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LabelInputKeyLeft
            //
            this.LabelInputKeyLeft.AutoSize = true;
            this.LabelInputKeyLeft.BackColor = System.Drawing.Color.Transparent;
            this.LabelInputKeyLeft.ForeColor = System.Drawing.Color.White;
            this.LabelInputKeyLeft.Location = new System.Drawing.Point(50, 180);
            this.LabelInputKeyLeft.Name = "LabelInputKeyLeft";
            this.LabelInputKeyLeft.Text = "Leftward";
            this.LabelInputKeyLeft.Size = new System.Drawing.Size(0, 16);
            this.LabelInputKeyLeft.TabIndex = 1;
            this.LabelInputKeyLeft.UseCompatibleTextRendering = true;
            this.LabelInputKeyLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //                
            // Input KeyLeft
            //
            this.TextBoxKeyLeft.Size = new System.Drawing.Size(60, 20);
            this.TextBoxKeyLeft.Location = new System.Drawing.Point(200, 180);
            this.TextBoxKeyLeft.MaxLength = 1;
            this.TextBoxKeyLeft.KeyDown += TextBoxUserKeyLeft_KeyDown;
            this.TextBoxKeyLeft.BackColor = System.Drawing.Color.SlateGray;
            this.TextBoxKeyLeft.ForeColor = System.Drawing.Color.White;
            this.TextBoxKeyLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LabelInputKeyRight
            //
            this.LabelInputKeyRight.AutoSize = true;
            this.LabelInputKeyRight.BackColor = System.Drawing.Color.Transparent;
            this.LabelInputKeyRight.ForeColor = System.Drawing.Color.White;
            this.LabelInputKeyRight.Location = new System.Drawing.Point(50, 240);
            this.LabelInputKeyRight.Name = "LabelInputKeyRight";
            this.LabelInputKeyRight.Text = "Rightward";
            this.LabelInputKeyRight.Size = new System.Drawing.Size(0, 16);
            this.LabelInputKeyRight.TabIndex = 1;
            this.LabelInputKeyRight.UseCompatibleTextRendering = true;
            this.LabelInputKeyRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //
            // Input KeyRight
            //
            this.TextBoxKeyRight.Size = new System.Drawing.Size(60, 20);
            this.TextBoxKeyRight.Location = new System.Drawing.Point(200, 240);
            this.TextBoxKeyRight.MaxLength = 1;
            this.TextBoxKeyRight.KeyDown += TextBoxUserKeyRight_KeyDown;
            this.TextBoxKeyRight.BackColor = System.Drawing.Color.SlateGray;
            this.TextBoxKeyRight.ForeColor = System.Drawing.Color.White;
            this.TextBoxKeyRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LabelInputKeyShoot
            //
            this.LabelInputKeyShoot.AutoSize = true;
            this.LabelInputKeyShoot.BackColor = System.Drawing.Color.Transparent;
            this.LabelInputKeyShoot.ForeColor = System.Drawing.Color.White;
            this.LabelInputKeyShoot.Location = new System.Drawing.Point(50, 300);
            this.LabelInputKeyShoot.Name = "LabelInputKeyShoot";
            this.LabelInputKeyShoot.Text = "Shoot";
            this.LabelInputKeyShoot.Size = new System.Drawing.Size(0, 16);
            this.LabelInputKeyShoot.TabIndex = 1;
            this.LabelInputKeyShoot.UseCompatibleTextRendering = true;
            //             
            // Input KeyShoot
            //
            this.TextBoxKeyShoot.Size = new System.Drawing.Size(60, 20);
            this.TextBoxKeyShoot.Location = new System.Drawing.Point(200, 300);
            this.TextBoxKeyShoot.MaxLength = 1;
            this.TextBoxKeyShoot.KeyDown += TextBoxUserKeyShoot_KeyDown;
            this.TextBoxKeyShoot.BackColor = System.Drawing.Color.SlateGray;
            this.TextBoxKeyShoot.ForeColor = System.Drawing.Color.White;
            this.TextBoxKeyShoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LabelInputKeyBulletTime
            //
            this.LabelInputKeyBulletTime.AutoSize = true;
            this.LabelInputKeyBulletTime.BackColor = System.Drawing.Color.Transparent;
            this.LabelInputKeyBulletTime.ForeColor = System.Drawing.Color.White;
            this.LabelInputKeyBulletTime.Location = new System.Drawing.Point(50, 360);
            this.LabelInputKeyBulletTime.Name = "LabelInputKeyBulletTime";
            this.LabelInputKeyBulletTime.Text = "Bullet Time";
            this.LabelInputKeyBulletTime.Size = new System.Drawing.Size(0, 16);
            this.LabelInputKeyBulletTime.TabIndex = 1;
            this.LabelInputKeyBulletTime.UseCompatibleTextRendering = true;
            //             
            // Input KeyBulletTime
            //
            this.TextBoxKeyBulletTime.Size = new System.Drawing.Size(60, 20);
            this.TextBoxKeyBulletTime.Location = new System.Drawing.Point(200, 360);
            this.TextBoxKeyBulletTime.MaxLength = 1;
            this.TextBoxKeyBulletTime.KeyDown += TextBoxUserKeyBulletTime_KeyDown;
            this.TextBoxKeyBulletTime.BackColor = System.Drawing.Color.SlateGray;
            this.TextBoxKeyBulletTime.ForeColor = System.Drawing.Color.White;
            this.TextBoxKeyBulletTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //          
            // PanelEndScreen
            // 
            this.PanelEndScreen.BackColor = System.Drawing.Color.Transparent;
            this.PanelEndScreen.Controls.Add(this.LabelScoreEndScreen);
            this.PanelEndScreen.Controls.Add(this.ButtonRestartEndScreen);
            this.PanelEndScreen.Controls.Add(this.ButtonExitEndScreen);
            this.PanelEndScreen.Location = new System.Drawing.Point(0, 0);
            this.PanelEndScreen.Name = "PanelEndScreen";
            this.PanelEndScreen.Size = new System.Drawing.Size(1020, 768);
            this.PanelEndScreen.TabIndex = 3;
            // 
            // LabelScoreEndScreen
            // 
            this.LabelScoreEndScreen.AutoSize = true;
            this.LabelScoreEndScreen.BackColor = System.Drawing.Color.Transparent;
            this.LabelScoreEndScreen.ForeColor = System.Drawing.Color.White;
            this.LabelScoreEndScreen.Location = new System.Drawing.Point(20, 20);
            this.LabelScoreEndScreen.Name = "LabelScoreEndScreen";
            this.LabelScoreEndScreen.Size = new System.Drawing.Size(0, 16);
            this.LabelScoreEndScreen.TabIndex = 1;
            this.LabelScoreEndScreen.UseCompatibleTextRendering = true;
            // 
            // ButtonRestartEndScreen
            // 
            this.ButtonRestartEndScreen.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonRestartEndScreen.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ButtonRestartEndScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRestartEndScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRestartEndScreen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonRestartEndScreen.Location = new System.Drawing.Point(341, 365);
            this.ButtonRestartEndScreen.Name = "ButtonRestartEndScreen";
            this.ButtonRestartEndScreen.Size = new System.Drawing.Size(304, 66);
            this.ButtonRestartEndScreen.TabIndex = 4;
            this.ButtonRestartEndScreen.Text = "RESTART";
            this.ButtonRestartEndScreen.UseCompatibleTextRendering = true;
            this.ButtonRestartEndScreen.UseVisualStyleBackColor = false;
            this.ButtonRestartEndScreen.Click += new System.EventHandler(this.ButtonRestart_Click);
            // 
            // ButtonExitEndScreen
            // 
            this.ButtonExitEndScreen.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonExitEndScreen.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ButtonExitEndScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExitEndScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExitEndScreen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonExitEndScreen.Location = new System.Drawing.Point(341, 500);
            this.ButtonExitEndScreen.Name = "ButtonExitEndScreen";
            this.ButtonExitEndScreen.Size = new System.Drawing.Size(304, 66);
            this.ButtonExitEndScreen.TabIndex = 4;
            this.ButtonExitEndScreen.Text = "EXIT";
            this.ButtonExitEndScreen.UseCompatibleTextRendering = true;
            this.ButtonExitEndScreen.UseVisualStyleBackColor = false;
            this.ButtonExitEndScreen.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // PictureBoxBackground
            // 
            this.PictureBoxBackground.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxBackground.Controls.Add(this.PictureBoxGame);
            this.PictureBoxBackground.Controls.Add(this.PanelStartScreen);
            this.PictureBoxBackground.Controls.Add(this.PanelOptionsScreen);
            this.PictureBoxBackground.Controls.Add(this.PanelEndScreen);
            this.PictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxBackground.Name = "PictureBoxBackground";
            this.PictureBoxBackground.Size = new System.Drawing.Size(1020, 768);
            this.PictureBoxBackground.TabIndex = 3;
            this.PictureBoxBackground.TabStop = false;
            this.PictureBoxBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxBackground_Paint);
            // 
            // PictureBoxGame
            // 
            this.PictureBoxGame.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxGame.Controls.Add(this.LabelScore);
            this.PictureBoxGame.Controls.Add(this.LabelLevel);
            this.PictureBoxGame.Controls.Add(this.LabelX);
            this.PictureBoxGame.Controls.Add(this.LabelY);
            this.PictureBoxGame.Controls.Add(this.LabelHP);
            this.PictureBoxGame.Controls.Add(this.LabelSP);
            this.PictureBoxGame.Controls.Add(this.LabelHpIcon);
            this.PictureBoxGame.Controls.Add(this.LabelSpIcon);
            this.PictureBoxGame.Controls.Add(this.LabelFP);
            this.PictureBoxGame.Controls.Add(this.LabelFpIcon);
            this.PictureBoxGame.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxGame.Name = "PictureBoxGame";
            this.PictureBoxGame.Size = new System.Drawing.Size(1020, 768);
            this.PictureBoxGame.TabIndex = 2;
            this.PictureBoxGame.TabStop = false;
            this.PictureBoxGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxGame_Paint);
            this.PictureBoxGame.MouseLeave += new System.EventHandler(this.PictureBoxGame_MouseLeave);
            this.PictureBoxGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxGame_MouseMove);
            // 
            // LabelScore
            // 
            this.LabelScore.AutoSize = true;
            this.LabelScore.BackColor = System.Drawing.Color.Transparent;
            this.LabelScore.ForeColor = System.Drawing.Color.White;
            this.LabelScore.Location = new System.Drawing.Point(20, 20);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(0, 16);
            this.LabelScore.TabIndex = 1;
            this.LabelScore.UseCompatibleTextRendering = true;
            // 
            // LabelX
            // 
            this.LabelX.AutoSize = true;
            this.LabelX.BackColor = System.Drawing.Color.Transparent;
            this.LabelX.ForeColor = System.Drawing.Color.White;
            this.LabelX.Location = new System.Drawing.Point(950, 715);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(0, 16);
            this.LabelX.TabIndex = 2;
            this.LabelX.UseCompatibleTextRendering = true;
            // 
            // LabelY
            // 
            this.LabelY.AutoSize = true;
            this.LabelY.BackColor = System.Drawing.Color.Transparent;
            this.LabelY.ForeColor = System.Drawing.Color.White;
            this.LabelY.Location = new System.Drawing.Point(950, 737);
            this.LabelY.Name = "LabelY";
            this.LabelY.Size = new System.Drawing.Size(0, 16);
            this.LabelY.TabIndex = 3;
            this.LabelY.UseCompatibleTextRendering = true;
            // 
            // LabelHP
            // 
            this.LabelHP.AutoSize = true;
            this.LabelHP.BackColor = System.Drawing.Color.Transparent;
            this.LabelHP.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelHP.Location = new System.Drawing.Point(50, 685);
            this.LabelHP.Name = "LabelHP";
            this.LabelHP.Size = new System.Drawing.Size(0, 16);
            this.LabelHP.TabIndex = 1;
            this.LabelHP.UseCompatibleTextRendering = true;
            // 
            // LabelSP
            // 
            this.LabelSP.AutoSize = true;
            this.LabelSP.BackColor = System.Drawing.Color.Transparent;
            this.LabelSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(187)))), ((int)(((byte)(245)))));
            this.LabelSP.Location = new System.Drawing.Point(50, 710);
            this.LabelSP.Name = "LabelSP";
            this.LabelSP.Size = new System.Drawing.Size(0, 16);
            this.LabelSP.TabIndex = 1;
            this.LabelSP.UseCompatibleTextRendering = true;
            // 
            // LabelHpIcon
            // 
            this.LabelHpIcon.BackColor = System.Drawing.Color.Transparent;
            this.LabelHpIcon.Location = new System.Drawing.Point(20, 685);
            this.LabelHpIcon.Name = "LabelHpIcon";
            this.LabelHpIcon.Size = new System.Drawing.Size(20, 17);
            this.LabelHpIcon.TabIndex = 1;
            this.LabelHpIcon.UseCompatibleTextRendering = true;
            // 
            // LabelSpIcon
            // 
            this.LabelSpIcon.BackColor = System.Drawing.Color.Transparent;
            this.LabelSpIcon.Location = new System.Drawing.Point(20, 710);
            this.LabelSpIcon.Name = "LabelSpIcon";
            this.LabelSpIcon.Size = new System.Drawing.Size(20, 17);
            this.LabelSpIcon.TabIndex = 1;
            this.LabelSpIcon.UseCompatibleTextRendering = true;
            // 
            // LabelFP
            // 
            this.LabelFP.AutoSize = true;
            this.LabelFP.BackColor = System.Drawing.Color.Transparent;
            this.LabelFP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.LabelFP.Location = new System.Drawing.Point(50, 735);
            this.LabelFP.Name = "LabelFP";
            this.LabelFP.Size = new System.Drawing.Size(0, 16);
            this.LabelFP.TabIndex = 1;
            this.LabelFP.UseCompatibleTextRendering = true;
            // 
            // LabelFpIcon
            // 
            this.LabelFpIcon.BackColor = System.Drawing.Color.Transparent;
            this.LabelFpIcon.Location = new System.Drawing.Point(20, 735);
            this.LabelFpIcon.Name = "LabelFpIcon";
            this.LabelFpIcon.Size = new System.Drawing.Size(20, 17);
            this.LabelFpIcon.TabIndex = 1;
            this.LabelFpIcon.UseCompatibleTextRendering = true;
            // 
            // LabelLevel
            // 
            this.LabelLevel.AutoSize = true;
            this.LabelLevel.BackColor = System.Drawing.Color.Transparent;
            this.LabelLevel.ForeColor = System.Drawing.Color.White;
            this.LabelLevel.Location = new System.Drawing.Point(20, 50);
            this.LabelLevel.Name = "LabelLevel";
            this.LabelLevel.Size = new System.Drawing.Size(0, 16);
            this.LabelLevel.TabIndex = 1;
            this.LabelLevel.UseCompatibleTextRendering = true;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1020, 768);
            this.Controls.Add(this.PictureBoxBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::covidvader.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "MainFrame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyUp);
            this.PanelStartScreen.ResumeLayout(false);
            this.PanelOptionsScreen.ResumeLayout(false);
            this.PanelEndScreen.ResumeLayout(false);
            this.PanelEndScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBackground)).EndInit();
            this.PictureBoxBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGame)).EndInit();
            this.PictureBoxGame.ResumeLayout(false);
            this.PictureBoxGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxBackground;
        private System.Windows.Forms.PictureBox PictureBoxGame;
        private System.Windows.Forms.Panel PanelStartScreen;
        private System.Windows.Forms.Panel PanelOptionsScreen;
        private System.Windows.Forms.Panel PanelOptionsSound;
        private System.Windows.Forms.Panel PanelOptionsKeyboard;
        private System.Windows.Forms.Panel PanelEndScreen;
        private System.Windows.Forms.Label LabelPanelOptions;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Label LabelLevel;
        private System.Windows.Forms.Label TitleStartScreen;
        private System.Windows.Forms.Label LabelScoreEndScreen;
        private System.Windows.Forms.Label LabelY;
        private System.Windows.Forms.Label LabelX;
        private System.Windows.Forms.Label LabelHP;
        private System.Windows.Forms.Label LabelHpIcon;
        private System.Windows.Forms.Label LabelSP;
        private System.Windows.Forms.Label LabelSpIcon;
        private System.Windows.Forms.Label LabelFP;
        private System.Windows.Forms.Label LabelFpIcon;
        private System.Windows.Forms.Label LabelMasterVolume;
        private System.Windows.Forms.Label LabelMasterVolumeNumber;
        private System.Windows.Forms.Label LabelMasterMusicVolume;
        private System.Windows.Forms.Label LabelMasterMusicVolumeNumber;
        private System.Windows.Forms.Label LabelMasterFxVolume;
        private System.Windows.Forms.Label LabelMasterFxVolumeNumber;
        private System.Windows.Forms.Label LabelInputKeyUp;
        private System.Windows.Forms.Label LabelInputKeyDown;
        private System.Windows.Forms.Label LabelInputKeyLeft;
        private System.Windows.Forms.Label LabelInputKeyRight;
        private System.Windows.Forms.Label LabelInputKeyShoot;
        private System.Windows.Forms.Label LabelInputKeyBulletTime;


        private TrackBar TrackBarMasterVolume;
        private TrackBar TrackBarMasterMusicVolume;
        private TrackBar TrackBarMasterFxVolume;
        private TextBox TextBoxKeyUp;
        private TextBox TextBoxKeyDown;
        private TextBox TextBoxKeyLeft;
        private TextBox TextBoxKeyRight;
        private TextBox TextBoxKeyShoot;
        private TextBox TextBoxKeyBulletTime;
        private Button ButtonStart;
        private Button ButtonOptions;
        private Button ButtonApplyOptions;
        private Button ButtonTabOptionsSound;
        private Button ButtonTabOptionsKeyboard;
        private Button ButtonCancelOptions;
        private Button ButtonExit;
        private Button ButtonExitEndScreen;
        private Button ButtonRestartEndScreen;
        //private readonly EventHandler PictureBoxGame_Click;
    }
}

