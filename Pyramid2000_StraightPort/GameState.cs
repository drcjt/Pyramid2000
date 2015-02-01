using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
{
    public class GameState : IGameState
    {
        public string LastRoom { get; set; }
        public int TurnCount { get; set; }
        public bool GameOver { get; set; }
        public int BatteryLife { get; set; }
    }
}
