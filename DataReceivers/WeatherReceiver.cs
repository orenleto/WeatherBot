using System;
using System.Linq;
using WeatherBot.DataReceivers.Models;
using WeatherBot.Infrastructure;
using WeatherBot.RequestModels.ForecastApi;

namespace WeatherBot.DataReceivers
{
    public class WeatherReceiver : IWeatherReceiver
    {
        private readonly string _apiKey;

        public WeatherReceiver(string apiKey)
        {
            _apiKey = apiKey;
        }

        public WeatherDataModel GetWeather(string cityCode)
        {
            var responseAccuWeather = Webber.Get<AccuWeather>(
                $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{cityCode}" +
                $"?apikey={_apiKey}" +
                "&details=true" +
                "&metric=true"
            );

            var weather = responseAccuWeather.Result.DailyForecasts.FirstOrDefault();
            if (weather == null)
            {
                return null;
            }

            return new WeatherDataModel
            {
                MinimumTemperature = weather.Temperature.Minimum.Value,
                MaximumTemperature = weather.Temperature.Maximum.Value,
                SunlightDuration = DateTime.Parse(weather.Sun.Set) - DateTime.Parse(weather.Sun.Rise),
                RealFeelTemperature = (weather.RealFeelTemperature.Minimum.Value + weather.RealFeelTemperature.Maximum.Value) / 2,
                WindSpeed = weather.Day.Wind.Speed.Value,
                WindDirection = weather.Day.Wind.Direction.English,
                PrecipitationProbability = weather.Day.PrecipitationProbability
            };
        }
    }
}