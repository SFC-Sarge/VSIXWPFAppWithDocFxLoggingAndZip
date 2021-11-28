using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace $safeprojectname$
{
    /// <summary>Class DependencyObjectExtensions</summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>Finds the child control.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control">The control.</param>
        /// <returns>System.Windows.DependencyObject.</returns>
        public static DependencyObject FindChildControl<T>(DependencyObject control)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                if (child is not null && child is T)
                    return child;
                else
                    FindChildControl<T>(child);
            }
            return null;

        }
        /// <summary>Finds the parent control.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control">The control.</param>
        /// <returns>System.Windows.DependencyObject.</returns>
        public static DependencyObject FindParentControl<T>(DependencyObject control)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(control);
            while (parent is not null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent;
        }
        /// <summary>Finds the child.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="childName">Name of the child.</param>
        /// <returns>T.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent is null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child as T is null)
                {
                    foundChild = FindChild<T>(child, childName);

                    if (foundChild is not null) break;
                }
                else if (childName is not null)
                {
                    if (child as FrameworkElement is not null && (child as FrameworkElement).Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
    }
}
