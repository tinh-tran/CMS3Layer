using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Common
{
    public class DateTimeClass
    {
        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="DateTime">string Datetime to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(string DateTime, string DateFormat)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = Convert.ToDateTime(DateTime);
            }
            catch { }
            return dt.ToString(DateFormat);
        }

        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="DateTime">Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(DateTime DateTime)
        {
            return ConvertDateTime(DateTime, "dd/MM/yyyy HH:mm:ss tt");
        }
        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="DateTime">Datetime to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(DateTime DateTime, string DateFormat)
        {
            return DateTime.ToString(DateFormat);
        }
    }
}