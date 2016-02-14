namespace Pyramid2000.Engine.Interfaces
{
    public interface IGameSettings
    {
        bool Trs80Mode { get; set; }
        bool AllCaps { get; set; }
        bool ClearDialogueOnRoomChange { get; set; }
    }
}
