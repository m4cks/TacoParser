using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            if(lines[0] == null)
            {
                logger.LogError("No Lines!");
            } else if (lines[1] == null)
            {
                logger.LogWarning("Only One Line.");
            }
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable firstTacoBell = null;
            ITrackable secondTacoBell = null;
            double greatestDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            GeoCoordinate locA;
            GeoCoordinate locB;
            

            for(int i = 0; i < locations.Length; i++)
            {
                locA = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);
                for(int j = 1; j < locations.Length; j++)
                {
                    locB = new GeoCoordinate(locations[j].Location.Latitude, locations[j].Location.Longitude);
                    if (locA.GetDistanceTo(locB) > greatestDistance)
                    {
                        greatestDistance = locA.GetDistanceTo(locB);
                        firstTacoBell = locations[i];
                        secondTacoBell = locations[j];
                        //Console.WriteLine($"Updating the new greatest distance! It is now {greatestDistance} and it is between {firstTacoBell.Name} and {secondTacoBell.Name}");
                    }
                }
            }
            
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            Console.WriteLine($"The greatest distance is between {firstTacoBell.Name} and {secondTacoBell.Name}. The Distance is {greatestDistance}");
        }
    }
}
