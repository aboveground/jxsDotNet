using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace jsx
{
    public class Class1
    {
          public class DisplayInfo
        {
            public string Availability { get; set; }
            public string ScreenHeight { get; set; }
            public string ScreenWidth { get; set; }

            private Rect monitorArea;
            public Rect MonitorArea { get { return monitorArea; } }

            private Rect workArea;
            public Rect WorkArea { get { return workArea; } }

            public void SetMonitorArea(PInvoke.RECT r)
            {

                monitorArea.left = r.left;
                monitorArea.right = r.right;
                monitorArea.top = r.top;
                monitorArea.bottom = r.bottom;

            }

            public void SetWorkArea(PInvoke.RECT r)
            {

                workArea.left = r.left;
                workArea.right = r.right;
                workArea.top = r.top;
                workArea.bottom = r.bottom;

            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        /// <summary>
        /// Collection of display information
        /// </summary>
        public class DisplayInfoCollection : List<DisplayInfo>
        {
        }

        delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);
        [DllImport("user32.dll")]
        static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);

        /// <summary>
        /// Returns the number of Displays using the Win32 functions
        /// </summary>
        /// <returns>collection of Display Info</returns>
        public static bool TryGetDisplays(out DisplayInfoCollection colx)
        {
            colx = new DisplayInfoCollection();
            DisplayInfoCollection col = new DisplayInfoCollection();
            try
            {
                EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
                    {
                        MONITORINFO mi = new MONITORINFO();
                        mi.cbSize = (int)Marshal.SizeOf(mi);
                        bool success = GetMonitorInfo(hMonitor, ref mi);
                        if (success)
                        {
                            DisplayInfo di = new DisplayInfo();
                            di.ScreenWidth = (mi.rcMonitor.right - mi.rcMonitor.left).ToString();
                            di.ScreenHeight = (mi.rcMonitor.bottom - mi.rcMonitor.top).ToString();
                            di.SetMonitorArea(mi.rcMonitor);
                            di.SetWorkArea(mi.rcWork);
                        di.Availability = mi.dwFlags.ToString();
                            col.Add(di);
                        }
                        return true;
                    }, IntPtr.Zero);

            }
            catch (Exception e)
            {
                ex = e;
            }
            colx = col;
            return col != null && col.Count > 0;
        }
    }
}
