using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    /// <summary>Class StringExtensions</summary>
    public static class StringExtensions
    {
        /// <summary>Replaces the specified old value1.</summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="oldValue1">The old value1.</param>
        /// <param name="newValue1">The new value1.</param>
        /// <param name="stringComparison">The string comparison.</param>
        /// <param name="oldValue2">The old value2.</param>
        /// <param name="newValue2">The new value2.</param>
        /// <param name="oldValue3">The old value3.</param>
        /// <param name="newValue3">The new value3.</param>
        /// <param name="oldValue4">The old value4.</param>
        /// <param name="newValue4">The new value4.</param>
        /// <param name="oldValue5">The old value5.</param>
        /// <param name="newValue5">The new value5.</param>
        /// <returns>System.String.</returns>
        public static string Replace(this string fileContents, string oldValue1, string newValue1, StringComparison stringComparison, string oldValue2 = "", string newValue2 = "", string oldValue3 = "", string newValue3 = "", string oldValue4 = "", string newValue4 = "", string oldValue5 = "", string newValue5 = "")
        {
            fileContents = fileContents.Replace(oldValue: oldValue1,
                   newValue: newValue1,
                   comparisonType: stringComparison).Replace(oldValue: oldValue2,
                   newValue: newValue2,
                   comparisonType: stringComparison).Replace(oldValue: oldValue3,
                   newValue: newValue3,
                   comparisonType: stringComparison).Replace(oldValue: oldValue4,
                   newValue: newValue4,
                   comparisonType: stringComparison).Replace(oldValue: oldValue5,
                   newValue: newValue5,
                   comparisonType: stringComparison);
            return fileContents;
        }
        /// <summary>Replaces the specified old value1.</summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="oldValue1">The old value1.</param>
        /// <param name="newValue1">The new value1.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="culture">The culture.</param>
        /// <param name="oldValue2">The old value2.</param>
        /// <param name="newValue2">The new value2.</param>
        /// <param name="oldValue3">The old value3.</param>
        /// <param name="newValue3">The new value3.</param>
        /// <param name="oldValue4">The old value4.</param>
        /// <param name="newValue4">The new value4.</param>
        /// <param name="oldValue5">The old value5.</param>
        /// <param name="newValue5">The new value5.</param>
        /// <returns>System.String.</returns>
        public static string Replace(this string fileContents, string oldValue1, string newValue1, bool ignoreCase, CultureInfo culture, string oldValue2 = "", string newValue2 = "", string oldValue3 = "", string newValue3 = "", string oldValue4 = "", string newValue4 = "", string oldValue5 = "", string newValue5 = "")
        {
            fileContents = fileContents.Replace(oldValue: oldValue1,
                   newValue: newValue1,
                   ignoreCase: ignoreCase,
                   culture: culture).Replace(oldValue: oldValue2,
                   newValue: newValue2,
                   ignoreCase: ignoreCase,
                   culture: culture).Replace(oldValue: oldValue3,
                   newValue: newValue3,
                   ignoreCase: ignoreCase,
                   culture: culture).Replace(oldValue: oldValue4,
                   newValue: newValue4,
                   ignoreCase: ignoreCase,
                   culture: culture).Replace(oldValue: oldValue5,
                   newValue: newValue5,
                   ignoreCase: ignoreCase,
                   culture: culture);
            return fileContents;
        }
        /// <summary>Determines whether [is null or empty] [the specified s].</summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if [is null or empty] [the specified s]; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty(this string s) => s is null || s.Trim().Length == 0;

    }
}
