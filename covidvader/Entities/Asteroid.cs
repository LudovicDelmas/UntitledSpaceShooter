using covidvader.Properties;
using CovidVader.Core;
using System;
using System.Drawing;

namespace CovidVader.Entities
{
    public class Asteroid : GameEntity
    {
        private static Image GetRandomAsteroidImage()
        {
            Random random = new Random();

            int randomAsteroid = random.Next(1, 4);

            switch (randomAsteroid)
            {
                case 1:
                    return Resources.meteorBrown_big1;
                case 2:
                    return Resources.meteorBrown_big2;
                case 3:
                    return Resources.meteorBrown_big3;
                case 4:
                    return Resources.meteorBrown_big4;
                default:
                    return Resources.meteorBrown_big1;
            }

        }

        public Asteroid(Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, MoveDirection defaultMoveDirection) : base(GetRandomAsteroidImage(), entitySize, location, moveSpeed, hp, sp, dp, defaultMoveDirection)
        {
        }
    }
}
