// Copyright (c) 2012-2019 FuryLion Group. All Rights Reserved.

using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Task3.CurrentWeather;
using Task3.ForecastWeather;

// Мой API key - 8ab2c616cd2b4473dcbbe231e161622c

namespace Task3
{
    internal static class Program
    {
        private enum Cities
        {
            Minsk = 1,
            London = 2,
            Paris = 3,
            Washington = 4,
            Navapolatsk = 5
        }

        private static void PrintWeather(WeatherResponse weatherResponse)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Weather report for {weatherResponse.Name},{weatherResponse.Sys.Country}\n\n");

            if (weatherResponse.Weather[0].Id >= 200 && weatherResponse.Weather[0].Id <= 232)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("      __   _");
                Console.WriteLine("    _(  )_( )_");
                Console.Write("   (_   _    _)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Main);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("     (_) (__)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Description);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("   /   / /  ");
                Console.WriteLine("  / /  /  / ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            if (weatherResponse.Weather[0].Id >= 300 && weatherResponse.Weather[0].Id <= 321)
            {
                Console.WriteLine("      __   _");
                Console.WriteLine("    _(  )_( )_");
                Console.Write("   (_   _    _)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Main);
                Console.Write("     (_) (__)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Description);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("   /   / /  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            if (weatherResponse.Weather[0].Id >= 500 && weatherResponse.Weather[0].Id <= 531)
            {
                Console.WriteLine("      __   _");
                Console.WriteLine("    _(  )_( )_");
                Console.Write("   (_   _    _)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Main);
                Console.Write("     (_) (__)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Description);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("   / / / /  ");
                Console.WriteLine("  / /  /  / ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            if (weatherResponse.Weather[0].Id >= 600  && weatherResponse.Weather[0].Id <= 622)
            {
                Console.WriteLine("      __   _");
                Console.WriteLine("    _(  )_( )_");
                Console.Write("   (_   _    _)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Main);
                Console.Write("     (_) (__)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Description);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("   * * * *  ");
                Console.WriteLine("  * *  *  * ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            if (weatherResponse.Weather[0].Id >= 701  && weatherResponse.Weather[0].Id <= 781)
            {
                Console.WriteLine(" ~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~");
                Console.Write(" ~~~~~~~~~~~~~~");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Main);
                Console.Write("~~~~~~~~~~~~~");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Description);
                Console.WriteLine(" ~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~");
            }

            if (weatherResponse.Weather[0].Id >= 801 && weatherResponse.Weather[0].Id <= 804)
            {
                Console.WriteLine("      __   _");
                Console.WriteLine("    _(  )_( )_");
                Console.Write("   (_   _    _)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Main);
                Console.Write("     (_) (__)");
                Console.WriteLine("\t\t{0}", weatherResponse.Weather[0].Description);
            }

            Console.Write("\nCurrent temp: ");
            if (weatherResponse.Main.Temp <= 0)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{weatherResponse.Main.Temp}C");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" (feels like ");
            if (weatherResponse.Main.TempFeelsLike <= 0)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{weatherResponse.Main.TempFeelsLike}C");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(')');
            
            Console.WriteLine($"\nHumidity: {weatherResponse.Main.Humidity}%");
            Console.WriteLine($"Pressure: {weatherResponse.Main.Pressure} hPa");
            Console.WriteLine("Visibility: {0}km", weatherResponse.Visibility / 1000);
            Console.WriteLine($"Wind speed: {weatherResponse.Wind.Speed} meter/sec " +
                              $"(weather direction - {weatherResponse.Wind.Deg})");

            Console.WriteLine();
        }

        private static void PrintForecast(ForecastReport forecastReport)
        {
            Console.WriteLine($"5 day forecast for {forecastReport.City.Name},{forecastReport.City.Country} below\n");
            
            for (var i = 0; i < 40; i++)
            {
                var days = 0;
                for (var x = i + 1; x < i + 9 && x < 40; x++)
                {
                    if (ForecastReport.Features[i].Dt.Day.Equals(ForecastReport.Features[x].Dt.Day))
                        days++;
                }

                Console.WriteLine("\t\t\t\t\t\t-------------------------");
                Console.WriteLine($"\t\t\t\t\t\t|\t{ForecastReport.Features[i].Dt.ToShortDateString()}\t|");
                Console.WriteLine("\t\t\t\t\t\t-------------------------");

                for (var x = i; x <= i + days; x++)
                    Console.Write($"{ForecastReport.Features[x].Dt.ToShortTimeString()}\t\t");

                Console.WriteLine();

                for (var x = i; x <= i + days; x++)
                    Console.Write($"{ForecastReport.Features[x].Weather[0].Main}\t\t");

                Console.WriteLine();

                for (var x = i; x <= i + days; x++)
                    Console.Write($"{ForecastReport.Features[x].Main.Temp}°C\t\t");

                Console.WriteLine();

                for (var x = i; x <= i + days; x++)
                    Console.Write(
                        $"{ForecastReport.Features[x].Wind.Speed}m/s, {ForecastReport.Features[x].Wind.Degrees}\t");

                Console.WriteLine();

                for (var x = i; x <= i + days; x++)
                    Console.Write(
                        $"{ForecastReport.Features[x].Visibility / 1000}km, {ForecastReport.Features[x].Main.Humidity}%\t");

                Console.WriteLine();

                for (var x = i; x <= i + days; x++)
                    Console.Write($"{ForecastReport.Features[x].Main.Pressure}hPa\t\t");

                i += days;
                Console.WriteLine("\n\n");
            }
        }

        private static async void DownloadWeather(string city, string apikey)
            {
                var response = "";
                var url =
                    "http://api.openweathermap.org/data/2.5/weather?units=metric";
                
                url += $"&q={city}&appid={apikey}";

                HttpWebRequest httpWebRequest = null;

                try
                {
                    httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
                }
                catch (WebException e)
                {
                    Console.Write("Error: {0}", e.Status);
                }
            
                HttpWebResponse httpWebResponse = null;

                try
                {
                    if (httpWebRequest != null) httpWebResponse = (HttpWebResponse) await httpWebRequest.GetResponseAsync();
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpWebResponse = (HttpWebResponse) e.Response;
                        Console.Write("Error code: {0} -- {1}.", (int) httpWebResponse.StatusCode,
                            httpWebResponse.StatusDescription);
                    }
                    else
                    {
                        Console.Write("Error: {0}", e.Status);
                    }

                    return;
                }

                if (httpWebResponse != null)
                    using (var responseStream = httpWebResponse.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var streamReader =
                                new StreamReader(httpWebResponse.GetResponseStream() ??
                                                 throw new InvalidOperationException()))
                            {
                                response = await streamReader.ReadToEndAsync();
                            }
                        }
                    }

                var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                
                PrintWeather(weatherResponse);
                
                DownloadForecast(city,apikey);
            }

            private static async void DownloadForecast(string city, string apikey)
            {
                var response = "";
                var url =
                    "http://api.openweathermap.org/data/2.5/forecast?units=metric";
                
                url += $"&q={city}&appid={apikey}";

                var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
                HttpWebResponse httpWebResponse;

                try
                {
                    httpWebResponse = (HttpWebResponse) await httpWebRequest.GetResponseAsync();
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpWebResponse = (HttpWebResponse) e.Response;
                        Console.Write("Error code: {0} -- {1}.", (int) httpWebResponse.StatusCode,
                            httpWebResponse.StatusDescription);
                    }
                    else
                    {
                        Console.Write("Error: {0}", e.Status);
                    }

                    return;
                }

                using (var responseStream = httpWebResponse.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var streamReader =
                            new StreamReader(httpWebResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                        {
                            response = await streamReader.ReadToEndAsync();
                        }
                    }
                }

                var forecastReport = JsonConvert.DeserializeObject<ForecastReport>(response);
                PrintForecast(forecastReport);
            }

            public static void Main()
            {
                var apikey = "";
                var city = "";
            
                while (true)
                {
                    Console.Clear();
                    if (string.IsNullOrEmpty(apikey))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No API key!");
                    }
                    else
                        Console.WriteLine($"API key - {apikey}");
                
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (string.IsNullOrEmpty(city))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No City defined!\n");
                    } 
                    else 
                        Console.WriteLine($"City - {city}\n");
                
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("1 - Change city");
                    Console.WriteLine("2 - Change API key\n");
                    Console.WriteLine("3 - Get Weather!\n");
                    Console.Write("0 - Exit\n\n>");
                    var choice = ReadInt(ReadIntCondition.Positive);
                    
                    switch (choice)
                    {
                        case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Main Menu -> Change City\n");
                            Console.WriteLine("1 - Enter location");
                            Console.WriteLine("2 - Select city from pre-defined list\n");
                            Console.Write("0 - Back\n\n>");
                            var choice11 = ReadInt(ReadIntCondition.Positive);
                            
                            switch (choice11)
                            {
                                case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Main Menu -> Change City -> Enter location\n");
                                    Console.Write("Enter desired city: ");
                                    do
                                    {
                                        city = Console.ReadLine();
                                    } 
                                    while (string.IsNullOrEmpty(city));
                                
                                    break;
                                }

                                case 2:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Main Menu -> Change City -> Select city from pre-defined list\n");
                                    Console.WriteLine("Select desired city:");
                                    Console.WriteLine("1 - Minsk");
                                    Console.WriteLine("2 - London");
                                    Console.WriteLine("3 - Paris");
                                    Console.WriteLine("4 - Washington");
                                    Console.WriteLine("5 - Navapolatsk\n\n>");
                                    var choose112 = Console.ReadLine();
                                    
                                    if (choose112 != null)
                                    {
                                        switch (Convert.ToInt32(choose112))
                                        {
                                            case (int) Cities.Minsk:
                                            {
                                                city = "Minsk";
                                                break;
                                            }
                                        
                                            case (int) Cities.London:
                                            {
                                                city = "London";
                                                break;
                                            }
                                        
                                            case (int) Cities.Paris:
                                            {
                                                city = "Paris";
                                                break;
                                            }

                                            case (int) Cities.Washington:
                                            {
                                                city = "Washington";
                                                break;
                                            }

                                            case (int) Cities.Navapolatsk:
                                            {
                                                city = "Navapolatsk";
                                                break;
                                            }
                                        }
                                    }

                                    System.Threading.Thread.Sleep(1000);
                                    break;
                                }
                            }
                            break;
                        }

                        case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Main Menu -> Change API key\n");
                            Console.Write("Enter your API key: ");
                            do
                            {
                                apikey = Console.ReadLine();
                            } 
                            while (string.IsNullOrEmpty(apikey));
                                
                            break;
                        }
                        
                        case 3:
                        {
                            Console.Clear();
                            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(apikey))
                            {
                                Console.WriteLine("Can't fetch weather! Check API key/city!");
                                Console.ReadKey();
                                break;
                            }
                            
                            DownloadWeather(city,apikey);
                            Console.ReadKey();
                            break;
                        }
                    
                        case 0:
                            return;
                    }
                }
            }

        private enum ReadIntCondition
        {
            None,
            Positive,
            Negative
        }

        private static int ReadInt(ReadIntCondition condition = ReadIntCondition.None)
        {
            var number = 0;
            var isParsed = false;
            var isConditioned = false;

            while (!isParsed || !isConditioned)
            {
                var input = Console.ReadLine();
		
                isParsed = int.TryParse(input, out number);
                if (!isParsed)
                {
                    Console.Write($"\"{input}\" isn't a number!\nPlease enter the number: ");
                    continue;
                }

                isConditioned = CheckReadIntCondition(number, condition);
                if (!isConditioned)
                    Console.Write($"\"{input}\" isn't appropriate in this case!\nPlease enter the number: ");
            }

            return number;
        }

        private static bool CheckReadIntCondition(int value, ReadIntCondition condition)
        {
            switch (condition)
            {
                case ReadIntCondition.None:
                    return true;
                case ReadIntCondition.Positive:
                    return value >= 0;
                case ReadIntCondition.Negative:
                    return value < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(condition), condition, null);
            }
        }
    }
}