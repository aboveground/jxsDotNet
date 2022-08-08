using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;

namespace jxsUI.ViewModels
{
    public class ClientVM : ObservableObject
    {

        private GridLength toolboxColumnDistance;
        public GridLength ToolboxColumnDistance
        {
            get { return toolboxColumnDistance; }
            set { SetProperty(ref toolboxColumnDistance, value); }
        }

        private GridLength notificationColumnDistance;
        public GridLength NotificationColumnDistance
        {
            get { return notificationColumnDistance; }
            set { SetProperty(ref notificationColumnDistance, value); }
        }


    }
}
