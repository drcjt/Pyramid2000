using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pyramid2000.Services
{
    public class SettingsService : ISettingsService, INotifyPropertyChanged
    {
        public static SettingsService Instance { get; }
        static SettingsService()
        {
            Instance = Instance ?? new SettingsService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _showCompass;
        public bool ShowCompass
        {
            get
            {
                return _showCompass;
            }
            set
            {
                _showCompass = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowCompass"));
            }
        }

        private int _textSize;
        public int TextSize
        {
            get
            {
                return _textSize;
            }
            set
            {
                _textSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextSize"));
            }
        }
    }
}
