namespace WeatherBot.RequestModels.ForecastApi
{
    public class Sun
    {
        public string Rise { get; set; }
        public long EpochRise { get; set; }
        public string Set { get; set; }
        public long EpochSet { get; set; }
    }
}