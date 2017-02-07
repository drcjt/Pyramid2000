using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;

namespace Pyramid2000.UWP.Services.SettingsServices
{
    public class SettingsService
    {
        public static SettingsService Instance { get; }
        static SettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        readonly Template10.Services.SettingsService.ISettingsHelper _helper;
        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public int TextSize
        {
            get { return _helper.Read<int>(nameof(TextSize), 20); }
            set { _helper.Write(nameof(TextSize), value); }
        }

        public bool ShowCompassDefault { get; set; } = true;

        public bool ShowCompass
        {
            get { return _helper.Read<bool>(nameof(ShowCompass), ShowCompassDefault); }
            set { _helper.Write(nameof(ShowCompass), value); }
        }

        public bool HidePossibleExitsOnCompassDefault { get; set; } = true;
        public bool HidePossibleExitsOnCompass
        {
            get { return _helper.Read<bool>(nameof(HidePossibleExitsOnCompass), HidePossibleExitsOnCompassDefault); }
            set { _helper.Write(nameof(HidePossibleExitsOnCompass), value); }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Dark;
                var value = _helper.Read<string>(nameof(AppTheme), theme.ToString());
                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                (Window.Current.Content as FrameworkElement).RequestedTheme = value.ToElementTheme();
                Views.Shell.HamburgerMenu.RefreshStyles(value);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get { return _helper.Read<TimeSpan>(nameof(CacheMaxDuration), TimeSpan.FromDays(2)); }
            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }
    }
}

