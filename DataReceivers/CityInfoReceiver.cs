using System.Linq;
using WeatherBot.DataReceivers.Models;
using WeatherBot.Infrastructure;
using WeatherBot.RequestModels.LocationApi;

namespace WeatherBot.DataReceivers
{
    public class CityInfoReceiver : ICityInfoReceiver
    {
        private readonly string _apiKey;

        public CityInfoReceiver(string apiKey)
        {
            _apiKey = apiKey;
        }

        public CityDataModel GetCityInformation(string cityName)
        {
            var citiesResponse = Webber.Get<Location[]>(
                "http://dataservice.accuweather.com/locations/v1/cities/search" +
                $"?apikey={_apiKey}" +
                $"&q={cityName}" +
                "&details=true"
            );
            var city = citiesResponse
                .Result
                .OrderBy(x => x.Rank)
                .FirstOrDefault();

            return city != null
                ? CityDataModel.BuildSuccess(city)
                : CityDataModel.BuildFailed();
        }
    }
}