using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.UWP.Services.GameSettingsServices
{
    public class GameSettingsService : IGameSettings
    {
        public static GameSettingsService Instance { get; }
        static GameSettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new GameSettingsService();
        }

        Template10.Services.SettingsService.ISettingsHelper _helper;
        private GameSettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool AllCaps
        {
            get { return _helper.Read<bool>(nameof(AllCaps), false); }
            set { _helper.Write(nameof(AllCaps), value); }
        }

        public bool Trs80Mode
        {
            get { return _helper.Read<bool>(nameof(Trs80Mode), true); }
            set { _helper.Write(nameof(Trs80Mode), value); }
        }

        public bool ClearDialogueOnRoomChange
        {
            get { return _helper.Read<bool>(nameof(ClearDialogueOnRoomChange), false); }
            set { _helper.Write(nameof(ClearDialogueOnRoomChange), value); }
        }
    }
}
