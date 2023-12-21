using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Practice_1._8
{
    internal class WeatherApp
    {
        public static void Main(string[] args)
        {
            string pathDefault = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.8/DefaultCity.json";

            Default defaultTown = JsonConvert.DeserializeObject<Default>(File.ReadAllText(pathDefault));
            if (defaultTown != null)
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={defaultTown.DefaultTown}&units=metric&appid=6ebcb57ff53cb27f5044f1b0e383c64e";
                HttpWebRequest weatherRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse weatherResponse = (HttpWebResponse)weatherRequest.GetResponse();
                string response;
                using (StreamReader weatherReader = new StreamReader(weatherResponse.GetResponseStream()))
                {
                    response = weatherReader.ReadToEnd();
                }
                WeatherResponse info = JsonConvert.DeserializeObject<WeatherResponse>(response);
                Console.WriteLine("Температура в {0} {1} °C\nОщущается как {2} °C\nВетер {3} м/с", info.Name, info.Main.Temp, info.Main.Feels_Like, info.Wind.Speed);
            }
            else Console.WriteLine("Город по умолчанию не установлен");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:\n[weather city] - получить данные о погоде в определенном городе\n[set default] - установить новое значение города по умолчанию\n[exit] - выйти из программы");
                string command = Console.ReadLine();
                Console.Clear();
                if (command == "weather city")
                {
                    Console.Write("Введите город: ");
                    string city = Console.ReadLine();
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=6ebcb57ff53cb27f5044f1b0e383c64e";
                    HttpWebRequest weatherRequest = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse weatherResponse = (HttpWebResponse)weatherRequest.GetResponse();
                    string response;
                    using (StreamReader weatherReader = new StreamReader(weatherResponse.GetResponseStream()))
                    {
                        response = weatherReader.ReadToEnd();
                    }
                    WeatherResponse info = JsonConvert.DeserializeObject<WeatherResponse>(response);
                    Console.WriteLine("\nТемпература в {0} {1} °C\nОщущается как {2} °C\nВетер {3} м/с", info.Name, info.Main.Temp, info.Main.Feels_Like, info.Wind.Speed);
                    continue;
                }
                if (command == "set default")
                {
                    Console.Write("Введите новый город по умолчанию: ");
                    string defaultTownLocalString = Console.ReadLine();
                    Default defaultTownLocal = new Default(defaultTownLocalString);
                    File.WriteAllText(pathDefault,JsonConvert.SerializeObject(defaultTownLocal));
                    Console.WriteLine("Город по умолчанию обновлён");
                    continue;
                }
                if (command == "exit") break;
                else Console.WriteLine("Неправильный формат ввода");
            }
        }
    }
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public WindInfo Wind { get; set; }
        public string Name { get; set; }
    }
    public class TemperatureInfo
    {
        public float Temp { get; set; }
        public float Feels_Like { get; set; }
    }
    public class WindInfo
    {
        public float Speed { get; set; }
    }
    public class Default
    {
        public string DefaultTown { get; set; }
        public Default(string defaultTown)
        {
            DefaultTown = defaultTown;
        }
    }
}