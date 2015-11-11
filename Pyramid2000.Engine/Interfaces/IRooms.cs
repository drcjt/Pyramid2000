using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
