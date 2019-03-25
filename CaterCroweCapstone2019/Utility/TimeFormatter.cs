using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Utility
{
    public class TimeFormatter
    {
        public static string FormatTimeFromDB(string time)
        {
            var timeSplit = time.Split(':');

            var period = "AM";
            if (Convert.ToInt32(timeSplit[0]) == 12)
            {
                period = "PM";
            } 
            else if(Convert.ToInt32(timeSplit[0]) > 12)
            {
                period = "PM";
                timeSplit[0] = Convert.ToString(Convert.ToInt32(timeSplit[0]) - 12);
            }

            return timeSplit[0] + ":" + timeSplit[1] + " " + period;
        }
    }
}