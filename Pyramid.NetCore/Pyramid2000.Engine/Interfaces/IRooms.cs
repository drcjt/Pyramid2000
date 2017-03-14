using System.Collections.Generic;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IRooms
    {
        Room GetRoom(string roomName);
        bool IsRoomLit(string roomName);
        int CalculateScore();

        IList<string> GetRoomNames();

        IScripter Scripter { get; set; }
    }
}
