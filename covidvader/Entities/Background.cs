using covidvader.Properties;
using System;
using System.Drawing;
using System.IO;

namespace CovidVader.Entities
{
    public class Background : EntityBase
    {
        /// <summary>
        /// Background image path
        /// </summary>
        private static readonly Image BACKGROUND_IMAGE_PATH = Resources.background;

        /// <summary>
        /// Background image size
        /// </summary>
        private static readonly Size BACKGROUND_SIZE = new Size(1020, 2296);

        /// <summary>
        /// Background image location
        /// </summary>
        private static readonly Point BACKGROUND_IMAGE_LOCATION = new Point(0, 0);

        public Background(int moveSpeed): base(BACKGROUND_IMAGE_PATH, BACKGROUND_SIZE, BACKGROUND_IMAGE_LOCATION, moveSpeed)
        {
        }
    }
}
