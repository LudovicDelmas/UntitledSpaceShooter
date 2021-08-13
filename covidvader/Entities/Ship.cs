using covidvader.Properties;
using CovidVader.Core;
using System;
using System.Drawing;

namespace CovidVader.Entities
{
    public class Ship : GameEntity
    {
        /// <summary>
        /// Fire points of the ship
        /// </summary>
        protected int Fp { get; private set; }

        public Ship(Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, int fp, MoveDirection defaultMoveDirection) : base(Resources.playerShip1_red, entitySize, location, moveSpeed, hp, sp, dp, defaultMoveDirection)
        {
            this.Fp = fp;
        }

        /// <summary>
        /// Ship fire the ship has some fire points
        /// </summary>
        /// <returns>A laser fired if the ship has the needed fire point, otherwise null</returns>
        public Laser Fire()
        {
            lock (this.EntityLock)
            {
                Laser laser = null;
                if (this.Fp > 0)
                {
                    // Spent on fp to fire
                    this.Fp--;
                    // Create size and location of the laser
                    Size laserSize = new Size(10, 30);
                    Point laserOrigin = new Point(this.GetLocation().X + this.GetSize().Width / 2 - laserSize.Width / 2, this.GetLocation().Y - laserSize.Height + 5);
                    // Create the laser
                    laser = new Laser(laserSize, laserOrigin, GameConfiguration.INIT_LASER_MOVESPEED, 1, 1, GameConfiguration.INIT_GLOBAL_DAMAGE, MoveDirection.Up);
                }
                return laser;
            }
        }

        /// <summary>
        /// Get the fire points of the ship
        /// </summary>
        /// <returns>The fire points</returns>
        public int GetFp()
        {
            lock (this.EntityLock)
            {
                return this.Fp;
            }
        }

        /// <summary>
        /// Set the fire points of the ship
        /// </summary>
        /// <param name="fp">Fire points</param>
        public void SetFp(int fp)
        {
            lock (this.EntityLock)
            {
                this.Fp = fp;
            }
        }
    }
}
