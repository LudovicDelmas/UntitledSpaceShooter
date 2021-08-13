using System;
using System.Drawing;
using System.Reflection;


namespace CovidVader.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        protected readonly object EntityLock = new object();

        /// <summary>
        /// Visual reprentation of the entity
        /// </summary>
        protected Image Image;

        /// <summary>
        /// Location of the entity
        /// </summary>
        protected Point Location;

        /// <summary>
        /// Size of the entity
        /// </summary>
        protected Size Size;

        /// <summary>
        /// The number of pixels that make up a movement in a game loop
        /// </summary>
        protected int MoveSpeed;

        protected int OldMoveSpeed;

        /// <summary>
        /// The Blueprint of the entity
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="entitySize"></param>
        /// <param name="location"></param>
        /// <param name="moveSpeed"></param>
        protected EntityBase(Image imagePath, Size entitySize, Point location, int moveSpeed)
        {
            this.Image = new Bitmap(imagePath, entitySize);
            this.Location = location;
            this.Size = entitySize;
            this.MoveSpeed = moveSpeed;
            this.OldMoveSpeed = moveSpeed;
        }

        /// <summary>
        /// Get the image of the entity
        /// </summary>
        /// <returns>An image representing the entity</returns>
        public Image GetImage()
        {
            lock (EntityLock)
            {
                return this.Image;
            }
        }

        /// <summary>
        /// Get the location of the entity
        /// </summary>
        /// <returns>A point representing the location of the entity</returns>
        public Point GetLocation()
        {
            lock (EntityLock)
            {
                return this.Location;
            }
        }

        /// <summary>
        /// Set the X location of the entity
        /// </summary>
        /// <param name="x">X location of the entity (in px)</param>
        public void SetLocationX(int x)
        {
            lock (EntityLock)
            {
                this.Location.X = x;
            }
        }

        /// <summary>
        /// Set the X location of the entity
        /// </summary>
        /// <param name="y">Y location of the entity (in px)</param>
        public void SetLocationY(int y)
        {
            lock (EntityLock)
            {
                this.Location.Y = y;
            }
        }

        /// <summary>
        /// Get the size of the entity
        /// </summary>
        /// <returns>Size of the entity</returns>
        public Size GetSize()
        {
            lock (EntityLock)
            {
                return this.Size;
            }
        }

        /// <summary>
        /// Get The number of pixels that make up a movement in a game loop
        /// </summary>
        /// <returns>An integer representing the move speed of the entity</returns>
        public int GetMoveSpeed()
        {
            lock (EntityLock)
            {
                return this.MoveSpeed;
            }
        }

        /// <summary>
        /// Set The number of pixels that make up a movement in a game loop
        /// </summary>
        /// <param name="speed"></param>
        public void SetMoveSpeed(int speed)
        {
            lock (EntityLock)
            {
                this.MoveSpeed = speed;
            }
        }

        /// <summary>
        /// Get The number of pixels that make up a movement in a game loop
        /// </summary>
        /// <returns>An integer representing the old move speed of the entity</returns>
        public int GetOldMoveSpeed()
        {
            lock(EntityLock)
            {
                return this.OldMoveSpeed;
            }
        }

        /// <summary>
        /// Set The number of pixels that make up a movement in a game loop
        /// </summary>
        /// <param name="oldspeed"></param>
        public void SetOldMoveSpeed(int oldSpeed)
        {
            lock(EntityLock)
            {
                this.OldMoveSpeed = oldSpeed;
            }
        }

    }
}
