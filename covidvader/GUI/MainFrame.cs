using covidvader.Properties;
using CovidVader.Core;
using CovidVader.Entities;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CovidVader.Core.Audio;

namespace CovidVader.GUI
{
    public partial class MainFrame : Form
    {
        /// <summary>
        /// Game core engine
        /// </summary>
        private readonly GameEngine GameEngine;

        /// <summary>
        /// Custom FontCollection
        /// </summary>
        private PrivateFontCollection Pfc;

        /// <summary>
        /// Key direction pushed number
        /// </summary>
        private bool KeyDirectionUpPushedNb;
        private bool KeyDirectionRightPushedNb;
        private bool KeyDirectionDownPushedNb;
        private bool KeyDirectionLeftPushedNb;

        /// <summary>
        /// User Settings
        /// </summary>
        private readonly GameOptions GameOptions;

        /// <summary>
        /// ctor
        /// </summary>
        public MainFrame()
        {
            InitializeComponent();
            this.InitCusomLabelFont();
            this.GameEngine = new GameEngine(this.PictureBoxGame.Width, this.PictureBoxGame.Height);
            this.GameEngine.EntitiesUpdated += OnEntitiesUpdated;
            this.GameEngine.BackgroundUpdated += OnBackgroundUpdated;
            this.GameEngine.ScoreUpdated += OnScoreUpdated;
            this.GameEngine.LevelUpdated += OnLevelUpdated;
            this.GameEngine.GameFinished += OnGameFinished;
            this.GameEngine.ShipInformationsUpdated += OnShipInformationsUpdated;
            this.PictureBoxGame.Visible = false;
            this.PanelEndScreen.Visible = false;
            this.PanelOptionsScreen.Visible = false;
            this.LabelHpIcon.Image = Resources.powerupRed_star;
            this.LabelSpIcon.Image = Resources.powerupBlue_shield;
            this.LabelFpIcon.Image = Resources.powerupYellow_bolt;
            this.TrackBarMasterVolume.Maximum = 100;
            this.TrackBarMasterVolume.Minimum = 0;
            this.TrackBarMasterMusicVolume.Maximum = 100;
            this.TrackBarMasterMusicVolume.Minimum = 0;
            this.TrackBarMasterFxVolume.Maximum = 100;
            this.TrackBarMasterFxVolume.Minimum = 0;

            this.GameOptions = this.GameEngine.GetGameOptions();
            this.TrackBarMasterVolume.Value = this.GameOptions.MasterVolume;
            this.TrackBarMasterMusicVolume.Value = this.GameOptions.MusicVolume;
            this.TrackBarMasterFxVolume.Value = this.GameOptions.FxVolume;
            this.TextBoxKeyUp.Text = this.GameEngine.GetGameOptions().UserKeyUp.ToString();
            this.TextBoxKeyDown.Text = this.GameEngine.GetGameOptions().UserKeyDown.ToString();
            this.TextBoxKeyLeft.Text = this.GameEngine.GetGameOptions().UserKeyLeft.ToString();
            this.TextBoxKeyRight.Text = this.GameEngine.GetGameOptions().UserKeyRight.ToString();
            this.TextBoxKeyShoot.Text = this.GameEngine.GetGameOptions().UserKeyShoot.ToString();
            this.TextBoxKeyBulletTime.Text = this.GameEngine.GetGameOptions().UserKeyBulletTime.ToString();

        }

        /// <summary>
        ///  Update the hp and sp
        /// </summary>
        /// <param name="hp">health point</param>
        /// <param name="sp">shield point</param>
        private delegate void UpdateHpAndSp(int hp, int sp, int fp);

        /// <summary>
        ///  Display the hp and sp
        /// </summary>
        /// <param name="hp">health point</param>
        /// <param name="sp">shield point</param>
        private void DisplayHpAndSp(int hp, int sp, int fp)
        {
            this.LabelHP.Text = $"{hp}";
            this.LabelSP.Text = $"{sp}";
            this.LabelFP.Text = $"{fp}";
        }

        /// <summary>
        /// OnShipInformationsUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShipInformationsUpdated(object sender, ShipInformationsUpdatedEventArg e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateHpAndSp(DisplayHpAndSp), e.Hp, e.Sp, e.Fp);
                return;
            }
            else
                DisplayHpAndSp(e.Hp, e.Sp, e.Fp);
        }

        /// <summary>
        /// Action to launch the update of the score
        /// </summary>
        /// <param name="score">score to display</param>
        private delegate void UpdateScore(int score);

        /// <summary>
        /// Action to launch the update of the level
        /// </summary>
        /// <param name="level"></param>
        private delegate void UpdateLevel(int level);

        /// <summary>
        /// Display the score 
        /// </summary>
        /// <param name="score">score to display</param>
        private void DisplayScore(int score)
        {
            this.LabelScore.Text = $"Score    {score}";

        }

        /// <summary>
        /// Display the level
        /// </summary>
        /// <param name="level"></param>
        ///
        private void DisplayLevel(int level)
        {
            this.LabelLevel.Text = $"Level    {level}";
        }

        /// <summary>
        /// OnScoreUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnScoreUpdated(object sender, ScoreUpdatedEventArg e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateScore(DisplayScore), e.Score);
                return;
            }
            else
                DisplayScore(e.Score);

        }

        /// <summary>
        /// OnLevelUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLevelUpdated(object sender, LevelUpdatedEventArg e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateLevel(DisplayLevel), e.Level);
                return;
            }
            else
                DisplayLevel(e.Level);

        }

        /// <summary>
        /// Action to launch the display of the end screen
        /// </summary>
        private delegate void EndOfGame(int score);

        /// <summary>
        /// Display the end screen
        /// </summary>
        private void DisplayEndScreen(int score)
        {
            this.LabelScoreEndScreen.Text = $"Score    {score}";
            this.LabelScoreEndScreen.Location = new Point(this.Width / 2 - (this.LabelScoreEndScreen.Size.Width / 2), this.Height / 4);
            this.PanelEndScreen.Visible = true;
            this.PictureBoxGame.Visible = false;
            System.Console.WriteLine("Game finished");
        }

        /// <summary>
        /// OnGameFinished event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameFinished(object sender, GameFininishedEventArg e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EndOfGame(DisplayEndScreen), e.Score);
                return;
            }
            else
                DisplayEndScreen(e.Score);
        }

        /// <summary>
        /// EntitiesUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEntitiesUpdated(object sender, EntitiesUpdatedEventArg e)
        {
            this.PictureBoxGame.Invalidate();
        }

        /// <summary>
        /// BackgroundUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBackgroundUpdated(object sender, BackgroundUpdatedEventArg e)
        {
            this.PictureBoxBackground.Invalidate();
        }

        /// <summary>
        /// MasterVolumeUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMasterVolumeUpdated(object sender, EventArgs e)
        {
            this.LabelMasterVolumeNumber.Text = (System.Math.Round(TrackBarMasterVolume.Value / 1.0)).ToString();
        }

        /// <summary>
        /// MasterMusicVolumeUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMasterMusicVolumeUpdated(object sender, EventArgs e)
        {
            this.LabelMasterMusicVolumeNumber.Text = (System.Math.Round(TrackBarMasterMusicVolume.Value / 1.0)).ToString();
        }

        /// <summary>
        /// MasterFxVolumeUpdated event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMasterFxVolumeUpdated(object sender, EventArgs e)
        {
            this.LabelMasterFxVolumeNumber.Text = (System.Math.Round(TrackBarMasterFxVolume.Value / 1.0)).ToString();
        }

        /// <summary>
        /// On key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == this.GameOptions.UserKeyUp)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.PushUp();
                this.KeyDirectionUpPushedNb = true;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyDown)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.PushDown();
                this.KeyDirectionDownPushedNb = true;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyLeft)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.PushLeft();
                this.KeyDirectionLeftPushedNb = true;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyRight)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.PushRight();
                this.KeyDirectionRightPushedNb = true;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyShoot)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.Fire();
            }
            else if (e.KeyCode == this.GameOptions.UserKeyBulletTime)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.BulletTime();
            }
        }

        /// <summary>
        /// On key released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == this.GameOptions.UserKeyUp)
            {
                System.Console.WriteLine("Released : " + e.KeyCode);
                this.KeyDirectionUpPushedNb = false;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyDown)
            {
                System.Console.WriteLine("Released : " + e.KeyCode);
                this.KeyDirectionDownPushedNb = false;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyLeft)
            {
                System.Console.WriteLine("Released : " + e.KeyCode);
                this.KeyDirectionLeftPushedNb = false;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyRight)
            {
                System.Console.WriteLine("Released : " + e.KeyCode);
                this.KeyDirectionRightPushedNb = false;
            }
            else if (e.KeyCode == this.GameOptions.UserKeyShoot)
            {
                System.Console.WriteLine("Released : " + e.KeyCode);
            }
            else if (e.KeyCode == this.GameOptions.UserKeyBulletTime)
            {
                System.Console.WriteLine("Pushed : " + e.KeyCode);
                this.GameEngine.ReleaseBulletTime();
            }

            if (!this.KeyDirectionUpPushedNb && !this.KeyDirectionRightPushedNb && !this.KeyDirectionDownPushedNb && !this.KeyDirectionLeftPushedNb)
            {
                System.Console.WriteLine("Reset : None");
                this.GameEngine.ReleaseDirection();
            }
        }

        /// <summary>
        /// Main panel rendering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxGame_Paint(object sender, PaintEventArgs e)
        {
            // Draw the entities
            foreach (IEntityBase entity in this.GameEngine.GetEntities())
            {
                e.Graphics.DrawImage(entity.GetImage(), entity.GetLocation());
                
            }
        }

        /// <summary>
        /// Background panel rendering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxBackground_Paint(object sender, PaintEventArgs e)
        {
            // Draw the background
            IEntityBase background = this.GameEngine.GetBackground();
            e.Graphics.DrawImage(background.GetImage(), background.GetLocation());
        }

        /// <summary>
        /// Update mouse info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxGame_MouseMove(object sender, MouseEventArgs e)
        {
            this.LabelX.Text = $"X : {e.X}";
            this.LabelY.Text = $"Y : {e.Y}";
        }

        /// <summary>
        /// Clean mouse info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxGame_MouseLeave(object sender, EventArgs e)
        {
            this.LabelX.Text = $"X : 0";
            this.LabelY.Text = $"Y : 0";
        }

        /// <summary>
        /// Click on the start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.PanelStartScreen.Visible = false;
            this.PictureBoxGame.Visible = true;
            this.GameEngine.Run();
            this.Focus();
            System.Console.WriteLine("Game started");
        }

        /// <summary>
        /// Click on the options button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOptions_Click(object sender, EventArgs e)
        {
            this.PanelStartScreen.Visible = false;
            this.PanelOptionsScreen.Visible = true;
            System.Console.WriteLine("Options");
        }

        /// <summary>
        /// Click on the Keyboard tab button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTabOptionsKeyboard_Click(object sender, EventArgs e)
        {
            this.PanelOptionsSound.Visible = false;
            this.PanelOptionsKeyboard.Visible = true;
            this.ButtonTabOptionsKeyboard.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ButtonTabOptionsSound.BackColor = System.Drawing.Color.SlateGray;
        }

        /// <summary>
        /// Click on the Sound tab button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTabOptionsSound_Click(object sender, EventArgs e)
        {
            this.PanelOptionsSound.Visible = true;
            this.PanelOptionsKeyboard.Visible = false;
            this.ButtonTabOptionsKeyboard.BackColor = System.Drawing.Color.SlateGray;
            this.ButtonTabOptionsSound.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        /// <summary>
        ///  Custom the panel options rendering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderPanelOptions_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PanelOptionsSound.DisplayRectangle, Color.White, ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, this.PanelOptionsKeyboard.DisplayRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// Click on the apply button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonApplyOptions_Click(object sender, EventArgs e)
        {   
            if (this.TextBoxKeyUp.Text == this.TextBoxKeyDown.Text || this.TextBoxKeyUp.Text == this.TextBoxKeyLeft.Text || this.TextBoxKeyUp.Text == this.TextBoxKeyRight.Text || this.TextBoxKeyUp.Text == this.TextBoxKeyShoot.Text || this.TextBoxKeyUp.Text == this.TextBoxKeyBulletTime.Text)
            {
                this.TextBoxKeyUp.BackColor = System.Drawing.Color.Red;
            }
            else if (this.TextBoxKeyDown.Text == this.TextBoxKeyUp.Text || this.TextBoxKeyDown.Text == this.TextBoxKeyLeft.Text || this.TextBoxKeyDown.Text == this.TextBoxKeyRight.Text || this.TextBoxKeyDown.Text == this.TextBoxKeyShoot.Text || this.TextBoxKeyDown.Text == this.TextBoxKeyBulletTime.Text)
            {
                this.TextBoxKeyDown.BackColor = System.Drawing.Color.Red;
            } else if (this.TextBoxKeyLeft.Text == this.TextBoxKeyUp.Text || this.TextBoxKeyLeft.Text == this.TextBoxKeyDown.Text || this.TextBoxKeyLeft.Text == this.TextBoxKeyRight.Text || this.TextBoxKeyLeft.Text == this.TextBoxKeyShoot.Text || this.TextBoxKeyLeft.Text == this.TextBoxKeyBulletTime.Text)
            {
                this.TextBoxKeyLeft.BackColor = System.Drawing.Color.Red;
            } else if (this.TextBoxKeyRight.Text == this.TextBoxKeyUp.Text || this.TextBoxKeyRight.Text == this.TextBoxKeyDown.Text || this.TextBoxKeyRight.Text == this.TextBoxKeyLeft.Text || this.TextBoxKeyRight.Text == this.TextBoxKeyShoot.Text || this.TextBoxKeyRight.Text == this.TextBoxKeyBulletTime.Text)
            {
                this.TextBoxKeyRight.BackColor = System.Drawing.Color.Red;
            } else if(this.TextBoxKeyShoot.Text == this.TextBoxKeyUp.Text || this.TextBoxKeyShoot.Text == this.TextBoxKeyDown.Text || this.TextBoxKeyShoot.Text == this.TextBoxKeyLeft.Text || this.TextBoxKeyShoot.Text == this.TextBoxKeyRight.Text || this.TextBoxKeyShoot.Text == this.TextBoxKeyBulletTime.Text)
            {
                this.TextBoxKeyShoot.BackColor = System.Drawing.Color.Red;
            } else if (this.TextBoxKeyBulletTime.Text == this.TextBoxKeyUp.Text || this.TextBoxKeyBulletTime.Text == this.TextBoxKeyDown.Text || this.TextBoxKeyBulletTime.Text == this.TextBoxKeyLeft.Text || this.TextBoxKeyBulletTime.Text == this.TextBoxKeyRight.Text || this.TextBoxKeyBulletTime.Text == this.TextBoxKeyShoot.Text)
            {
                this.TextBoxKeyBulletTime.BackColor = System.Drawing.Color.Red;
            } else
            {
                this.GameOptions.UserKeyUp = (Keys)Enum.Parse(typeof(Keys), this.TextBoxKeyUp.Text);
                this.TextBoxKeyUp.BackColor = System.Drawing.Color.SlateGray;
                this.GameOptions.UserKeyDown = (Keys)Enum.Parse(typeof(Keys), this.TextBoxKeyDown.Text);
                this.TextBoxKeyDown.BackColor = System.Drawing.Color.SlateGray;
                this.GameOptions.UserKeyLeft = (Keys)Enum.Parse(typeof(Keys), this.TextBoxKeyLeft.Text);
                this.TextBoxKeyLeft.BackColor = System.Drawing.Color.SlateGray;
                this.GameOptions.UserKeyRight = (Keys)Enum.Parse(typeof(Keys), this.TextBoxKeyRight.Text);
                this.TextBoxKeyRight.BackColor = System.Drawing.Color.SlateGray;
                this.GameOptions.UserKeyShoot = (Keys)Enum.Parse(typeof(Keys), this.TextBoxKeyShoot.Text);
                this.TextBoxKeyShoot.BackColor = System.Drawing.Color.SlateGray;
                this.GameOptions.UserKeyBulletTime = (Keys)Enum.Parse(typeof(Keys), this.TextBoxKeyBulletTime.Text);
                this.TextBoxKeyBulletTime.BackColor = System.Drawing.Color.SlateGray;
                this.GameEngine.SetGameOptions(this.GameOptions);
                this.PanelOptionsScreen.Visible = false;
                this.PanelStartScreen.Visible = true;
            }

            this.GameOptions.MasterVolume = this.TrackBarMasterVolume.Value;
            this.GameOptions.MusicVolume = this.TrackBarMasterMusicVolume.Value;
            this.GameOptions.FxVolume = this.TrackBarMasterFxVolume.Value;

            System.Console.WriteLine("Options Apply");
        }

        /// <summary>
        /// User key up input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUserKeyUp_KeyDown(object sender, KeyEventArgs e)
        {
            this.TextBoxKeyUp.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// User key down input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUserKeyDown_KeyDown(object sender, KeyEventArgs e)
        { 
            this.TextBoxKeyDown.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// User key left input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUserKeyLeft_KeyDown(object sender, KeyEventArgs e)
        {
            this.TextBoxKeyLeft.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// User key right input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUserKeyRight_KeyDown(object sender, KeyEventArgs e)
        {
            this.TextBoxKeyRight.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// User key shoot input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUserKeyShoot_KeyDown(object sender, KeyEventArgs e)
        {
            this.TextBoxKeyShoot.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// Useer Key BulletTime input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUserKeyBulletTime_KeyDown(object sender, KeyEventArgs e)
        {
            this.TextBoxKeyBulletTime.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// Click on the back button in the menu option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExitOptions_Click(object sender, EventArgs e)
        {
            this.PanelOptionsScreen.Visible = false;
            this.PanelStartScreen.Visible = true;
            System.Console.WriteLine("Options closed");
        }

        /// <summary>
        /// Click on the restart button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            this.PanelEndScreen.Visible = false;
            this.PictureBoxGame.Visible = true;
            this.GameEngine.Restart();
            this.Focus();
            System.Console.WriteLine("Game re-started");
        }

        /// <summary>
        /// Click on the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Console.WriteLine("Game closed");
        }

        /// <summary>
        /// Initialize and set the font Families on the component
        /// </summary>
        private void InitCusomLabelFont()
        {
            //Create your private font collection object.
            this.Pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Resources.kenvector_future.Length;

            // create a buffer to read in to
            byte[] fontdata = Resources.kenvector_future;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            this.Pfc.AddMemoryFont(data, fontLength);

            // Get global font
            FontFamily globalFont = this.Pfc.Families[0];
            //set the font families on component
            this.ButtonStart.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOptions.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarMasterVolume.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarMasterMusicVolume.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarMasterFxVolume.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTabOptionsSound.Font = new System.Drawing.Font(globalFont, 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTabOptionsKeyboard.Font = new System.Drawing.Font(globalFont, 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonApplyOptions.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelOptions.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleStartScreen.Font = new System.Drawing.Font(globalFont, 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExit.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRestartEndScreen.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExitEndScreen.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPanelOptions.Font = new System.Drawing.Font(globalFont, 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelScore.Font = new System.Drawing.Font(globalFont, 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLevel.Font = new System.Drawing.Font(globalFont, 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelScoreEndScreen.Font = new System.Drawing.Font(globalFont, 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX.Font = new System.Drawing.Font(globalFont, 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelY.Font = new System.Drawing.Font(globalFont, 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHP.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSP.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFP.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMasterVolume.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMasterVolumeNumber.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMasterMusicVolume.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMasterMusicVolumeNumber.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMasterFxVolume.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMasterFxVolumeNumber.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInputKeyUp.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInputKeyDown.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInputKeyLeft.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInputKeyRight.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInputKeyShoot.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInputKeyBulletTime.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeyUp.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeyDown.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeyLeft.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeyRight.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeyShoot.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeyBulletTime.Font = new System.Drawing.Font(globalFont, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
