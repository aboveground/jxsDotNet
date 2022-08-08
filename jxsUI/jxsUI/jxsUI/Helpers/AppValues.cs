using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jxsUI.Helpers
{
    public static class AppValues
    {
        public static readonly string dark = "Dark";
        public static readonly string light = "Light";
        public static readonly string ThemToUse = "ThemeToUsee";

        public static readonly string Left="Left";
        public static readonly string Top = "Top";
        public static readonly string Width = "Width";
        public static readonly string Height = "Height";
        public static readonly string CurrentLastTheme = "ThemeToUSe";
        public static readonly string DarkTheme = "Dark";
        public static readonly string LightTheme = "Light";

        public static readonly string MonitorCount = "MonitorCount";
        public static readonly string ToolBoxWidth="ToolboxWidth";
        public static readonly string NotificationHeight = "NotificationHeight";


        public static int DefaultTop = 10;
        public static int DefaultLeft = 10;
        public static int DefaultWidth= 1000;
        public static int DefaultHeight = 600;
        public static int DefaultMinToolBoxWidth = 75;
        public static int DefaultMinNotificationHeight = 75;
        public static int ToolBoxMin = 30;
        public static int NotificationMin = 30;
        public static int SplitBuffer = 18;
        public static int MinWidowWidth = 100;
        public static int MinWindowHeight = 75;

        public static SolidColorBrush Red = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
        public static SolidColorBrush Yellow = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 0));
        public static SolidColorBrush Blue = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));

        public static Thickness ErrorThick = new Thickness(4);
        public static Thickness WarningThick = new Thickness(3);
        public static Thickness NormalThick = new Thickness(1.5);
        public enum WindowStatus { normal, warning, error }
    }
}
