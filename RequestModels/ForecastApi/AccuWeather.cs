namespace WeatherBot.RequestModels.ForecastApi
{
    public class AccuWeather
    {
        public Headline Headline { get; set; }
        public DailyForecast[] DailyForecasts { get; set; }
    }
}