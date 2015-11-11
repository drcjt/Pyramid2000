using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class GameSettings : IGameSettings
    {
        public bool Trs80Mode { get; set; }
        public bool AllCaps { get; set; }
        public bool ClearDialogueOnRoomChange { get; set; }

        public ObservableCollection<IItem> InventoryItems { get; set; }

        public IItems Items { get; set; }
    }
}
