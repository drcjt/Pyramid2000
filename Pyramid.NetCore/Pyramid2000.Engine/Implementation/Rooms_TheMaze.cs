using System.Collections.Generic;
using System.Linq;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    partial class Rooms : IRooms
    {
        private IDictionary<string, Room> BuildRooms_TheMaze()
        {
            return new Dictionary<string, Room>()
            {
                {
                    "room_28",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_28") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_32") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_30") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_29") } },
                            { Function.Up, new Script { s => s.MoveToRoomX("room_19") } },
                        }
                    }
                },
                {
                    "room_29",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_28") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_51") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_29") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_29") } },
                        }
                    }
                },
                {
                    "room_30",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_32") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_42") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_43") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_28") } },
                            { Function.Up, new Script { s => s.MoveToRoomX("room_31") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_31") } },
                        }
                    }
                },
                {
                    "room_31",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.Up, new Script { s => s.MoveToRoomX("room_30") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_30") } },
                        }
                    }
                },
                {
                    "room_32",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_30") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_33") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_28") } },
                        }
                    }
                },
                {
                    "room_33",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_44") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_32") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_34") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_45") } },
                        }
                    }
                },
                {
                    "room_34",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_33") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_35") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_37") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_38") } },
                        }
                    }
                },
                {
                    "room_35",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_36") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_38") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_35") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_34") } },
                            { Function.Up, new Script { s => s.MoveToRoomX("room_39") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_47") } },
                        }
                    }
                },
                {
                    "room_36",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_36") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_52") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_35") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_48") } },
                        }
                    }
                },
                {
                    "room_37",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_34") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_38") } },
                        }
                    }
                },
                {
                    "room_38",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_35") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_39") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_37") } },
                            { Function.Up, new Script { s => s.MoveToRoomX("room_34") } },
                        }
                    }
                },
                {
                    "room_39",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_35") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_46") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_38") } },
                        }
                    }
                },
                {
                    "room_40",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_52") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_41") } },
                            { Function.NorthWest, new Script { s => s.MoveToRoomX("room_53") } },
                        }
                    }
                },
                {
                    "room_41",
                    new Room()
                    {
                        ShortDescription = "Maze of twisty passages",
                        Description = Resources.Maze,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_40") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_52") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_50") } },
                        }
                    }
                },
                {
                    "room_42",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.West, new Script { s => s.MoveToRoomX("room_30") } },
                        }
                    }
                },
                {
                    "room_43",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_30") } },
                        }
                    }
                },
                {
                    "room_44",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.South, new Script { s => s.MoveToRoomX("room_33") } },
                        }
                    }
                },
                {
                    "room_45",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.Up, new Script { s => s.MoveToRoomX("room_33") } },
                        }
                    }
                },
                {
                    "room_46",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.West, new Script { s => s.MoveToRoomX("room_39") } },
                        }
                    }
                },
                {
                    "room_47",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.Up, new Script { s => s.MoveToRoomX("room_35") } },
                        }
                    }
                },
                {
                    "room_48",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.Up, new Script { s => s.MoveToRoomX("room_36") } },
                        }
                    }
                },
                {
                    "room_49",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_52") } },
                        }
                    }
                },
                {
                    "room_50",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.East, new Script { s => s.MoveToRoomX("room_41") } },
                        }
                    }
                },
                {
                    "room_51",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.West, new Script { s => s.MoveToRoomX("room_29") } },
                            { Function.Drop, new Script
                                    {
                                        s => s.AssertItemXMatchesUserInput("#COINS"),
                                        s => s.MoveItemXToRoomY("#COINS", "room_0"),
                                        s => s.MoveItemXToCurrentRoom("#BATTERIES_fresh"),
                                        s => s.PrintMessageX(Resources.FreshBatteries)
                                    }
                            }
                        }
                    }
                },
                {
                    "room_52",
                    new Room()
                    {
                        ShortDescription = "Brink of pit",
                        Description = Resources.Room52,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.North, new Script { s => s.MoveToRoomX("room_41") } },
                            { Function.East, new Script { s => s.MoveToRoomX("room_40") } },
                            { Function.South, new Script { s => s.MoveToRoomX("room_49") } },
                            { Function.West, new Script { s => s.MoveToRoomX("room_36") } },
                            { Function.Down, new Script { s => s.MoveToRoomX("room_11") } },
                        }
                    }
                },
                {
                    "room_53",
                    new Room()
                    {
                        ShortDescription = "Dead end",
                        Description = Resources.DeadEnd,
                        Commands = new Dictionary<Function, Script>()
                        {
                            { Function.SouthEast, new Script { s => s.MoveToRoomX("room_40") } },
                        }
                    }
                },
            };
        }
    }
}