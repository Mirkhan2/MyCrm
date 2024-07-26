using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Application.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsiDate(this DateTime time)
        {
             var persianCalender = new PersianCalendar();
            return persianCalender.GetYear(time) + "/" +
                persianCalender.GetMonth(time).ToString("") + "/" +
                persianCalender.GetDayOfMonth(time).ToString("00");
        }
    }
}
