using Ninject.Modules;
using WeatherBot.DataReceivers;

namespace WeatherBot
{
    public class Bindings : NinjectModule
    {
        private readonly string _apiKey;

        public Bindings(string apiKey)
        {
            _apiKey = apiKey;
        }

        public override void Load()
        {
            Bind<IWeatherReceiver>().To<WeatherReceiver>().WithConstructorArgument(@"apiKey", _apiKey);;
            Bind<ICityInfoReceiver>().To<CityInfoReceiver>().WithConstructorArgument(@"apiKey", _apiKey);;
        }
    }
}