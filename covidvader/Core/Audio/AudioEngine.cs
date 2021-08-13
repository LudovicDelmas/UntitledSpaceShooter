using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CovidVader.Core;

namespace CovidVader.Core.Audio
{
    public enum Sounds
    {
        /// <summary>
        /// The main game music
        /// </summary>
        MusicMain,
        /// <summary>
        /// The Laser sound
        /// </summary>
        Laser,
        /// <summary>
        /// The ShieldBonus sound
        /// </summary>
        ShieldBonus,
        /// <summary>
        /// The Explosion sound
        /// </summary>      
        Explosion,
        /// <summary>
        /// The Enemy Explosion sound
        /// </summary>
        EnemyExplosion,
        /// <summary>
        /// The Impact sound
        /// </summary>
        Impact,
        /// <summary>
        /// The Impact Laser sound
        /// </summary>
        ImpactLaser,
        /// <summary>
        /// The level up sound
        /// </summary>
        LevelUp,
        /// <summary>
        /// The GameOver sound
        /// </summary>
        GameOver,
        /// <summary>
        /// The bullet time sound
        /// </summary>
        BulletTime
    }

    public class AudioEngine
    {
        private readonly XAudio2 Xaudio;

        /// <summary>
        /// Master volume
        /// </summary>
        private int MasterVolume { get; set; }
        /// <summary>
        /// Master music volume
        /// </summary>
        private int MasterMusicVolume { get; set; }
        /// <summary>
        /// Master Fx Volume
        /// </summary>
        private int MasterFxVolume { get; set; }

        /// <summary>
        /// Local volume
        /// </summary>
        private readonly float MusicMainVolume;
        private readonly float LaserVolume;
        private readonly float ExplosionVolume;
        private readonly float ImpactVolume;
        private readonly float GameOverVolume;
        private readonly float ImpactLaserVolume;
        private readonly float EnemyExplosionVolume;
        private readonly float ShieldBonusVolume;
        private readonly float LevelUpVolume;
        private readonly float BulletTimeVolume;

        /// <summary>
        /// Audio engine
        /// </summary>
        public AudioEngine()
        {
            this.Xaudio = new XAudio2();
            new MasteringVoice(Xaudio);

            // Initial audio mix
            this.MasterVolume = 100;
            this.MasterMusicVolume = 100;
            this.MasterFxVolume = 100;
            this.MusicMainVolume = 6f;
            this.LaserVolume = 0.25f;
            this.ExplosionVolume = 0.21f;
            this.ImpactVolume = 0.17f;
            this.GameOverVolume = 0.15f;
            this.ImpactLaserVolume = 0.23f;
            this.EnemyExplosionVolume = 0.25f;
            this.ShieldBonusVolume = 0.20f;
            this.LevelUpVolume = 0.20f;
            this.BulletTimeVolume = 0.20f;
        }

        public void SetMasterVolume(int volume)
        {
            this.MasterVolume = volume;
        }

        public int GetMasterVolume()
        {
            return this.MasterVolume;
        }

        public void SetMasterMusicVolume(int volume)
        { 
            this.MasterMusicVolume = volume;
        }

        public int GetMasterMusicVolume()
        {
            return this.MasterMusicVolume;
        }

        public void SetMasterFxVolume(int volume)
        {
            this.MasterFxVolume = volume;
        }

        public int GetMasterFxVolume()
        {
            return this.MasterFxVolume;
        }

        /// <summary>
        /// Allow to play a sound
        /// </summary>
        /// <param name="sound">Sound to play</param>
        /// <param name="cancellationToken">Token to stop the current sound</param>
        /// <returns></returns>
        public Task Play(Sounds sound, bool loop = false, CancellationToken cancellationToken = default)
        {
            Task task = Task.CompletedTask;
            switch (sound)
            {
                case Sounds.MusicMain:
                    MemoryStream destination = new MemoryStream();
                    var main = AudioConfiguration.FILEPATH_MUSIC_MAIN;
                    main.CopyTo(destination);
                    main.Position = 0;
                    destination.Position = 0;
                    task = this.PlaySoundFile(destination, this.MusicMainVolume * Convert.ToSingle(this.MasterMusicVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                     break;
                case Sounds.Laser:
                    MemoryStream destination2 = new MemoryStream();
                    var laser = AudioConfiguration.FILEPATH_LASER;
                    laser.CopyTo(destination2);
                    laser.Position = 0;
                    destination2.Position = 0;
                    task = this.PlaySoundFile(destination2, this.LaserVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
                case Sounds.Explosion:
                    MemoryStream destination3 = new MemoryStream();
                    var explosion = AudioConfiguration.FILEPATH_EXPLOSION;
                    explosion.CopyTo(destination3);
                    explosion.Position = 0;
                    destination3.Position = 0;
                    task = this.PlaySoundFile(destination3, this.ExplosionVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
                case Sounds.Impact:
                    MemoryStream destination4 = new MemoryStream();
                    var impact = AudioConfiguration.FILEPATH_IMPACT;
                    impact.CopyTo(destination4);
                    impact.Position = 0;
                    destination4.Position = 0;
                    task = this.PlaySoundFile(destination4, this.ImpactVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
                case Sounds.GameOver:
                    task = Task.Run(() =>
                    {
                        MemoryStream destination5 = new MemoryStream();
                        Thread.Sleep(400);
                        var gameOver = AudioConfiguration.FILEPATH_GAME_OVER;
                        gameOver.CopyTo(destination5);
                        gameOver.Position = 0;
                        destination5.Position = 0;
                        this.PlaySoundFile(destination5, this.GameOverVolume * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    });

                    break;
                case Sounds.ImpactLaser:
                    MemoryStream destination6 = new MemoryStream();
                    var impactLaser = AudioConfiguration.FILEPATH_IMPACT_LASER;
                    impactLaser.CopyTo(destination6);
                    impactLaser.Position = 0;
                    destination6.Position = 0;
                    task = this.PlaySoundFile(destination6, this.ImpactLaserVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
                case Sounds.EnemyExplosion:
                    MemoryStream destination7 = new MemoryStream();
                    var enemyExplosion = AudioConfiguration.FILEPATH_ENEMY_EXPLOSION;
                    enemyExplosion.CopyTo(destination7);
                    enemyExplosion.Position = 0;
                    destination7.Position = 0;
                    task = this.PlaySoundFile(destination7, this.EnemyExplosionVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
                case Sounds.ShieldBonus:
                    MemoryStream destination8 = new MemoryStream();
                    var shieldBonus = AudioConfiguration.FILEPATH_SHIELD_BONUS;
                    shieldBonus.CopyTo(destination8);
                    shieldBonus.Position = 0;
                    destination8.Position = 0;
                    task = this.PlaySoundFile(destination8, this.ShieldBonusVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break; 
                case Sounds.LevelUp:
                    MemoryStream destination9 = new MemoryStream();
                    var levelUp = AudioConfiguration.FILEPATH_LEVEL_UP;
                    levelUp.CopyTo(destination9);
                    levelUp.Position = 0;
                    destination9.Position = 0;
                    task = this.PlaySoundFile(destination9, this.LevelUpVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
                case Sounds.BulletTime:
                    MemoryStream destination10 = new MemoryStream();
                    var bulletTime = AudioConfiguration.FILEPATH_BULLET_TIME;
                    bulletTime.CopyTo(destination10);
                    bulletTime.Position = 0;
                    destination10.Position = 0;
                    task = this.PlaySoundFile(destination10, this.BulletTimeVolume * Convert.ToSingle(this.MasterFxVolume / 100.0) * Convert.ToSingle(this.MasterVolume / 100.00), loop, cancellationToken);
                    break;
            }
            return task;
        }

        /// <summary>
        /// Play a sound file. Supported format are Wav(pcm+adpcm) and XWMA
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="volume">Volume</param>
        /// <param name="fileName">Name of the file.</param>
        private Task PlaySoundFile(MemoryStream copyStream, float volume, bool loop = false, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                var stream = new SoundStream(copyStream);

                var waveFormat = stream.Format;

                AudioBuffer buffer = new AudioBuffer()
                {

                    Stream = stream.ToDataStream(),
                    AudioBytes = (int)stream.Length,
                    Flags = BufferFlags.None,

                };

                stream.Close();
                //stream.Dispose();

                var sourceVoice = new SourceVoice(this.Xaudio, waveFormat, true);
                sourceVoice.SetVolume(volume);

                // Set the infinite loop if it requested
                if (loop)
                    buffer.LoopCount = AudioBuffer.LoopInfinite;

                // Adds a sample callback to check that they are working on source voices
                sourceVoice.SubmitSourceBuffer(buffer, stream.DecodedPacketsInfo);
                sourceVoice.Start();

                while (sourceVoice.State.BuffersQueued > 0)
                {
                    Thread.Sleep(1);
                    // if the caller want to stop the current thread : break the loop
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }

                sourceVoice.DestroyVoice();
                sourceVoice.Dispose();
                buffer.Stream.Dispose();

            });
        }
    }
}
