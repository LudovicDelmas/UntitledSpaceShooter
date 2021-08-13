using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CovidVader.Core
{
    public class GameOptions
    {
        public Keys UserKeyUp { get; set; } 
        public Keys UserKeyDown { get; set; }
        public Keys UserKeyLeft { get; set; }
        public Keys UserKeyRight { get; set; }
        public Keys UserKeyShoot { get; set; }
        public Keys UserKeyBulletTime { get; set; }
        public int MasterVolume { get; set; }
        public int MusicVolume { get; set; }
        public int FxVolume { get; set; }

        public GameOptions()
        {

        }

        /// <summary>
        /// Save the game options into a configuration file
        /// </summary>
        /// <param name="myOptions">Game options to save</param>
        public static void Save(GameOptions myOptions)
        {
            try
            {
                // Convert options to a string
                var json = new JavaScriptSerializer().Serialize(myOptions);
                // Save string object into file
                string[] text = { json };
                File.WriteAllLines("options.cfg", text);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Load a the game options from a configuration file
        /// </summary>
        /// <returns>Game options loaded</returns>
        public static GameOptions Load()
        {
            GameOptions myOptions;
            try
            {
                // Load string object from file
                string json = File.ReadAllText("options.cfg");
                // Convert text to option
                myOptions = new JavaScriptSerializer().Deserialize<GameOptions>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Default config loaded.");
                myOptions = new GameOptions
                {
                    UserKeyUp = Keys.Up,
                    UserKeyDown = Keys.Down,
                    UserKeyLeft = Keys.Left,
                    UserKeyRight = Keys.Right,
                    UserKeyShoot = Keys.Space,
                    UserKeyBulletTime = Keys.Alt,
                    MasterVolume = 100,
                    MusicVolume = 100,
                    FxVolume = 100
                };
            }

            // return the options
            return myOptions;
        }
    }
}



