using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormatUtility
{
    public class ExtractingValue
    {

        /// <summary>
        /// Extract a string value matching a regular expression
        /// </summary>
        /// <param name="inputValue">Source value</param>
        /// <param name="regex">Regular Expression</param>
        /// <param name="valueIfError">Value if error or no match</param>
        /// <returns>Extracted string</returns>
        public static string ExtractValueMatchRegex(string sourceValue, string regex, string returnValueIfError)
        {
            string returnValue = returnValueIfError;

            try
            {
                Regex pattern = new Regex(regex);
                Match match = pattern.Match(sourceValue);
                if (match.Success)
                    returnValue = match.Value;
                else
                    returnValue = returnValueIfError;
            }
            catch { }

            return returnValue;
        }

        /// <summary>
        /// Extract and format value from source string
        /// </summary>
        /// <param name="sourceValue">Source value</param>
        /// <param name="valuesToReplace">Value to replace</param>
        /// <param name="regexToExtract">Regex pattern to extract</param>
        /// <param name="trimValue">Trim value required?</param>
        /// <param name="valueType">Value type (date, numeric, text)</param>
        /// <param name="valueFormat">Value format (e.g. dd/MM/yyyy, #,0.00, ...)</param>
        /// <param name="returnValueIfError">If error value returned</param>
        /// <returns>String extracted from source value</returns>
        public static string ExtractFormatValue(string sourceValue, string regexToExtract, string valuesToReplace, int trimValue, string valueType, string valueFormat, string returnValueIfError)
        {
            string returnValue = sourceValue;

            try
            {

                //1 - Extract matching regex from new value
                if (regexToExtract != string.Empty)
                    returnValue = ExtractValueMatchRegex(returnValue, regexToExtract, returnValue);

                //2 - Replace values from source value
                if (valuesToReplace != string.Empty)
                    returnValue = StringFormatMethods.ReplaceValues(returnValue, valuesToReplace, returnValue);

                //3 - Trim value
                if (trimValue == 1)
                    returnValue = returnValue.Trim();

                //4 - Format value
                if (valueType != string.Empty)
                {
                    if (valueType.ToLower() == "numeric")
                        returnValue = NumericFormatMethods.GetFormattedNumber(returnValue, valueFormat, returnValue);
                    else if (valueType.ToLower() == "date")
                        returnValue = DateFormatMethods.GetFormattedDate(returnValue, valueFormat, returnValue);
                }
            }
            catch
            {
                returnValue = returnValueIfError;
            }

            return returnValue;
        }
    }
}
