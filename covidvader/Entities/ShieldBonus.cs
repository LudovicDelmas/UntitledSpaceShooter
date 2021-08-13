
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CovidVader.Core;
using covidvader.Properties;

namespace CovidVader.Entities
{
    public class ShieldBonus : GameEntity
    {
        public ShieldBonus(Size entitySize, Point location, int moveSpeed, int hp, int sp, int dp, MoveDirection defaultMoveDirection) : base(Resources.pill_blue, entitySize, location, moveSpeed, hp, sp, dp, defaultMoveDirection)
        {

        }
    }
}
