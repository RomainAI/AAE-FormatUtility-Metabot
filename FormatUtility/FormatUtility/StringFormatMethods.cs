using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatUtility
{
    public class StringFormatMethods
    {

        /// <summary>
        /// Replace values in source value
        /// </summary>
        /// <param name="sourceValue">Original value</param>
        /// <param name="valuesToReplace">use "," to separate old and new value and ";" to separate replace occurence (e.g old1","new1";"old2","new2)</param>
        /// <param name="returnValueIfError">Value return if there is an error</param>
        /// <returns>String</returns>
        public static string ReplaceValues(string sourceValue, string valuesToReplace, string returnValueIfError)
        {

            string returnValue = sourceValue;
            List<string> listReplaceValues = new List<string>();
            string valueToReplaceOld = string.Empty;
            string valueToReplaceNew = string.Empty;

            try
            {
                listReplaceValues = valuesToReplace.Split(new[] { "\";\"" }, StringSplitOptions.None).ToList();
                foreach (string replaceValue in listReplaceValues)
                {
                    valueToReplaceOld = replaceValue.Split(new[] { "\",\"" }, StringSplitOptions.None)[0];
                    valueToReplaceNew = replaceValue.Split(new[] { "\",\"" }, StringSplitOptions.None)[1];

                    returnValue = returnValue.Replace(valueToReplaceOld, valueToReplaceNew);
                }
            }
            catch
            { returnValue = returnValueIfError; }

            return returnValue;

        }

        /// <summary>
        /// Remove from a string value
        /// </summary>
        /// <param name="sourceValue">Original value</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="returnValueIfError">Value return if there is an error</param>
        /// <returns>String</returns>
        public static string RemoveString(string sourceValue, int startIndex, string returnValueIfError)
        {

            string returnValue = sourceValue;

            try
            {
                    returnValue = returnValue.Remove(startIndex);
            }
            catch
            { returnValue = returnValueIfError; }

            return returnValue;

        }

        /// <summary>
        /// Remove from a string value
        /// </summary>
        /// <param name="sourceValue">Original value</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="count">Number of char to remove</param>
        /// <param name="returnValueIfError">Value return if there is an error</param>
        /// <returns>String</returns>
        public static string RemoveString(string sourceValue, int startIndex, int count, string returnValueIfError)
        {

            string returnValue = sourceValue;

            try
            {
                returnValue = returnValue.Remove(startIndex, count);
            }
            catch
            { returnValue = returnValueIfError; }

            return returnValue;

        }

    }
}
