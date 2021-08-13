using System;

namespace CovidVader.Core
{
    public static class GameConfiguration
    {
        /// <summary>
        /// Background move speed (in px)
        /// </summary>
        public const int INIT_BACKGROUND_MOVESPEED = 4;

        /// <summary>
        /// Ship move speed (in px)
        /// </summary>
        public const int INIT_SHIP_MOVESPEED = 40;

        /// <summary>
        /// Laser Speed (in px)
        /// </summary>
        public const int INIT_LASER_MOVESPEED = 25;

        /// <summary>
        /// Refresh rate (in ms)
        /// </summary>
        public const int INIT_REFRESHRATE = 5;

        /// <summary>
        /// Global damage
        /// </summary>
        public const int INIT_GLOBAL_DAMAGE = 50;

        /// <summary>
        /// Ship Health Point
        /// </summary>
        public const int INIT_SHIP_HP = 100;

        /// <summary>
        /// Ship Shield Point
        /// </summary>
        public const int INIT_SHIP_SP = 50;

        /// <summary>
        /// Ship Max Fire Point
        /// </summary>
        public const int INIT_SHIP_FP_MAX = 20;

        /// <summary>
        /// Cooldown of the fire reloading
        /// </summary>
        public static readonly TimeSpan FireReloadCooldown = new TimeSpan(0, 0, 0, 0, 750);

        /// <summary>
        /// Cooldown of the fire action
        /// </summary>
        public static readonly TimeSpan ActionFireShootCooldown = new TimeSpan(0, 0, 0, 0, 150);
    }
}
