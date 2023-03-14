﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Remoting.Messaging;

namespace Accounting.Utility.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime Value)
        {

            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(Value) + "/" + pc.GetMonth(Value).ToString("00") + "/" + pc.GetDayOfMonth(Value).ToString("00");
        }

        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new System.Globalization.PersianCalendar());
        }
       


    }
}
