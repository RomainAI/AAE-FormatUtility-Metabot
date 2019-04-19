using System;
using System.Text.RegularExpressions;

namespace FormatUtility
{
    public class DateFormatMethods
    {

        /// <summary>
        /// Get a date value with a specific format
        /// </summary>
        /// <param name="sourceValue">Source value (e.g. extracted from a document OCR)</param>
        /// <param name="targetFormat">Format requested (e.g. dd/MM/yyyy)</param>
        /// <param name="returnValueIfError">If not able to convert value</param>
        /// <returns>Formatted target value or input value if error</returns>
        public static string GetFormattedDate(string sourceValue, string targetFormat, string returnValueIfError)
        {
            string returnValue = returnValueIfError;
            string dateValue = string.Empty;
            bool isError = false;

            try
            {
                if (targetFormat != "")
                    returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDateTime(sourceValue));
                else
                    returnValue = Convert.ToDateTime(sourceValue).ToString();
            }
            catch
            { isError = true; }

            if (isError)
            {
                isError = false;
                dateValue = GetDateStringValue(sourceValue, 0, sourceValue);
                try
                {
                    if (targetFormat != "")
                        returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDateTime(dateValue));
                    else
                        returnValue = Convert.ToDateTime(dateValue).ToString();
                }
                catch
                { isError = true; }

                if (isError)
                {
                    dateValue = GetDateStringValue(sourceValue, 1, sourceValue);
                    try
                    {
                        if (targetFormat != "")
                            returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDateTime(dateValue));
                        else
                            returnValue = Convert.ToDateTime(dateValue).ToString();
                    }
                    catch
                    { }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Get a date value with a specific format
        /// </summary>
        /// <param name="sourceValue">Source value (e.g. extracted from a document OCR)</param>
        /// <param name="targetFormat">Format requested (e.g. dd/MM/yyyy)</param>
        /// <param name="returnValueIfError">If not able to convert value</param>
        /// <returns>Formatted target value or input value if error</returns>
        public static string GetFormattedDate(string sourceValue, string targetFormat, string returnValueIfError, int addDayNumber, int addMonthNumber, int addYearNumber, int addHourNumber, int addMinuteNumber, int addSecondNumber)
        {
            string returnValue = returnValueIfError;
            string dateValue = string.Empty;
            bool isError = false;

            try
            {
                if (targetFormat != "")
                    returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDateTime(sourceValue).AddDays(addDayNumber).AddMonths(addMonthNumber).AddYears(addYearNumber).AddHours(addHourNumber).AddMinutes(addMinuteNumber).AddSeconds(addSecondNumber));
                else
                    returnValue = Convert.ToDateTime(sourceValue).ToString();
            }
            catch
            { isError = true; }

            if (isError)
            {
                isError = false;
                dateValue = GetDateStringValue(sourceValue, 0, sourceValue);
                try
                {
                    if (targetFormat != "")
                        returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDateTime(dateValue).AddDays(addDayNumber).AddMonths(addMonthNumber).AddYears(addYearNumber).AddHours(addHourNumber).AddMinutes(addMinuteNumber).AddSeconds(addSecondNumber));
                    else
                        returnValue = Convert.ToDateTime(dateValue).ToString();
                }
                catch
                { isError = true; }

                if (isError)
                {
                    dateValue = GetDateStringValue(sourceValue, 1, sourceValue);
                    try
                    {
                        if (targetFormat != "")
                            returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDateTime(dateValue).AddDays(addDayNumber).AddMonths(addMonthNumber).AddYears(addYearNumber).AddHours(addHourNumber).AddMinutes(addMinuteNumber).AddSeconds(addSecondNumber));
                        else
                            returnValue = Convert.ToDateTime(dateValue).ToString();
                    }
                    catch
                    { }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Get a date value with a specific format with the last day of month as day value
        /// </summary>
        /// <param name="sourceValue">Source value (e.g. extracted from a document OCR)</param>
        /// <param name="targetFormat">Format requested (e.g. dd/MM/yyyy)</param>
        /// <param name="returnValueIfError">If not able to convert value</param>
        /// <returns>Formatted target value or input value if error</returns>
        public static string GetFormattedDateLastDayOfMonth(string sourceValue, string targetFormat, string returnValueIfError)
        {
            string returnValue = returnValueIfError;
            DateTime sourceDate = DateTime.MinValue;
            string dateValue = string.Empty;
            bool isError = false;

            try
            {
                if (targetFormat != "")
                {
                    sourceDate = Convert.ToDateTime(sourceValue);
                    DateTime endOfMonth = new DateTime(sourceDate.Year, sourceDate.Month, DateTime.DaysInMonth(sourceDate.Year, sourceDate.Month));
                    returnValue = String.Format("{0:" + targetFormat + "}", endOfMonth);
                }
                else
                    returnValue = Convert.ToDateTime(sourceValue).ToString();
            }
            catch
            { isError = true; }

            if (isError)
            {
                isError = false;
                dateValue = GetDateStringValue(sourceValue, 0, sourceValue);
                try
                {
                    if (targetFormat != "")
                    {
                        sourceDate = Convert.ToDateTime(dateValue);
                        DateTime endOfMonth = new DateTime(sourceDate.Year, sourceDate.Month, DateTime.DaysInMonth(sourceDate.Year, sourceDate.Month));
                        returnValue = String.Format("{0:" + targetFormat + "}", endOfMonth);
                    }
                    else
                        returnValue = Convert.ToDateTime(dateValue).ToString();
                }
                catch
                { isError = true; }

                if (isError)
                {
                    dateValue = GetDateStringValue(sourceValue, 1, sourceValue);
                    try
                    {
                        if (targetFormat != "")
                        {
                            sourceDate = Convert.ToDateTime(dateValue);
                            DateTime endOfMonth = new DateTime(sourceDate.Year, sourceDate.Month, DateTime.DaysInMonth(sourceDate.Year, sourceDate.Month));
                            returnValue = String.Format("{0:" + targetFormat + "}", endOfMonth);
                        }
                        else
                            returnValue = Convert.ToDateTime(dateValue).ToString();
                    }
                    catch
                    { }
                }
            }

            return returnValue;
        }
        
        /// <summary>
        /// Get string value formatted
        /// </summary>
        /// <param name="originalValue">Original value to format</param>
        /// <param name="switchDayMonth">0=day/month/year, 1=month/day/year</param>
        /// <param name="returnValueIfError">if error value to return</param>
        /// <returns>Formatted date value</returns>
        private static string GetDateStringValue(string originalValue, int switchDayMonth, string returnValueIfError)
        {
            string day = "";
            string month = "";
            string year = "";

            string returnValue = returnValueIfError;

            try
            {
                if (!originalValue.Contains("/"))
                {
                    if (originalValue.Length >= 8)
                        originalValue = string.Format("{0}/{1}/{2}", originalValue.Substring(0, 2), originalValue.Substring(2, 2), originalValue.Substring(4, originalValue.Length - 4));
                    else if (originalValue.Length >= 6)
                        originalValue = string.Format("{0}/{1}", originalValue.Substring(0, 2), originalValue.Substring(2, originalValue.Length - 2));
                }
            }
            catch { }

            string[] dateS = originalValue.Split('/');

            try
            {
                if (dateS.Length == 3)
                {
                    day = dateS[0].Trim();
                    month = dateS[1].Trim();
                    year = dateS[2].Trim();
                }
                else if (dateS.Length == 2)
                {
                    month = dateS[0].Trim();
                    year = dateS[1].Trim();
                }
                if (month.Length == 1)
                {
                    month = "0" + month;
                }

                if (day == "")
                    day = "01";

                if (switchDayMonth == 0)
                    returnValue = string.Format("{0}/{1}/{2}", day, month, year);
                else
                    returnValue = string.Format("{0}/{1}/{2}", month, day, year);
            }
            catch
            {

            }

            return returnValue;
        }

    }
}
