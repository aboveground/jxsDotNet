using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using static jxsUI.Helpers.AppValues;
using static jxsUI.Helpers.WindowHelper;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.


namespace jxsUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private JxsUiMain main;

     
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            SetUpColorTheme();
            main= new JxsUiMain();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
             mainWindow = main.GetMainWindow();
            //  IWindowNative nativeWindow = window.As<IWindowNative>();
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mainWindow);
            main.WindowPtr = hwnd;
            SetWindowPositionSize(hwnd);
            main.SetupDistances();
            mainWindow.Activate();
        }

        private Window mainWindow;

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
        internal interface IWindowNative
        {
            IntPtr WindowHandle { get; }
        }

    }
}
