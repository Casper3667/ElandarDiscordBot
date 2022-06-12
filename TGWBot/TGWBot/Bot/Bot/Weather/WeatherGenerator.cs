using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class WeatherGenerator
    {
        public static string WeatherReport()
        {
            int season = Season();
            int temperature = Temp(season);
            string weather = Weather(season);
            string[] seasonList = new string[4] { "Winter", "Spring", "Summer", "Fall" };
            string currentSeason = seasonList[season];
            DateTime today = DateTime.Today;
            DateTime nextWeek = today.AddDays(6);
            int celsius = CelsiusConvert(temperature);

            return $"**__This week's weather forecast is:__**\nDate: {today.Day}-{today.Month}-{today.Year} to {nextWeek.Day}-{nextWeek.Month}-{nextWeek.Year}\nSeason: {currentSeason}\nTemperature: {temperature}° F/{celsius}° C\nWeather: {weather}";
        }

        private static int Season()
        {
            int result = 1;
            DateTime Today = DateTime.Today;
            if (Today.Month == 1 || Today.Month == 2 || Today.Month == 12)
            {
                result = 0;
            }
            else if (Today.Month == 3 || Today.Month == 4 || Today.Month == 5)
            {
                result = 1;
            }
            else if (Today.Month == 6 || Today.Month == 7 || Today.Month == 8)
            {
                result = 2;
            }
            else if (Today.Month == 9 || Today.Month == 10 || Today.Month == 11)
            {
                result = 3;
            }
            return result;
        }

        private static int Temp(int season)
        {
            // Temperature baseline: winter, spring, summer, fall
            // int[] TempBaseList = new int[4] { 50, 75, 95, 75 };
            int[] TempBaseList = new int[4] { 60, 75, 80, 75 };
            int Temperature = TempBaseList[season];
            Random rnd = new Random();
            int random = rnd.Next(1, 100);
            int weatherModifier = 0;

            #region Temperature Mod
            if (random <= 10)
            {
                // weatherModifier = rnd.Next(2, 20);
                weatherModifier = rnd.Next(5, 10);
                Temperature -= weatherModifier;
            }
            else if (random >= 11 && random <= 25)
            {
                weatherModifier = rnd.Next(1, 10);
                Temperature -= weatherModifier;
            }
            else if (random >= 26 && random <= 55)
            {
                Temperature += weatherModifier;
            }
            else if (random >= 56 && random <= 85)
            {
                weatherModifier = rnd.Next(1, 10);
                Temperature += weatherModifier;
            }
            else if (random >= 86)
            {
                // weatherModifier = rnd.Next(2, 20);
                weatherModifier = rnd.Next(5, 10);
                Temperature += weatherModifier;
            }
            #endregion

            Console.WriteLine(Temperature);


            return Temperature; // + 10;
        }

        static string Weather(int season)
        {
            string[] SeasonalBaseline = new string[4] { "rare", "common", "intermitten", "common" };

            Random rnd = new Random();
            int random = rnd.Next(1, 100);
            bool precipitation = false;
            string weather = "Clear with some clouds";

            if (season == 0)
            {
                if (random <= 15)
                {
                    precipitation = true;
                }
                else
                {
                    precipitation = false;
                }
            }
            else if (season == 1 || season == 3)
            {
                if (random <= 60)
                {
                    precipitation = true;
                }
                else
                {
                    precipitation = false;
                }
            }
            else if (season == 3)
            {
                if (random <= 30)
                {
                    precipitation = true;
                }
                else
                {
                    precipitation = false;
                }
            }
            if (precipitation == true)
            {
                weather = WeatherType();
            }

            return weather;
        }

        static string WeatherType()
        {
            string[] weathertype = new string[6] { "light fog", "heavy fog","drizzle", "rain", "heavy rain", "thunderstorm" };

            Random rnd = new Random();
            int random = rnd.Next(1, 100);
            int windrandom = rnd.Next(1, 100);
            int weather = 0;
            string extraWeather = "";

            if (random <= 10)
            {
                weather = 0;
                extraWeather = "\nEffect: Light fog reduces visibility to three-quarters of the normal ranges, resulting in a –2 penalty on Perception checks and a –2 penalty on ranged attacks. Light fog typically occurs early in the day, late in the day, or sometimes at night, but the heat of the midday usually burns it away. Light fog occurs only when there is no or light wind.";
            }
            else if (random >= 11 && random <= 15)
            {
                weather = 1;
                extraWeather = "\nEffect: Heavy fog obscures all vision beyond 5 feet, including darkvision. Creatures 5 feet away have concealment. Heavy fog typically occurs early in the day, late in the day, or sometimes at night, but the heat of the midday usually burns it away. Heavy fog occurs only when there is no or light wind.";
            }
            else if (random >= 16 && random <= 25)
            {
                weather = 2;
                extraWeather = "\nEffect: Drizzle reduces visibility to three-quarters of the normal range, imposing a –2 penalty on Perception checks. It automatically extinguishes tiny unprotected flames (candles and the like, but not torches).";
            }
            else if (random >= 26 && random <= 50)
            {
                weather = 3;
                extraWeather = "\nEffect: Rain reduces visibility ranges by half, resulting in a –4 penalty on Perception checks. Rain automatically extinguishes unprotected flames (candles, torches, and the like) and imposes a –4 penalty on ranged attacks.";
            }
            else if (random >= 51 && random <= 80)
            {
                weather = 4;
                extraWeather = "\nEffect: Heavy rain reduces visibility to one-quarter of the normal range, resulting in a –6 penalty on Perception checks. Heavy rain automatically extinguishes unprotected flames and imposes a –6 penalty on ranged attacks.";
            }
            else if (random >= 81)
            {
                weather = 5;
                extraWeather = "\nEffect: Thunderstorms feature powerful winds and heavy rain (see above). To determine the type of wind associated with the thunderstorm, roll on Table 4–27: Thunderstorm Winds.";
            }
            return weathertype[weather] + extraWeather;
        }

        static int CelsiusConvert(int F)
        {
            double H = (F - 32) / 1.8;
            int C = Convert.ToInt32(Math.Round(H));
            return C;
        }
    }
}
