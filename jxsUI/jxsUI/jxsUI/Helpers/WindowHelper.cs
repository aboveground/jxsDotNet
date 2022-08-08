using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using static PInvoke.User32;
using PInvoke;
using static jxsUI.Helpers.AppValues;
using Microsoft.UI.Xaml;

namespace jxsUI.Helpers
{
    public static class WindowHelper
    {

        public static void SaveWindowPositionSize(IntPtr wHandle)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            WINDOWINFO wi = new WINDOWINFO();
            GetWindowInfo(wHandle, ref wi);
            RECT rect = new RECT();
            GetWindowRect(wHandle, out rect);
            POINT pt = new POINT();
            ClientToScreen(wHandle, ref pt);
            localSettings.Values[Left] = rect.left;
            localSettings.Values[Top] = rect.top;
            localSettings.Values[Width] = rect.right - rect.left;
            localSettings.Values[Height] = rect.bottom - rect.top;

        }


        private static int WindowWidth;
        private static int WindowHeight;
        public static void SetWindowPositionSize(IntPtr wHandle)
        {
            ApplicationDataContainer ls = ApplicationData.Current.LocalSettings;
            var dpi = GetDpiForWindow(wHandle);
            float scale = 1f;// (float)dpi / 96;
            int left = (int)(scale * (ls.Values.TryGetValue(Left, out object x) ? (int)x : DefaultLeft));
            int top = (int)(scale * (ls.Values.TryGetValue(Top, out object y) ? (int)y : DefaultTop));
            int width = (int)(scale * (ls.Values.TryGetValue(Width, out object cx) ? (int)cx : DefaultWidth));
            WindowWidth = width < MinWidowWidth ? MinWidowWidth : width;
            int height = (int)(scale * (ls.Values.TryGetValue(Height, out object cy) ? (int)cy : DefaultHeight));
            WindowHeight = height < MinWindowHeight ? MinWindowHeight : height;
            SetWindowPos(wHandle, SpecialWindowHandles.HWND_TOP, left, top, WindowWidth, WindowHeight, SetWindowPosFlags.SWP_SHOWWINDOW);
            ShowWindow(wHandle, WindowShowStyle.SW_SHOWNORMAL);
        }

        public static void SetUpColorTheme()
        {
            ApplicationDataContainer ls = ApplicationData.Current.LocalSettings;
            object value = ls.Values[CurrentLastTheme];
            ApplicationTheme theme = ApplicationTheme.Dark;
            if (value == null)
            {
                ls.Values[CurrentLastTheme] = theme == ApplicationTheme.Dark ? DarkTheme : LightTheme;
            }
            else
            {
                App.Current.RequestedTheme = theme;
            }

        }
        public static double[] GridSpliterValues()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

            double toolboxWidth = DefaultMinToolBoxWidth;
            if (settings.Values.TryGetValue(ToolBoxWidth, out object width))
            {
                toolboxWidth = (double)width;
            }
            toolboxWidth = toolboxWidth > WindowWidth - SplitBuffer ? WindowWidth - ToolBoxMin : toolboxWidth;
            double notificationHeight = DefaultMinNotificationHeight;
            if (settings.Values.TryGetValue(NotificationHeight, out object height))
            {
                notificationHeight = (double)height;
            }
            notificationHeight=notificationHeight>WindowHeight -SplitBuffer ?WindowHeight-NotificationMin : notificationHeight;
            return new[] {toolboxWidth, notificationHeight}; 
        }

        public static void SaveSplitterDistance(double value, string column)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values[column] = value;
        }
    }
}
