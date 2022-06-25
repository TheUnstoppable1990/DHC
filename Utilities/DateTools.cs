using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHC.Utilities
{
    internal static class DateTools
    {
        //public static bool WeekOf()
        public static bool DayOf(DateTime holiday)
        {
            //this will return true if it is true anywhere in the world
            //Holday dates are returned as Midnight(start of day) in UTC time
            //Therefore we need to calculate the range as -12 hours to + 36 hours to get all time zones
            double oaTimeUTC = DateTime.UtcNow.ToOADate(); //current time UTC
            double min = holiday.AddHours(-12).ToOADate();
            double max = holiday.AddHours(36).ToOADate();
            if(oaTimeUTC > min && oaTimeUTC < max)
            {
                return true;
            }            
            return false;
        }
        public static bool DayOf(DateTime[] holidays)//for multi-day holidays
        {
            for (var i = 0; i < holidays.Length; i++)
            {
                if (DayOf(holidays[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool WeekOf(DateTime holiday)
        {
            //this will return true if it is true anywhere in the world
            //Holday dates are returned as Midnight(start of day) in UTC time
            //Therefore we need to calculate the range as -12 hours to + 36 hours to get all time zones
            double oaTimeUTC = DateTime.UtcNow.ToOADate(); //current time UTC
            double min = holiday.AddDays(-6).AddHours(-12).ToOADate();
            double max = holiday.AddDays(6).AddHours(36).ToOADate();
            if (oaTimeUTC > min && oaTimeUTC < max)
            {
                return true;
            }
            return false;
        }
        public static bool WeekOf(DateTime[] holidays)//for multi-day holidays
        {
            for (var i = 0; i < holidays.Length; i++)
            {
                if (WeekOf(holidays[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static void DateTest(DateTime testDate)
        {
            if (DayOf(testDate))
            {
                UnityEngine.Debug.Log($"It\'s {testDate.Month}/{testDate.Day} somewhere");
            }
            else if (WeekOf(testDate))
            {
                UnityEngine.Debug.Log($"It\'s the week of {testDate.Month}/{testDate.Day} somewhere");
            }
            else
            {
                UnityEngine.Debug.Log($"It\'s not {testDate.Month}/{testDate.Day} anywhere");
            }
        }
    }
}
