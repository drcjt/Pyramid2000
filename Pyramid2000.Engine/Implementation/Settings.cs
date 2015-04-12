using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Settings : ISettings
    {
        public bool Trs80Mode { get; set; }
        public bool AllCaps { get; set; }
        public bool ClearDialogueOnRoomChange { get; set; }
    }
}
