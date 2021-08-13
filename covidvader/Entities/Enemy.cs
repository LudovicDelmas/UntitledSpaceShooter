using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CovidVader.Core;
using System.Timers;
using covidvader.Properties;

namespace CovidVader.Entities
{
    public class Enemy : GameEntity
    {
        /// <summary>
        /// Allow to handle the event raised when the enemy fire
        /// </summary>
        public delegate void EnemyFiredHandler(object sender, EnemyFiredEventArgs myArgs);
        /// <summary>
        /// Allow to handle the event raised when the enemy fire
        /// </summary>
        public event EnemyFiredHandler EnemyFired;

        /// <summary>
        /// Current direction of the enemy
        /// </summary>
        //protected MoveDirection CurrentDirection;

        public Enemy(Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, MoveDirection defaultMoveDirection) : base(GetRandomEnemyImage(), entitySize, location, moveSpeed, hp, sp, dp, defaultMoveDirection)
        {
            // First random move direction
            if (new Random().Next(1, 100) < 50)
            {
                this.SetCurrentDirection(MoveDirection.Left);
            }
            else
            {
                this.SetCurrentDirection(MoveDirection.Right);
            }
            // Init the random move cycle of the entity
            StartRandomMoveCycle();
            // Init the fire cycle of the entity
            StartRandomFireCycle();
        }
        /// <summary>
        /// Start & Init the move cycle of the entity
        /// </summary>
        protected void StartRandomMoveCycle()
        {
            Timer tim = new Timer
            {
                Interval = 750
            };
            tim.Elapsed += OnMoveCycleReached;
            tim.Start();
        }

        /// <summary>
        /// move trigger
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnMoveCycleReached(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (new Random().Next(1, 100) < 50)
            {
                this.SetCurrentDirection(MoveDirection.Left);
            }
            else
            {
                this.SetCurrentDirection(MoveDirection.Right);
            }
        }


        /// <summary>
        /// Start & Init the fire cycle of the entity
        /// </summary>
        protected void StartRandomFireCycle()
        {
            Timer tim = new Timer
            {
                Interval = 1000
            };
            tim.Elapsed += OnFireCycleReached;
            tim.Start();
        }

        /// <summary>
        /// Fire trigger
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnFireCycleReached(Object source, System.Timers.ElapsedEventArgs e)
        {
            if(new Random().Next(1, 100) < 50)
            {
                this.EnemyFired?.Invoke(this, new EnemyFiredEventArgs(Fire()));
            }
        }

        /// <summary>
        ///  Fire a laser
        /// </summary>
        /// <returns></returns>
        private LaserEnemy Fire()
        {
            lock (this.EntityLock)
            {
                LaserEnemy laser = null;

                // Create size and location of the laser
                Size laserSize = new Size(10, 30);
                Point laserOrigin = new Point(this.GetLocation().X + this.GetSize().Width / 2 - laserSize.Width / 2, this.GetLocation().Y + this.GetSize().Height - laserSize.Height + 5);
                // Create the laser
                laser = new LaserEnemy(laserSize, laserOrigin, GameConfiguration.INIT_LASER_MOVESPEED, 1, 1, GameConfiguration.INIT_GLOBAL_DAMAGE, MoveDirection.Down);

                return laser;
            }
        }

        /// <summary>
        /// Random skin for the enemy
        /// </summary>
        /// <returns></returns>
        private static Image GetRandomEnemyImage()
        {
            Random random = new Random();

            int randomEnemie = random.Next(1, 5);

            switch (randomEnemie)
            {
                case 1:
                    return Resources.enemyBlack1;
                case 2:
                    return Resources.enemyBlue2;
                case 3:
                    return Resources.enemyGreen3;
                case 4:
                    return Resources.enemyRed4;
                default:
                    return Resources.enemyBlack1;
            }

        }

    }

    public class EnemyFiredEventArgs : EventArgs
    {
        public new EnemyFiredEventArgs Empty;

        public LaserEnemy Laser { get; set; }

        public EnemyFiredEventArgs(LaserEnemy laser)
        {
            this.Laser = laser;
        }
    }
}
