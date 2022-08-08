using jxsUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static jxsUI.Helpers.WindowHelper;
using static jxsUI.Helpers.AppValues;
using Microsoft.UI.Xaml;

namespace jxsUI
{
    public class JxsUiMain
    {
        private MainWindow mainWindow;
        private ClientVM clientVm;
        private IntPtr wHandle;
        public IntPtr WindowPtr { set { wHandle = value; } }
        internal Window GetMainWindow()
        {
            clientVm = new ClientVM();
            mainWindow = new MainWindow();
            mainWindow.Closed += MainWindow_Closed;
            mainWindow.SetClientArea(clientVm);
   
            return mainWindow;
        }

        private void MainWindow_Closed(object sender, Microsoft.UI.Xaml.WindowEventArgs args)
        {
            SaveSplitterDistance(clientVm.ToolboxColumnDistance.Value, ToolBoxWidth);
            SaveSplitterDistance(clientVm.NotificationColumnDistance.Value, NotificationHeight);
            SaveWindowPositionSize(wHandle);

        }

        internal void SetupDistances()
        {
            double[] values = GridSpliterValues();
            clientVm.ToolboxColumnDistance = new Microsoft.UI.Xaml.GridLength(values[0]);
            clientVm.NotificationColumnDistance = new Microsoft.UI.Xaml.GridLength(values[1]);

        }


    }
}
