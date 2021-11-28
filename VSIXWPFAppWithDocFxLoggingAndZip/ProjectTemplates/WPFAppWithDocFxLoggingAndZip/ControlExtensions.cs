using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace $safeprojectname$
{
    /// <summary>Class ControlExtensions</summary>
    public static class ControlExtensions
    {
        /// <summary>Performs the click.</summary>
        /// <param name="btn">The BTN.</param>
        public static void PerformClick(this Button btn) => btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
    }
}
