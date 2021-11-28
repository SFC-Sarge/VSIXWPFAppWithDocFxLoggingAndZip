using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    /// <summary>Class EnumExtensions</summary>
    public static class EnumExtensions
    {
        /// <summary>Gets the description.</summary>
        /// <param name="value">The value.</param>
        /// <returns>string.</returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo is null) return Enum.GetName(value.GetType(), value);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes is not null && attributes.Length > 0) return attributes[0].Description;
            return Enum.GetName(value.GetType(), value);
        }
    }
}
