using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    /// <summary>Class StringBuilderExtensions</summary>
    public static class StringBuilderExtensions
    {
        /// <summary>Appends the unique on new line if not empty.</summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="text">The text.</param>
        public static void AppendUniqueOnNewLineIfNotEmpty(this StringBuilder stringBuilder, string text)
        {
            if (text.Trim().Length > 0 && !stringBuilder.ToString().Contains(text)) stringBuilder.AppendFormat("{0}{1}", stringBuilder.ToString().Trim().Length == 0 ? string.Empty : Environment.NewLine, text);
        }
    }
}
