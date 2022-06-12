using System;
using System.Collections.Generic;
using System.Text;
using WeatherUtility;

namespace Weather
{
    public class SphereWeatherGen
    {
        public static string WeatherReport()
        {
            int season = Seasons.Season();
            int temperature = Temperature.Temp(season);
            string weather = RainChance.Rain(season);
            string[] seasonList = new string[4] { "Winter", "Spring", "Summer", "Fall" };
            string currentSeason = seasonList[season];
            DateTime today = DateTime.Today;
            DateTime nextWeek = today.AddDays(6);
            int celsius = CelsiusConvert(temperature);

            return $"**__This week's weather forecast is:__**\nDate: {today.Day}-{today.Month}-{today.Year} to {nextWeek.Day}-{nextWeek.Month}-{nextWeek.Year}\nSeason: {currentSeason}\nTemperature: {temperature}° F/{celsius}° C\nWeather: {weather}";
        }

        static int CelsiusConvert(int F)
        {
            double H = (F - 32) / 1.8;
            int C = Convert.ToInt32(Math.Round(H));
            return C;
        }
    }
}
