using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrüneBank
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime currentDateTime)
        {
            if(currentDateTime.DayOfWeek >= DayOfWeek.Monday &&
                currentDateTime.DayOfWeek <= DayOfWeek.Friday)
            {
                if (currentDateTime.TimeOfDay < new TimeSpan(10, 30, 00) || currentDateTime.TimeOfDay >= new TimeSpan(19, 00, 00))
                    return false;
            }
            else if (currentDateTime.DayOfWeek== DayOfWeek.Saturday)
            {
                if (currentDateTime.TimeOfDay < new TimeSpan(10, 30, 00) || currentDateTime.TimeOfDay >= new TimeSpan(14, 00, 00))
                    return false;
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool IsNowOpen()
        {
            return IsOpen(DateTime.Now); // Testen mit aktueller Uhrzeit
        }


    }
}
