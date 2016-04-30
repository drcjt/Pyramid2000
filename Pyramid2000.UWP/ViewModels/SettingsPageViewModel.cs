using Pyramid2000.UWP.Services.GameSettingsServices;
using Pyramid2000.UWP.Services.SettingsServices;
using System;
using Template10.Mvvm;
using Windows.UI.Xaml;

namespace Pyramid2000.UWP.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        SettingsService _settings;
        GameSettingsService _gameSettings;

        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _settings = SettingsService.Instance;
                _gameSettings = GameSettingsService.Instance;
            }
        }

        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
            set { _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; base.RaisePropertyChanged(); }
        }

        public int TextSize
        {
            get { return _settings.TextSize; }
            set { _settings.TextSize = value; base.RaisePropertyChanged(); }
        }

        public bool UseAllCaps
        {
            get { return _gameSettings.AllCaps; }
            set { _gameSettings.AllCaps = value; base.RaisePropertyChanged(); }
        }

        public bool UseTrs80Mode
        {
            get { return _gameSettings.Trs80Mode; }
            set { _gameSettings.Trs80Mode = value;  base.RaisePropertyChanged(); }
        }

        public bool ClearDialogueOnRoomChange
        {
            get { return _gameSettings.ClearDialogueOnRoomChange; }
            set { _gameSettings.ClearDialogueOnRoomChange = value; base.RaisePropertyChanged(); }
        }

        public bool ShowCompass
        {
            get { return _settings.ShowCompass; }
            set { _settings.ShowCompass = value;  base.RaisePropertyChanged(); }
        }

        public bool HidePossibleExitsOnCompass
        {
            get { return _settings.HidePossibleExitsOnCompass; }
            set { _settings.HidePossibleExitsOnCompass = value;  base.RaisePropertyChanged(); }
        }
    }

    public class AboutPartViewModel : ViewModelBase
    {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("http://aka.ms/template10");
    }
}

