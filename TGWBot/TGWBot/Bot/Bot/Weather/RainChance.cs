using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherUtility
{
    public class RainChance
    {
        public static string Rain(int season)
        {
            string[] SeasonalBaseline = new string[4] { "rare", "common", "intermitten", "common" };

            Random rnd = new Random();
            int random = rnd.Next(1, 100);
            bool precipitation = false;
            string weather = "Clear with some clouds";
            int chance = 0;

            switch (season)
            {
                case 0:
                    chance = 15;
                    break;
                case 3:
                    chance = 30;
                    break;
                default:
                    chance = 60;
                    break;
            }
            
            if (random <= chance)
                precipitation = true;

            if (precipitation == true)
            {
                weather = WeatherTypes.WeatherType();
            }

            return weather;
        }
    }

}
