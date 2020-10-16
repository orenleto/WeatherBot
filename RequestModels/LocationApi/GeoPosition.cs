namespace WeatherBot.RequestModels.LocationApi
{
    public class GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Elevation Elevation { get; set; }
    }
}