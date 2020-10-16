using WeatherBot.DataReceivers.Models;

namespace WeatherBot.DataReceivers
{
    public interface IWeatherReceiver
    {
        WeatherDataModel GetWeather(string cityCode);
    }
}