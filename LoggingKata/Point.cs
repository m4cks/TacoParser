using System;

namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        //Not needed with fancy new GeoCoordinate technology!
        /* public double GetDistanceTo(Point location)
        {
            var distanceBetweenLat = this.Latitude - location.Latitude;
            var distanceBetweenLon = this.Longitude - location.Longitude;

            return Math.Sqrt(Math.Pow(distanceBetweenLat, 2) + Math.Pow(distanceBetweenLon, 2));
        }*/
    }
}