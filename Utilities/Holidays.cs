using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHC.Utilities
{
    internal static class Holidays
    {       

        public static DateTime GetGroundhog()
        {
            return new DateTime(DateTime.UtcNow.Year, 2, 2);
        }
        public static DateTime GetValentine()
        {
            return new DateTime(DateTime.UtcNow.Year, 2, 14);
        }
        public static DateTime GetStPatrick()
        {
            return new DateTime(DateTime.UtcNow.Year, 3, 17);
        }
        public static DateTime[] GetKwanzaa()
        {
            var year = DateTime.UtcNow.Year;
            return new DateTime[]
            {
                new DateTime(year,1,1), //returns the 1st of the year which is the last day of kwanzaa, should work this way
                new DateTime(year,12,26),
                new DateTime(year,12,27),
                new DateTime(year,12,28),
                new DateTime(year,12,29),
                new DateTime(year,12,30),
                new DateTime(year,12,31)
            };
        }
        public static DateTime[] GetHanukkah()
        {
            var output = new DateTime[]
            {
                //2022
                new DateTime(2022,12,18), new DateTime(2022,12,19), new DateTime(2022,12,20), 
                new DateTime(2022,12,21), new DateTime(2022,12,22), new DateTime(2022,12,23), 
                new DateTime(2022,12,24), new DateTime(2022,12,25), new DateTime(2022,12,26),
                //2023
                new DateTime(2023,12,7), new DateTime(2023,12,8), new DateTime(2023,12,9),
                new DateTime(2023,12,10), new DateTime(2023,12,11), new DateTime(2023,12,12),
                new DateTime(2023,12,13), new DateTime(2023,12,14), new DateTime(2023,12,15)
            };
           return output;
        }        public static DateTime GetChristmas()
        {
            return new DateTime(DateTime.UtcNow.Year, 12, 25); //should be at midnight start of day
        }
    }
}
