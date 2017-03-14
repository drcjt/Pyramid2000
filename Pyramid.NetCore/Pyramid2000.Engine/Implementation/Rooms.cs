using System.Collections.Generic;
using System.Linq;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;
namespace Pyramid2000.Engine
{
    public partial class Rooms : IRooms
    {
        private readonly IItems _items;

        private IResources Resources { get; set; }

        public Rooms(IItems items, IResources resources)
        {
            _items = items;
            Resources = resources;

            BuildRooms();
        }

        public IScripter Scripter { get; set; }

        public Room GetRoom(string roomName)
        {
            if (roomName !=null && _rooms.ContainsKey(roomName))
            {
                return _rooms[roomName];
            }

            return null;
        }

        public IList<string> GetRoomNames()
        {
            return _rooms.Keys.ToList<string>();
        }

        public bool IsRoomLit(string roomName)
        {
            var ro = GetRoom(roomName);

            if (ro != null)
            {
                if (ro.Lit)
                {
                    return true;
                }

                var lamp = _items.GetTopItemByName("#LAMP_on");

                if (lamp.Location == roomName || lamp.Location == "pack")
                {
                    return true;
                }

            }

            return false;
        }

        public int CalculateScore()
        {
            var score = 0;

            return score;
        }

        private IDictionary<string, Room> _rooms;
        
        private void BuildRooms()
        {
            _rooms = new Dictionary<string, Room>();

            Merge(_rooms, BuildRooms_OutsideThePyramid());
            Merge(_rooms, BuildRooms_UpperFloor());
            Merge(_rooms, BuildRooms_LowerFloor());
            Merge(_rooms, BuildRooms_TheMaze());
        }

        private static void Merge<TKey, TValue>(IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            if (second == null || first == null) return;
            foreach (var item in second)
                if (!first.ContainsKey(item.Key))
                    first.Add(item.Key, item.Value);
        }
    }
}