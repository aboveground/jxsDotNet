using jxsUI.UIControls;
using jxsUI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static jxsUI.Helpers.AppValues;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace jxsUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private Thickness borderThickness;
        public Thickness xBorderThickness { get { return borderThickness; } set { borderThickness = value; } }

        private SolidColorBrush borderBrush;
        public SolidColorBrush xBorderBrush { get { return borderBrush; } set { borderBrush = value; } }



        public MainWindow()
        {
            this.InitializeComponent();
            SetWindowStatus(WindowStatus.normal);
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
            var content = (Content as FrameworkElement)!;
            content.RequestedTheme = ElementTheme.Light;

        }

        public void SetWindowStatus(WindowStatus status)
        {
            switch (status)
            {
                case WindowStatus.normal:
                    xBorderThickness = NormalThick;
                    xBorderBrush = Blue;
                    break;
                case WindowStatus.warning:
                    xBorderThickness = WarningThick;
                    xBorderBrush = Yellow;
                    break;
                case WindowStatus.error:
                    xBorderThickness = ErrorThick;
                    xBorderBrush = Red;
                    break;

            }

        }
        public void SetClientArea(ClientVM vm)
        {
            ClientArea.DataContext = vm;
        }

    }
}
