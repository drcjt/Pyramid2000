using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public interface ISettings
    {
        bool Trs80Mode { get; set; }
        bool AllCaps { get; set; }
        bool ClearDialogueOnRoomChange { get; set; }
    }
}
