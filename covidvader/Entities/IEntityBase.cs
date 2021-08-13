using System.Drawing;

namespace CovidVader.Entities
{
    public interface IEntityBase
    {
        Image GetImage();
        Point GetLocation();
    }
}
