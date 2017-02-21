using System.Collections.Generic;
using System.Linq;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    partial class Rooms : IRooms
    {
        private Dictionary<string, Room> BuildRooms_OutsideThePyramid()
        {
            return new Dictionary<string, Room>()
            {
                {
                    "room_1",
                    new Room()
                    {
                        ShortDescription = "Before entrance to Pyramid",
                        Description = Resources.Room1,
                        Lit = true,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_2") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_3") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_4") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_5") } },
                            { Function.In, new Script { s => s.MoveToRoomX("room_2") } },
                        }
                    }
                },
                {
                    "room_3",
                    new Room()
                    {
                        ShortDescription = "Desert",
                        Description = Resources.Desert,
                        Lit = true,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_6") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_3") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_4") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_1") } },
                        }
                    }
                },
                {
                    "room_4",
                    new Room()
                    {
                        ShortDescription = "Desert",
                        Description = Resources.Desert,
                        Lit = true,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_1") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_3") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_4") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_5") } },
                        }
                    }
                },
                {
                    "room_5",
                    new Room()
                    {
                        ShortDescription = "Desert",
                        Description = Resources.Desert,
                        Lit = true,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_6") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_1") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_4") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_5") } },
                        }
                    }
                },
                {
                    "room_6",
                    new Room()
                    {
                        ShortDescription = "Desert",
                        Description = Resources.Desert,
                        Lit = true,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_6") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_3") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_1") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_5") } },
                        }
                    }
                }
            };
        }
    }
}
