using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using covidvader.Properties;
using CovidVader.Core;

namespace CovidVader.Entities
{
    public class LaserEnemy : GameEntity
    {
        public LaserEnemy(Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, MoveDirection defaultMoveDirection) : base(Resources.laserGreen05, entitySize, location, moveSpeed, hp, sp, dp, defaultMoveDirection)
        {

        }
    }
}
