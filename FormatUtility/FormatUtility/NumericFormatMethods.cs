using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatUtility
{
    public class NumericFormatMethods
    {

        /// <summary>
        /// Get a formatted number value either decimal or integer
        /// </summary>
        /// <param name="sourceValue">Source value (e.g. extracted from a document OCR)</param>
        /// <param name="isDecimal">Convert the source value to a decimal?</param>
        /// <param name="targetFormat">Target format (e.g. "C2")</param>
        /// <param name="returnValueIfError">If not able to convert value</param>
        /// <returns>Formatted target value or input value if error</returns>
        public static string GetFormattedNumber(string sourceValue, string targetFormat, string returnValueIfError)
        {
            string returnValue = returnValueIfError;
            bool isError = false;

            try
            {
                if (targetFormat != "")
                    returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDecimal(sourceValue));
                else
                    returnValue = Convert.ToDecimal(sourceValue).ToString();
            }
            catch
            { isError = true; }

            if (isError)
            {
                try
                {
                    returnValue = GetNumericValue(sourceValue);
                    if (targetFormat != "")
                        returnValue = String.Format("{0:" + targetFormat + "}", Convert.ToDecimal(returnValue));
                    else
                        returnValue = Convert.ToDecimal(returnValue).ToString();
                }
                catch { returnValue = returnValueIfError; }
            }

            return returnValue;
        }

        private static string GetNumericValue(string sourceValue)
        {
            string returnValue = sourceValue;
            int numberOfDotsToReplace = 0;
            int replaceCount = 0;
            int indexChar = 0;

            try
            {
                returnValue = returnValue.Replace(",", ".");
                numberOfDotsToReplace = returnValue.Count(x => x == '.') - 1;

                if (numberOfDotsToReplace > 0)
                {
                    foreach (char letter in returnValue)
                    {
                        if (letter == '.' && numberOfDotsToReplace > replaceCount)
                        {
                            returnValue = returnValue.Remove(indexChar, 1);
                            indexChar--;
                            replaceCount++;
                        }
                        indexChar++;
                    }
                }
            }
            catch
            {

            }

            return returnValue;
        }

    }
}
