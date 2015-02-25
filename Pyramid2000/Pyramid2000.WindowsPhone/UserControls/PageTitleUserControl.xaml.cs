using Pyramid2000.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pyramid2000.UserControls
{
    public sealed partial class PageTitleUserControl : UserControl, INotifyPropertyChanged
    {

        private NavigationHelper _navigationHelper;
        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this._navigationHelper; }
            set
            {
                if (this._navigationHelper != value)
                {
                    _navigationHelper = value;
                    RaisePropertyChanged("NavigationHelper");
                }


            }
        }

        private string _appName;
        public string AppName
        {
            get
            {
                return _appName;
            }
            set
            {
                if (_appName != value)
                {
                    _appName = value;
                    RaisePropertyChanged("AppName");
                }

            }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                if (_pageTitle != value)
                {
                    _pageTitle = value;
                    RaisePropertyChanged("PageTitle");
                }
            }
        }

        public PageTitleUserControl(NavigationHelper navigationHelper)
        {
            this.InitializeComponent();
            this.NavigationHelper = navigationHelper;
            this.DataContext = this;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GoBack();
        }
    }
}
