using System;
using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pyramid2000.UWP.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;

        public Shell()
        {
            Instance = this;
            InitializeComponent();

            #region Temporary Fix for Template10 dark/light theme settings not working properly. Should be fixed in Template10 1.1.9
            Services.SettingsServices.SettingsService _settings = Services.SettingsServices.SettingsService.Instance;
            HamburgerMenu.RefreshStyles(_settings.AppTheme);
            #endregion
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        private async void RateAndReviewTapped(object sender, RoutedEventArgs e)
#pragma warning restore S3168 // "async" methods should not return "void"
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=33ddb4b9-5fc5-4a4d-bec3-5adc282c6b3a"));
        }
    }
}