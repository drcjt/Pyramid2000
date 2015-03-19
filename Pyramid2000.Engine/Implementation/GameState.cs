using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class GameState : IGameState
    {
        public string LastRoom { get; set; }
        public int TurnCount { get; set; }
        public bool GameOver { get; set; }
        public int BatteryLife { get; set; }
    }
}
