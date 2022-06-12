using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherUtility
{
    public class Temperature
    {
        public static int Temp(int season)
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
    }
}
