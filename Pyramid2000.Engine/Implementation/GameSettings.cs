using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class GameSettings : IGameSettings
    {
        public bool Trs80Mode { get; set; } = true;
        public bool AllCaps { get; set; }
        public bool ClearDialogueOnRoomChange { get; set; }

        public IItems Items { get; set; }
    }
}
