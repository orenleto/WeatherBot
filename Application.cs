using System;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using WeatherBot.DataReceivers;

namespace WeatherBot
{
    public class Application
    {
        private readonly IWeatherReceiver _weatherReceiver;
        private readonly ICityInfoReceiver _cityInfoReceiver;
        private readonly TelegramBotClient _telegramBotClient;

        private static readonly Regex CityNameRegexp =
            new Regex(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", RegexOptions.Compiled);

        public Application(
            string apikey,
            IWeatherReceiver weatherReceiver,
            ICityInfoReceiver cityInfoReceiver
        )
        {
            _telegramBotClient = new TelegramBotClient(apikey);
            _weatherReceiver = weatherReceiver;
            _cityInfoReceiver = cityInfoReceiver;
        }

        public void Run()
        {
            _telegramBotClient.OnMessage += HandleMessage;
            _telegramBotClient.StartReceiving();
        }

        private void HandleMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type != MessageType.Text)
            {
                _telegramBotClient.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    "Я умею обрабатывать только названия городов."
                );
                return;
            }

            var cityName = e.Message.Text;
            if (cityName == null)
            {
                return;
            }

            if (!CityNameRegexp.IsMatch(cityName))
            {
                _telegramBotClient.SendTextMessageAsync(
                        e.Message.Chat.Id,
                    $"\'{cityName}\' - некорректное название города. Введите, пожалуйста на английском."
                );
                return;
            }

            var cityModel = _cityInfoReceiver.GetCityInformation(cityName);
            if (!cityModel.IsSuccess)
            {
                _telegramBotClient.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    $"У меня нет информации о городе \'{cityName}\'."
                );
                return;
            }

            var weatherDataModel = _weatherReceiver.GetWeather(cityModel.CityCode);

            _telegramBotClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                $"{cityModel}{Environment.NewLine}{weatherDataModel}"
            );
        }
    }
}