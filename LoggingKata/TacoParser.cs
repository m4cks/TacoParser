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
            //logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong. Log it and return null
            if (cells.Length < 3)
            {
                logger.LogWarning($"Less than 3 cells in line: \"{line}\"");   
                return null; 
            }

            //Latitude,Longitude,Name
            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            //TacoBell class extends ITrackable so we can return a TacoBell object 
            TacoBell tacoBell = new TacoBell();
            tacoBell.Location = new Point() { Latitude = latitude, Longitude = longitude };
            tacoBell.Name = name;

            return tacoBell;
        }
    }
}