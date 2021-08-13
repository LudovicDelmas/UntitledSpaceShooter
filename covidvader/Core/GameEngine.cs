using CovidVader.Core.Audio;
using CovidVader.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CovidVader.Core
{
    public class GameEngine
    {
        #region Properties

        #region EventsManagement

        /// <summary>
        /// Allow to handle the event raised when the game entities was refreshed
        /// </summary>
        public delegate void EntitiesUpdatedHandler(object sender, EntitiesUpdatedEventArg myArgs);
        /// <summary>
        /// Allow to handle the event raised when the game entities was refreshed
        /// </summary>
        public event EntitiesUpdatedHandler EntitiesUpdated;

        /// <summary>
        /// Allow to handle the event raised when the background location was refreshed
        /// </summary>
        public delegate void BackgroundUpdatedHandler(object sender, BackgroundUpdatedEventArg myArgs);
        /// <summary>
        /// Allow to handle the event raised when the background location was refreshed
        /// </summary>
        public event BackgroundUpdatedHandler BackgroundUpdated;

        /// <summary>
        /// Allow to handle the event raised when the score game is updated
        /// </summary>
        public delegate void ScoreUpdatedHandler(object sender, ScoreUpdatedEventArg myArgs);
        /// <summary>
        /// Allow to handle the event raised when the score game is updated
        /// </summary>
        public event ScoreUpdatedHandler ScoreUpdated;

        /// <summary>
        /// Allow to handle the event raised when the level game is updated
        /// </summary>
        public delegate void LevelUpdatedHandler(object sender, LevelUpdatedEventArg myArgs);
        /// <summary>
        /// Allow to handle the event raised when the level game is updated
        /// </summary>
        public event LevelUpdatedHandler LevelUpdated;

        /// <summary>
        /// Allow to handle the event raised when the game is finished
        /// </summary>
        public delegate void GameFininishedHandler(object sender, GameFininishedEventArg myArgs);
        /// <summary>
        /// Allow to handle the event raised when the game is finished
        /// </summary>
        public event GameFininishedHandler GameFinished;

        /// <summary>
        /// Allow to handle the event raised when the informations of the ship are updated
        /// </summary>
        public delegate void ShipInformationsUpdatedHandler(object sender, ShipInformationsUpdatedEventArg myArgs);
        /// <summary>
        /// Allow to handle the event raised when the informations of the ship are updated
        /// </summary>
        public event ShipInformationsUpdatedHandler ShipInformationsUpdated;

        #endregion

        /// <summary>
        /// Score of the game
        /// </summary>
        private int Score;

        /// <summary>
        /// Level of the game
        /// </summary>
        private int Level;

        /// <summary>
        /// List of entities
        /// </summary>
        private List<GameEntity> Entities;

        /// <summary>
        /// Lock entities
        /// </summary>
        private readonly object EntitiesLock = new object();

        /// <summary>
        /// Moment of the latest fire action
        /// </summary>
        private DateTime ActionFireLastDateTime;

        /// <summary>
        /// Moment of the latest fire reloading
        /// </summary>
        private DateTime FireOrReloadLastDateTime;

        /// <summary>
        /// Main ship
        /// </summary>
        private Ship Ship;

        /// <summary>
        /// Game background
        /// </summary>
        private Background Background;

        /// <summary>
        /// Maximum width of the game grid (in px)
        /// </summary>
        private readonly int MaxWidth;

        /// <summary>
        /// Maximum height of the game grid (in px)
        /// </summary>
        private readonly int MaxHeight;

        /// <summary>
        /// Sound player global instance
        /// </summary>
        private AudioEngine AudioEngine;

        /// <summary>
        /// Asteroid parameter
        /// </summary>
        private int AsteroidMaxNumber;
        private int AsteroidMinNumber;
        private int AsteroidMaxSpeed;
        private int AsteroidMinSpeed;

        /// <summary>
        /// Enemies Parameter
        /// </summary>
        private int EnemiesMaxNumber;
        private int EnemiesMinNumber;

        /// <summary>
        /// Determines if the bullet time is activated
        /// </summary>
        private bool IsBulletTimeActivated;

        /// <summary>
        /// Bullet time sound cancellation token source
        /// </summary>
        private CancellationTokenSource BulletTimeSoundTokenSource;

        /// <summary>
        /// Game Options
        /// </summary>
        private GameOptions GameOptions;

        #endregion

        /// <summary>
        /// Build the game
        /// </summary>
        /// <param name="maxWidth">Maximum width of the game grid (in px)</param>
        /// <param name="maxHeight">Maximum height of the game grid (in px)</param>
        public GameEngine(int maxWidth, int maxHeight)
        {
            this.MaxWidth = maxWidth;
            this.MaxHeight = maxHeight;
            this.Entities = new List<GameEntity>();
            this.AudioEngine = new AudioEngine();
            this.Score = 0;
            this.Level = 1;
            this.AsteroidMaxNumber = 10;
            this.AsteroidMinNumber = 1;
            this.AsteroidMaxSpeed = 3;
            this.AsteroidMinSpeed = 1;
            this.EnemiesMaxNumber = 3;
            this.EnemiesMinNumber = 1;
            this.GameOptions = new GameOptions();
            this.GameOptions = GameOptions.Load();
            this.AudioEngine.SetMasterVolume(this.GameOptions.MasterVolume);
            this.AudioEngine.SetMasterMusicVolume(this.GameOptions.MusicVolume);
            this.AudioEngine.SetMasterFxVolume(this.GameOptions.FxVolume);


            // Initialize the background
            InitAndNotifyBackground();

        }

        /// <summary>
        /// set the game options
        /// </summary>
        /// <param name="myOptions"></param>
        public void SetGameOptions(GameOptions myOptions)
        {
            this.AudioEngine.SetMasterVolume(myOptions.MasterVolume);
            this.AudioEngine.SetMasterMusicVolume(myOptions.MusicVolume);
            this.AudioEngine.SetMasterFxVolume(myOptions.FxVolume);
            this.GameOptions = myOptions;
            GameOptions.Save(myOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameOptions GetGameOptions()
        {
            return this.GameOptions;
        }

        /// <summary>
        /// Allow to restart the game
        /// </summary>
        public void Restart()
        {
            // Reinitialize the entities and the sound player
            this.Entities = new List<GameEntity>();
            this.AudioEngine = new AudioEngine();
            this.Score = 0;
            this.Level = 1;
            this.AsteroidMaxNumber = 10;
            this.AsteroidMinNumber = 1;
            this.AsteroidMaxSpeed = 3;
            this.AsteroidMinSpeed = 1;
            this.EnemiesMaxNumber = 3;
            this.EnemiesMinNumber = 1;
            // Re-run the game
            this.Run();
        }

        /// <summary>
        /// Run the game
        /// </summary>
        public void Run()
        {
            // Initialize the ship
            InitShip();

            // Core thread starting
            Task.Run(() =>
            {
                // Loop index
                int loopIndex = 0;

                // Play the cancellable game music
                var backgroundMusicTokenSource = new CancellationTokenSource();
                this.AudioEngine.Play(Sounds.MusicMain, true, backgroundMusicTokenSource.Token);

                // Main loop
                while (!IsEndOfGame())
                {
                    // Wait the refresh time
                    Thread.Sleep(GameConfiguration.INIT_REFRESHRATE);
                    loopIndex++;

                    // Background management
                    ManageBackground();
                    // Asteroids management
                    GenerateAsteroids(loopIndex);
                    // ShieldBonus management
                    GenerateShieldBonuses(loopIndex);
                    // Enemies manamgement
                    GenerateEnemies(loopIndex);
                    // Move entities
                    MoveEntities();
                    // Entities collisions management
                    ManageEntitiesCollisions();
                    // Score management
                    ManageScore();
                    // Level management
                    ManageLevel();
                    // Fire cooldown management
                    ManageFireCooldown();
                    // Clean entities
                    CleanEntities();
                    // Bullet time management
                    ManageBulletTime();

                    // Background updated notification
                    this.BackgroundUpdated?.Invoke(this, BackgroundUpdatedEventArg.Empty);
                    // Entities updated nofitication
                    this.EntitiesUpdated?.Invoke(this, EntitiesUpdatedEventArg.Empty);
                    // ShipInformations updated notification
                    this.ShipInformationsUpdated?.Invoke(this, new ShipInformationsUpdatedEventArg(this.Ship.GetHp(), this.Ship.GetSp(), this.Ship.GetFp()));
                    // Game score updated notification
                    this.ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArg(this.Score));
                    // Game level updated notfication
                    this.LevelUpdated?.Invoke(this, new LevelUpdatedEventArg(this.Level));
                }

                // Stop the background music
                backgroundMusicTokenSource.Cancel();

                // End of game nofitication
                GameFinished?.Invoke(this, new GameFininishedEventArg(this.Score));
            });
        }

        /// <summary>
        /// Change the current direction of the ship to right
        /// </summary>
        public void PushRight()
        {
            lock (EntitiesLock)
            {
                this.Ship.SetCurrentDirection(MoveDirection.Right);
            }

        }

        /// <summary>
        /// Change the current direction of the ship to left
        /// </summary>
        public void PushLeft()
        {
            lock (EntitiesLock)
            {
                this.Ship.SetCurrentDirection(MoveDirection.Left);
            }

        }

        /// <summary>
        /// Change the current direction of the ship to up
        /// </summary>
        public void PushUp()
        {
            lock (EntitiesLock)
            {
                this.Ship.SetCurrentDirection(MoveDirection.Up);
            }

        }

        /// <summary>
        /// Change the current direction of the ship to down
        /// </summary>
        public void PushDown()
        {
            lock (EntitiesLock)
            {
                this.Ship.SetCurrentDirection(MoveDirection.Down);
            }
        }

        /// <summary>
        /// Change the current direction of the ship to none
        /// </summary>
        public void ReleaseDirection()
        {
            lock (EntitiesLock)
            {
                this.Ship.SetCurrentDirection(MoveDirection.None);
            }
        }

        /// <summary>
        /// Create Lasers
        /// </summary>
        public void Fire()
        {
            // Cooldown verification
            DateTime currentDateTime = DateTime.UtcNow;
            // Try fire restart the fire reloading cooldown
            FireOrReloadLastDateTime = currentDateTime;

            // Minimum fire cooldown
            if (currentDateTime.Subtract(ActionFireLastDateTime) < GameConfiguration.ActionFireShootCooldown)
                return;

            // Latest real fire action
            ActionFireLastDateTime = currentDateTime;

            // Fire
            Laser laser = this.Ship.Fire();
            if (laser != null)
            {
                lock (EntitiesLock)
                {
                    this.Entities.Add(laser);
                }
                // Play the sound of the laser
                this.AudioEngine.Play(Sounds.Laser);
            }

        }

        /// <summary>
        /// Active bullet time
        /// </summary>
        public void BulletTime()
        {
            if (!this.IsBulletTimeActivated)
            {
                this.BulletTimeSoundTokenSource = new CancellationTokenSource();
                this.AudioEngine.Play(Sounds.BulletTime, true, this.BulletTimeSoundTokenSource.Token);
                this.IsBulletTimeActivated = true;
            }
        }

        /// <summary>
        /// Deactivate bullet time
        /// </summary>
        public void ReleaseBulletTime()
        {
            if (this.IsBulletTimeActivated)
            {
                this.IsBulletTimeActivated = false;
                this.BulletTimeSoundTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Allow to retrieve the game entities
        /// </summary>
        /// <returns>An enumeration of the game entities</returns>
        public IEnumerable<IEntityBase> GetEntities()
        {
            lock (this.EntitiesLock)
            {
                return this.Entities.ToList();
            }
        }

        /// <summary>
        /// Allow to retrieve the game entities
        /// </summary>
        /// <returns>An enumeration of the game entities</returns>
        public IEntityBase GetBackground()
        {
            lock (EntitiesLock)
            {
                return this.Background;
            }
        }

        /// <summary>
        /// Move the entities on their related move direction
        /// </summary>
        private void MoveEntities()
        {
            lock (this.EntitiesLock)
            {
                foreach (GameEntity entity in this.Entities.ToList())
                {
                    switch (entity.GetCurrentDirection())
                    {
                        case MoveDirection.Left:
                            if (entity.GetLocation().X > entity.GetMoveSpeed())
                                entity.SetLocationX(entity.GetLocation().X - entity.GetMoveSpeed());
                            break;
                        case MoveDirection.Right:
                            if (entity.GetLocation().X + entity.GetSize().Width < this.MaxWidth)
                                entity.SetLocationX(entity.GetLocation().X + entity.GetMoveSpeed());
                            break;
                        case MoveDirection.Up:
                            if ((entity.GetLocation().Y > this.MaxHeight / 1.5) || !(entity is Ship))
                                entity.SetLocationY(entity.GetLocation().Y - entity.GetMoveSpeed());
                            break;
                        case MoveDirection.Down:
                            if (entity.GetLocation().Y < this.MaxHeight - entity.GetSize().Height || !(entity is Ship))
                                entity.SetLocationY(entity.GetLocation().Y + entity.GetMoveSpeed());
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Clean off fields entities 
        /// </summary>
        private void CleanEntities()
        {
            lock (this.EntitiesLock)
            {
                foreach (GameEntity entity in this.Entities.ToList())
                {
                    switch (entity.GetCurrentDirection())
                    {
                        case MoveDirection.Down:
                            if (entity.GetLocation().Y > this.MaxHeight)
                                this.Entities.Remove(entity);
                            break;
                        case MoveDirection.Up:
                            if (entity.GetLocation().Y < 0 - entity.GetSize().Height)
                                this.Entities.Remove(entity);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Initialize the game
        /// </summary>
        private void InitAndNotifyBackground()
        {
            // Create the background
            this.Background = new Background(GameConfiguration.INIT_BACKGROUND_MOVESPEED);
            this.Background.SetLocationY(this.MaxHeight - this.Background.GetSize().Height);

            // Background updated nofitication
            this.BackgroundUpdated?.Invoke(this, BackgroundUpdatedEventArg.Empty);
        }

        /// <summary>
        /// Initialize the game
        /// </summary>
        private void InitShip()
        {
            // Create the ship
            this.Ship = new Ship(
                new Size(100, 100),
                new Point((this.MaxWidth / 2) - 80 / 2, this.MaxHeight - 110),
                15,
                GameConfiguration.INIT_SHIP_HP,
                GameConfiguration.INIT_SHIP_SP,
                GameConfiguration.INIT_GLOBAL_DAMAGE,
                GameConfiguration.INIT_SHIP_FP_MAX,
                MoveDirection.None);
            this.ActionFireLastDateTime = DateTime.MinValue;
            this.FireOrReloadLastDateTime = DateTime.MinValue;
            this.Entities.Add(this.Ship);
        }

        /// <summary>
        /// Increments the score
        /// </summary>
        private void ManageScore()
        {
            // Increment the score
            this.Score++;
        }

        /// <summary>
        /// Increments the level
        /// </summary>
        private void ManageLevel()
        {
            if (this.Score % 2500 == 0)
            {
                //Increment the level every 2500 score point
                this.Level++;
                // Play a sound when level up is reached
                this.AudioEngine.Play(Sounds.LevelUp);
                //Increment the min and max number of asteroid
                this.AsteroidMinNumber++;
                this.AsteroidMaxNumber++;
                //Increment the min and max speed of asteroid
                this.AsteroidMinSpeed++;
                this.AsteroidMaxSpeed++;
                //Increment the number min and max of the enemy
                this.EnemiesMinNumber++;
                this.EnemiesMaxNumber++;

            }
        }

        /// <summary>
        /// Test the end of the game and play the sound game over sound
        /// </summary>
        private bool IsEndOfGame()
        {
            bool endOfGame = (this.Ship.GetHp() <= 0);
            // End of the game detection
            if (endOfGame)
            {
                // Play the impact and the game over sound
                this.AudioEngine.Play(Sounds.GameOver);
                lock (this.EntitiesLock)
                {
                    // Stop listining the enemy firing 
                    foreach (Enemy enemy in this.Entities.Where(e => e is Enemy).ToList())
                    {
                        enemy.EnemyFired -= OnEnemyFired;
                    }
                }
            }
            return endOfGame;
        }

        /// <summary>
        /// Manage the scrolling of the game background
        /// </summary>
        private void ManageBackground()
        {
            // if the game reached the end of the background : restart
            if (this.Background.GetLocation().Y < 0)
                this.Background.SetLocationY(this.Background.GetLocation().Y + this.Background.GetMoveSpeed());
            else
                this.Background.SetLocationY(this.MaxHeight - this.Background.GetSize().Height);
        }

        /// <summary>
        /// Determines if the type of entities is managed for the bullet time
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsBulletTimeTypeManaged(Type type)
        {
            if (type == typeof(Asteroid))
                return true;
            else if (type == typeof(Background))
                return true;
            else if (type == typeof(LaserEnemy))
                return true;
            else if (type == typeof(Enemy))
                return true;
            else if (type == typeof(Laser))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Manage the creations and the moves of the asteroids
        /// </summary>
        /// <param name="loopIndex">Loop index</param>
        private void GenerateAsteroids(int loopIndex)
        {
            // Random asteroids creation every 100 loops
            if (loopIndex % 100 == 0)
            {
                lock (this.EntitiesLock)
                {
                    IEnumerable<GameEntity> asteroids = CreateRandomAsteroids();
                    this.Entities.AddRange(asteroids);
                }
            }
        }

        /// <summary>
        /// Manage the creations and the moves of the ShieldBonus
        /// </summary>
        /// <param name="loopIndex">Loop index</param>
        private void GenerateShieldBonuses(int loopIndex)
        {
            // Random ShieldBonus creation every 750 loops
            if (loopIndex % 750 == 0)
            {
                lock (this.EntitiesLock)
                {
                    IEnumerable<GameEntity> shieldBonus = CreateRandomShieldBonus();
                    this.Entities.AddRange(shieldBonus);
                }
            }
        }

        /// <summary>
        /// Manage the creations and the moves of the Enemies
        /// </summary>
        /// <param name="loopIndex">Loop index</param>
        private void GenerateEnemies(int loopIndex)
        {
            // Random Enemies creation every 800 loops
            if (loopIndex % 800 == 0)
            {
                lock (this.EntitiesLock)
                {
                    IEnumerable<GameEntity> enemies = CreateRandomEnemies();
                    this.Entities.AddRange(enemies);
                }
            }
        }

        /// <summary>
        /// Determines if the collision type is managed
        /// </summary>
        /// <param name="type1">Type of the entity 1</param>
        /// <param name="type2">Type of the entity 2</param>
        /// <returns>True if the colision is managed, otherwise false</returns>
        private bool IsCollisionTypeManaged(Type type1, Type type2)
        {
            if (type1 == typeof(Ship) && type2 == typeof(Asteroid) || type1 == typeof(Asteroid) && type2 == typeof(Ship))
                return true;
            else if (type1 == typeof(Laser) && type2 == typeof(Asteroid) || type1 == typeof(Asteroid) && type2 == typeof(Laser))
                return true;
            else if (type1 == typeof(Ship) && type2 == typeof(ShieldBonus) || type1 == typeof(ShieldBonus) && type2 == typeof(Ship))
                return true;
            else if (type1 == typeof(Ship) && type2 == typeof(LaserEnemy) || type1 == typeof(LaserEnemy) && type2 == typeof(Ship))
                return true;
            else if (type1 == typeof(Laser) && type2 == typeof(Enemy) || type1 == typeof(Enemy) && type2 == typeof(Laser))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Manage the Bullet Time
        /// </summary>
        private void ManageBulletTime()
        {
            lock (this.EntitiesLock)
            {
                List<GameEntity> entities = this.Entities.ToList();

                if (IsBulletTimeActivated)
                {
                    foreach (GameEntity entity in entities)
                    {
                        if (entity.GetOldMoveSpeed() == entity.GetMoveSpeed() && IsBulletTimeTypeManaged(entity.GetType()))
                        {
                            var move = entity.GetMoveSpeed();
                            var lowmove = move / 3;
                            entity.SetMoveSpeed(lowmove);
                        }
                    }
                }
                else
                {
                    foreach (GameEntity entity in entities)
                    {
                        if (entity.GetOldMoveSpeed() != entity.GetMoveSpeed() && IsBulletTimeTypeManaged(entity.GetType()))
                        {
                            entity.SetMoveSpeed(entity.GetOldMoveSpeed());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Manage the entity collisions.
        /// </summary>
        /// <returns>True if the ship is dead, otherwise false</returns>s
        private void ManageEntitiesCollisions()
        {
            lock (this.EntitiesLock)
            {
                List<GameEntity> entities = this.Entities.ToList();
                GameEntity entity = entities.FirstOrDefault();

                // While there is an entity to manage
                while (entity != null)
                {
                    // For each other entity in collision
                    foreach (GameEntity collision in entities.Where(e => e.GetHitBox().IntersectsWith(entity.GetHitBox()) && !e.Equals(entity)).ToList())
                    {
                        // Only collisions managed
                        if (IsCollisionTypeManaged(entity.GetType(), collision.GetType()))
                        {
                            //Shield collisions management
                            if (collision is ShieldBonus && entity is Ship)
                            {
                                entity.BonusShield(collision.GetSp());
                            }
                            else if (collision is Ship && entity is ShieldBonus)
                            {
                                collision.BonusShield(entity.GetSp());
                            }

                            // Deal the damage to both entities and remove dead entities
                            if (entity.Damage(collision.GetDp()))
                            {
                                this.Entities.Remove(entity);
                                // Stop listining the enemy firing and play the explosion sound
                                if (entity is Enemy)
                                {
                                    this.AudioEngine.Play(Sounds.EnemyExplosion);
                                    (entity as Enemy).EnemyFired -= OnEnemyFired;
                                }

                            }

                            if (collision.Damage(entity.GetDp()))
                                this.Entities.Remove(collision);

                            // Now the colision is managed
                            entities.Remove(collision);
                        }
                        // Manage audio collision
                        ManageAudioCollision(entity, collision);
                    }
                    // Now the entity is managed
                    entities.Remove(entity);
                    entity = entities.FirstOrDefault();
                }
            }
        }

        /// <summary>
        /// Allow to play a sound depending of the type of a collision
        /// </summary>
        /// <param name="entity1">Entity 1 of the collision</param> 
        /// <param name="entity2">Entity 2 of the collision</param>
        private void ManageAudioCollision(GameEntity entity1, GameEntity entity2)
        {
            if (entity1 is Ship && entity2 is Asteroid || entity1 is Asteroid && entity2 is Ship)
            {
                // Play the explosion sound
                this.AudioEngine.Play(Sounds.Explosion);
            }
            else if (entity1 is Asteroid && entity2 is Laser || entity1 is Laser && entity2 is Asteroid)
            {
                // Play the sound of the impact
                this.AudioEngine.Play(Sounds.Impact);
            }
            else if (entity1 is Enemy && entity2 is Laser || entity1 is Laser && entity2 is Enemy)
            {
                // Play the sound of the laser impact
                this.AudioEngine.Play(Sounds.ImpactLaser);
            }
            else if (entity1 is Ship && entity2 is LaserEnemy || entity1 is LaserEnemy && entity2 is Ship)
            {
                // Play the sound of the laser impact
                this.AudioEngine.Play(Sounds.ImpactLaser);
            }
            else if (entity1 is Ship && entity2 is ShieldBonus || entity1 is ShieldBonus && entity2 is Ship)
            {
                //Play the sound of the bonus shield
                this.AudioEngine.Play(Sounds.ShieldBonus);
            }
        }

        /// <summary>
        /// Manage the reload and the cooldown of the ship fire action
        /// </summary>
        private void ManageFireCooldown()
        {
            // If the cooldown is reached reload the fire points of the ship
            if (DateTime.UtcNow.Subtract(FireOrReloadLastDateTime) >= GameConfiguration.FireReloadCooldown)
            {
                // Until the max fire points
                if (this.Ship.GetFp() < GameConfiguration.INIT_SHIP_FP_MAX)
                    this.Ship.SetFp(this.Ship.GetFp() + 1);
                // Store the moment for the next cooldown verification
                FireOrReloadLastDateTime = DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Create some random asteroids
        /// </summary>
        /// <returns>An enumeration of new asteroids</returns>
        private IEnumerable<Asteroid> CreateRandomAsteroids()
        {
            Random rnd = new Random();
            List<Asteroid> asteroids = new List<Asteroid>();

            // Create a random count of asteroids
            for (uint ctr = 1; ctr <= rnd.Next(AsteroidMinNumber, AsteroidMaxNumber); ctr++)
            {
                // Create a random size of asteroid
                int RandomSizeAsteroid = rnd.Next(40, 80);
                // Create a random asteroid coordonate
                Point coordonate = new Point(rnd.Next(100, this.MaxWidth - 100), rnd.Next(-500, 0));
                // Create an asteroid on the coordonate with a random move speed
                asteroids.Add(new Asteroid(new Size(RandomSizeAsteroid, RandomSizeAsteroid), coordonate, rnd.Next(this.Background.GetMoveSpeed() + AsteroidMinSpeed, this.Background.GetMoveSpeed() + AsteroidMaxSpeed), 1, 1, GameConfiguration.INIT_GLOBAL_DAMAGE, MoveDirection.Down));
            }
            return asteroids;
        }

        /// <summary>
        /// Create some random Enemies
        /// </summary>
        /// <returns>An enumeration of new Enemies</returns>
        private IEnumerable<Enemy> CreateRandomEnemies()
        {
            Random rnd = new Random();
            List<Enemy> enemies = new List<Enemy>();

            // Create a random count of Enemies
            for (uint ctr = 1; ctr <= rnd.Next(EnemiesMinNumber, EnemiesMaxNumber); ctr++)
            {
                // Create a random Enemy coordonate
                Point coordonate = new Point(rnd.Next(100, this.MaxWidth - 100), rnd.Next(0, +300));
                // Create an Enemy on the coordonate with a random move speed
                Enemy enemy = new Enemy(new Size(100, 100), coordonate, rnd.Next(this.Background.GetMoveSpeed() + 1, this.Background.GetMoveSpeed() + 3), 100, 50, GameConfiguration.INIT_GLOBAL_DAMAGE, MoveDirection.None);
                // Start listening if is firing
                enemy.EnemyFired += OnEnemyFired;
                enemies.Add(enemy);
            }
            return enemies;
        }

        /// <summary>
        /// Raised when an enemy fired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="enemyFiredEventArgs"></param>
        private void OnEnemyFired(object sender, EnemyFiredEventArgs enemyFiredEventArgs)
        {
            lock (this.EntitiesLock)
            {
                if (enemyFiredEventArgs.Laser != null)
                {
                    this.Entities.Add(enemyFiredEventArgs.Laser);
                    // Play the sound of the laser
                    this.AudioEngine.Play(Sounds.Laser);
                }
            }
        }

        /// <summary>
        /// Create some random ShieldBonus
        /// </summary>
        /// <returns>An enumeration of new ShieldBonus</returns>
        private IEnumerable<ShieldBonus> CreateRandomShieldBonus()
        {
            Random rnd = new Random();
            List<ShieldBonus> shieldBonus = new List<ShieldBonus>();

            // Create a random count of ShieldBonus
            for (uint ctr = 1; ctr <= rnd.Next(1, 3); ctr++)
            {
                // Create a random ShieldBonus coordonate
                Point coordonate = new Point(rnd.Next(100, this.MaxWidth - 100), rnd.Next(-500, 0));

                // Create an ShieldBonus on the coordonate with a random move speed
                shieldBonus.Add(new ShieldBonus(new Size(20, 20), coordonate, rnd.Next(this.Background.GetMoveSpeed() * 1, this.Background.GetMoveSpeed() * 3), 1, 25, 0, MoveDirection.Down));
            }
            return shieldBonus;
        }


    }

    #region EventArgs

    public class EntitiesUpdatedEventArg : EventArgs
    {
        public new static EntitiesUpdatedEventArg Empty;
    }

    public class BackgroundUpdatedEventArg : EventArgs
    {
        public new static BackgroundUpdatedEventArg Empty;
    }

    public class ScoreUpdatedEventArg : EventArgs
    {
        public new static ScoreUpdatedEventArg Empty;

        public int Score { get; }

        public ScoreUpdatedEventArg(int score)
        {
            this.Score = score;
        }
    }

    public class LevelUpdatedEventArg : EventArgs
    {
        public new static LevelUpdatedEventArg Empty;

        public int Level { get; }

        public LevelUpdatedEventArg(int level)
        {
            this.Level = level;
        }
    }

    public class GameFininishedEventArg : EventArgs
    {
        public new static GameFininishedEventArg Empty;

        public int Score { get; }

        public GameFininishedEventArg(int score)
        {
            this.Score = score;
        }
    }

    public class ShipInformationsUpdatedEventArg : EventArgs
    {
        public new static ShipInformationsUpdatedEventArg Empty;

        public int Sp { get; }

        public int Hp { get; }

        public int Fp { get; }

        public ShipInformationsUpdatedEventArg(int hp, int sp, int fp)
        {
            this.Hp = hp;
            this.Sp = sp;
            this.Fp = fp;
        }
    }

    #endregion

    /// <summary>
    /// Possible move direction
    /// </summary>
    public enum MoveDirection
    {
        Left,
        Right,
        Up,
        Down,
        None
    }
}
