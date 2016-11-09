using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.Helpers
{
    public class DateTimeConverter
    {
        public static DateTime FromEpochTime(string unixTime)
        {
            char[] delimiters = new char[] { '-', '+' };
            var timeZone = unixTime.Split(delimiters)[1];
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0);
            epoch.AddMilliseconds(int.Parse(unixTime.Split(delimiters)[0]));
            long differenceHours = 10 * timeZone[0] + timeZone[1];
            long differenceMinutes = 10 * timeZone[2] + timeZone[3];
            differenceHours = differenceHours * 3600000;
            differenceMinutes = differenceMinutes * 60000;
            epoch.AddMilliseconds(differenceHours);
            epoch.AddMilliseconds(differenceMinutes);
            return epoch;
        }
    }
}