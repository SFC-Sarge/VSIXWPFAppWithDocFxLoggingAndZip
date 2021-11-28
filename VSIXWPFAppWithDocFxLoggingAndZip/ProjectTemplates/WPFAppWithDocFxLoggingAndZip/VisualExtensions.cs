using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace $safeprojectname$
{
    /// <summary>Class VisualExtensions</summary>
    public static class VisualExtensions
    {
        /// <summary>Finds the visual parent.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The element.</param>
        /// <returns>T.</returns>
        public static T FindVisualParent<T>(Visual element) where T : Visual
        {
            Visual parent = element;
            while (parent is not null)
            {
                if (parent as T is not null)
                {
                    return parent as T;
                }

                parent = VisualTreeHelper.GetParent(parent) as Visual;
            }
            return null;
        }
    }
}
