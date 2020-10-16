using WeatherBot.DataReceivers.Models;

namespace WeatherBot.DataReceivers
{
    public interface ICityInfoReceiver
    {
        CityDataModel GetCityInformation(string cityName);
    }
}