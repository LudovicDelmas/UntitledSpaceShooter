using covidvader.Properties;
using System.IO;

namespace CovidVader.Core.Audio
{
    public static class AudioConfiguration
    {
        public readonly static UnmanagedMemoryStream FILEPATH_MUSIC_MAIN = Resources.GameSound;
        public readonly static UnmanagedMemoryStream FILEPATH_LASER = Resources.laser;
        public readonly static UnmanagedMemoryStream FILEPATH_EXPLOSION = Resources.Explosion;
        public readonly static UnmanagedMemoryStream FILEPATH_ENEMY_EXPLOSION = Resources.EnemyExplosion;
        public readonly static UnmanagedMemoryStream FILEPATH_IMPACT = Resources.Impact;
        public readonly static UnmanagedMemoryStream FILEPATH_GAME_OVER = Resources.GameOver;
        public readonly static UnmanagedMemoryStream FILEPATH_IMPACT_LASER = Resources.ImpactEnemy;
        public readonly static UnmanagedMemoryStream FILEPATH_SHIELD_BONUS = Resources.ShieldBonus;
        public readonly static UnmanagedMemoryStream FILEPATH_LEVEL_UP = Resources.LevelUp;
        public readonly static UnmanagedMemoryStream FILEPATH_BULLET_TIME = Resources.BulletTime;
    }
}
