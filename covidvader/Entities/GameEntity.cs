using CovidVader.Core;
using System;
using System.Drawing;

namespace CovidVader.Entities
{
    public abstract class GameEntity : EntityBase
    {
        /// <summary>
        /// Unique identifier of the entity
        /// </summary>
        protected Guid UID { get; private set; }

        /// <summary>
        /// Health points of the entity
        /// </summary>
        protected int Hp;

        /// <summary>
        /// Shield points of the entity
        /// </summary>
        protected int Sp;

        /// <summary>
        /// Damage points of the entity
        /// </summary>
        protected int Dp;

        /// <summary>
        /// Current direction of the entity
        /// </summary>
        protected MoveDirection CurrentDirection { get; private set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="imagePath">Path of the image of the entity display</param>
        /// <param name="entitySize">Size of the entity (in px)</param>
        /// <param name="location">Location of the entity</param>
        /// <param name="moveSpeed">The number of pixels that make up a movement in a game loop</param>
        /// <param name="hp">The health points of the entity</param>
        /// <param name="sp">The shield points of the entity</param>
        /// <param name="dp">The damage points of the entity</param>
        protected GameEntity(Image imagePath, Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, MoveDirection defaultMoveDirection) : base(imagePath, entitySize, location, moveSpeed)
        {
            this.UID = Guid.NewGuid();
            this.Hp = hp;
            this.Sp = sp;
            this.Dp = dp;
            this.CurrentDirection = defaultMoveDirection;
        }

        /// <summary>
        /// Set the current direction of the ship
        /// </summary>
        /// <param name="moveDirection">The current direction ot set</param>
        public void SetCurrentDirection(MoveDirection moveDirection)
        {
            lock (this.EntityLock)
            {
                this.CurrentDirection = moveDirection;
            }
        }

        /// <summary>
        /// Get the current direction of the ship
        /// </summary>
        /// <returns>The current direction</returns>
        public MoveDirection GetCurrentDirection()
        {
            lock (this.EntityLock)
            {
                return this.CurrentDirection;
            }
        }

        /// <summary>
        /// Get the health points of the entity
        /// </summary>
        /// <returns>the quantity of the health points</returns>
        public int GetHp()
        {
            lock (EntityLock)
            {
                return this.Hp;
            }
        }

        /// <summary>
        /// Get the shield points of the entity
        /// </summary>
        /// <returns>the quantity of the shield points</returns>
        public int GetSp()
        {
            lock(EntityLock)
            {
                return this.Sp;
            }
        }

        /// <summary>
        /// Get the damage points of the entity
        /// </summary>
        /// <returns>The quantity of the damage points inflicted by the entity</returns>
        public int GetDp()
        {
            lock (EntityLock)
            {
                return this.Dp;
            }
        }

        /// <summary>
        /// Allow to inflict damage an entity with a given amount of damage points
        /// </summary>
        /// <param name="damagePoints">Damage points to inflict to the entity</param>
        /// <returns>True if the entity is dead, otherwise false</returns>
        public bool Damage(int damagePoints)
        {
            int ShieldAbsorption = 0;
            lock (EntityLock)
            {
                // The shield reveives the damages first
                if (Sp > 0)
                {
                    ShieldAbsorption = this.Sp;
                    this.Sp = Math.Max(0, this.Sp - damagePoints);
                }
                // The health reveives the damages after
                if (this.Sp <= 0)
                {
                    this.Hp -= Math.Max(0, damagePoints - ShieldAbsorption);
                }
                // The entity is dead if the amount of health points goes down to 0
                return (this.Hp <= 0);
            }
        }

        /// <summary>
        /// Allow a Shield bonus at an entity with a given amount of shield points
        /// </summary>
        public void BonusShield(int shieldBonus)
        {
            lock (EntityLock)
            {
                if (Sp < 100)
                {
                    this.Sp += shieldBonus;
            
                }
            }
        }

        /// <summary>
        /// Get the hitbox of the entity
        /// </summary>
        /// <returns>A rectangle representing the hit box of the entity</returns>
        public Rectangle GetHitBox()
        {
            lock (EntityLock)
            {
                return new Rectangle(this.Location, this.Size);
            }
        }

        /// <summary>
        /// Allow to clone the entity
        /// </summary>
        /// <returns>The new entity created</returns>
        public GameEntity Clone()
        {
            GameEntity clone = (GameEntity)this.MemberwiseClone();
            clone.UID = Guid.NewGuid();
            return clone;
        }

        /// <summary>
        /// Allow to detect if two entities are the same
        /// </summary>
        /// <param name="entity">Entity to compare</param>
        /// <returns>True if the two entities are the same.</returns>
        public bool Equals(GameEntity entity)
        {
            return this.UID.Equals(entity.UID);
        }
    }
}
