namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
           // logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                TacoLogger tacoLogger = new TacoLogger();
                tacoLogger.LogInfo($"Less than 3 cells in line: \"{line}\"");
                // Do not fail if one record parsing fails, return null
                return null; 
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

 
            TacoBell tacoBell = new TacoBell();
            tacoBell.Location = new Point() { Latitude = latitude, Longitude = longitude };
            tacoBell.Name = name;

            return tacoBell;
        }
    }
}