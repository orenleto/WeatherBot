namespace WeatherBot.RequestModels.ForecastApi
{
    public class Measure
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}