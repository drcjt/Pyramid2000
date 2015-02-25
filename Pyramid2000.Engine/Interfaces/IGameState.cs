using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public interface IGameState
    {
        string LastRoom { get; set; }
        int TurnCount { get; set; }
        bool GameOver { get; set; }
        int BatteryLife { get; set; }
    }
}
