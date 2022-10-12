using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    internal class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        /*
        public double GetDistanceTo(TacoBell tacoBell)
        {
            var distanceBetweenLat = this.Location.Latitude - tacoBell.Location.Latitude;
            var distanceBetweenLon = this.Location.Longitude - tacoBell.Location.Longitude;

            return Math.Sqrt(Math.Pow(distanceBetweenLat, 2) + Math.Pow(distanceBetweenLon, 2));

        }*/


    }
}
