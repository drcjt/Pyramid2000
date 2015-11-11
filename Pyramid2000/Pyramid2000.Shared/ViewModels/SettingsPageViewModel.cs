using Pyramid2000.Engine.Interfaces;
using Pyramid2000.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid2000.ViewModels
{
    class SettingsPageViewModel
    {
        ISettingsService _settings = SettingsService.Instance;

        public bool ShowCompass
        {
            get { return _settings.ShowCompass; }
            set { _settings.ShowCompass = value;  }
        }
        public int TextSize
        {
            get { return _settings.TextSize; }
            set { _settings.TextSize = value; }
        }

        IGameSettings _gameSettings = App.GameSettings;

        public bool Trs80Mode
        {
            get { return _gameSettings.Trs80Mode; }
            set { _gameSettings.Trs80Mode = value; }
        }

        public bool AllCaps
        {
            get { return _gameSettings.AllCaps; }
            set { _gameSettings.AllCaps = value; }
        }

        public bool ClearDialogueOnRoomChange
        {
            get { return _gameSettings.ClearDialogueOnRoomChange; }
            set { _gameSettings.ClearDialogueOnRoomChange = value; }
        }
    }
}
