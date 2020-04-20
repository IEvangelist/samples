using System;
using System.Windows.Controls;

namespace Raytracer.Wpf
{
    static class DispatcherExtensions
    {
        internal static void ThreadSafeInvoke(this Control control, Action action)
        {
            if (control is null || action is null)
            {
                return;
            }

            if (control.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                control.Dispatcher.BeginInvoke(action);
            }
        }
    }
}
