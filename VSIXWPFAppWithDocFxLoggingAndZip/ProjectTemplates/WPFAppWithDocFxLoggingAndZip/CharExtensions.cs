using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    /// <summary>Class CharExtensions</summary>
    public static class CharExtensions
    {
        /// <summary>Determines whether the specified c is letter.</summary>
        /// <param name="c">The c.</param>
        public static bool IsLetter(this char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
        /// <summary>Determines whether [is letter or separator] [the specified c].</summary>
        /// <param name="c">The c.</param>
        public static bool IsLetterOrSeparator(this char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
    }
}
