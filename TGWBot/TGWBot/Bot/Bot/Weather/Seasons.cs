using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherUtility
{
    public class Seasons
    {
        public static int Season()
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
    }
}
