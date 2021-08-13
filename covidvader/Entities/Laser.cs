using covidvader.Properties;
using CovidVader.Core;
using System.Drawing;

namespace CovidVader.Entities
{
    public class Laser: GameEntity
    {
        public Laser(Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, MoveDirection defaultMoveDirection) : base(Resources.laserRed05, entitySize, location, moveSpeed, hp, sp, dp, defaultMoveDirection)
        {

        }
    }
}
