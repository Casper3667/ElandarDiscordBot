using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherUtility
{
    public class WeatherTypes
    {
        public static string WeatherType()
        {
            string[] weathertype = new string[6] { "light fog", "heavy fog", "drizzle", "rain", "heavy rain", "thunderstorm" };

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
    }
}
