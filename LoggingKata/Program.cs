using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    /// <summary>
    /// Parses a CSV file and compares GeoLocations of TacoBells
    /// saves the two TacoBells with the greatest distance between eachother and their distance
    /// </summary>
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            logger.LogInfo($"Path name of file: {csvPath}");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            
            var lines = File.ReadAllLines(csvPath);
            
            if(lines[0] == null)
            {
                logger.LogError("No Lines!");
            } else if (lines[1] == null)
            {
                logger.LogWarning($"Only One Line: {lines[0]}");
            }
            
            // New instance of TacoParser class
            var parser = new TacoParser();

            // Grabs an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable firstTacoBell = null;
            ITrackable secondTacoBell = null;
            double greatestDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            GeoCoordinate locA = new GeoCoordinate();
            GeoCoordinate locB = new GeoCoordinate();

            //Nested loop to compare each Location against every other Location
            for(int i = 0; i < locations.Length; i++)
            {
                //Instead of creating a new GeoCoordinate each time, let's simply update the Lat and Lon data
                locA.Latitude = locations[i].Location.Latitude;
                locA.Longitude = locations[i].Location.Longitude;

                for (int j = 1; j < locations.Length; j++)
                {
                    locB.Latitude = locations[j].Location.Latitude;
                    locB.Longitude = locations[j].Location.Longitude;

                    if (locA.GetDistanceTo(locB) > greatestDistance)
                    {
                        greatestDistance = locA.GetDistanceTo(locB);
                        firstTacoBell = locations[i];
                        secondTacoBell = locations[j];
                        //logger.LogInfo($"Updating the new greatest distance! It is now {greatestDistance} and it is between {firstTacoBell.Name} and {secondTacoBell.Name}");
                    }
                }
            }
            
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            logger.LogInfo($"The greatest distance is between {firstTacoBell.Name} and {secondTacoBell.Name}. The Distance is {greatestDistance} meters");
        }
    }
}
