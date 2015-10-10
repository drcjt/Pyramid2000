using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Rooms : IRooms
    {
        private IItems _items;

        public Rooms(IItems items)
        {
            _items = items;
        }

        public Room GetRoom(string roomName)
        {
            if (_rooms.ContainsKey(roomName))
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

            if (ro.Lit)
            {
                return true;
            }

            var lamp = _items.GetTopItemByName("#LAMP_on");

            if (lamp.Location == roomName || lamp.Location == "pack")
            {
                return true;
            }

            return false;
        }

        public int CalculateScore()
        {
            var score = 0;

            return score;
        }

        private IDictionary<string, Room> _rooms = new Dictionary<string, Room>()
        {
            {
                "room_1",
                new Room()
                {
                    ShortDescription = "Before entrance to Pyramid",
                    Description = Resources.Room1,
                    Lit = true,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_2" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_3" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_4" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_5" } },
                        { Function.In, new List<object> { "MoveToRoomX", "room_2" } },
                    }
                }
            },
            {
                "room_2",
                new Room() 
                {
                    ShortDescription = "In Pyramid entrance",
                    Description = Resources.Room2,
                    Lit = true,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_1" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_7" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_1" } },
                        { Function.Panel, new List<object> { "MoveToRoomX", "room_26" } },
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
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_6" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_3" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_4" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_1" } },
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
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_1" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_3" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_4" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_5" } },
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
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_6" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_1" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_4" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_5" } },
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
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_6" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_3" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_1" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_5" } },
                    }
                }
            },
            {
                "room_7",
                new Room() 
                {
                    ShortDescription = "Small chamber beneath hole",
                    Description = Resources.Room7,
                    Lit = true,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_2" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_2" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_8" } },
                        { Function.In, new List<object> { "MoveToRoomX", "room_8" } },
                    }
                }
            },
            {
                "room_8",
                new Room()
                {
                    ShortDescription = "Crawling over pebbles",
                    Description = Resources.Room8,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_7" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_7" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_9" } },
                        { Function.In, new List<object> { "MoveToRoomX", "room_9" } },
                    }
                }
            },
            {
                "room_9",
                new Room()
                {
                    ShortDescription = "Broken Pottery Shards",
                    Description = Resources.Room9,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_8" } },
                        { Function.In, new List<object> { "MoveToRoomX", "room_10" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_10" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_10" } },
                    }
                }
            },
            {
                "room_10",
                new Room()
                {
                    ShortDescription = "Awkward sloping corridor",
                    Description = Resources.Room10,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Down, new List<object> { "MoveToRoomX", "room_9" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_9" } },
                        { Function.In, new List<object> { "MoveToRoomX", "room_11" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_11" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_11" } },
                    }
                }
            },
            {
                "room_11",
                new Room()
                {
                    ShortDescription = "Splendid chamber",
                    Description = Resources.Room11,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_10" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_12" } },
                    }
                }
            },
            {
                "room_12",
                new Room()
                {
                    ShortDescription = "Small pit",
                    Description = Resources.Room12,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_11" } },
                        { Function.Down, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#GOLD",
                                        "PrintMessageX", Resources.BrokenNeck,
                                        "PlayerDied"
                                    },
                                    "MoveToRoomX", "room_13"
                                }
                        },
                        { Function.West, new List<object> { "PrintMessageX", Resources.CrackTooSmall } },
                    }
                }
            },
            {
                "room_13",
                new Room()
                {
                    ShortDescription = "One end of vast hall",
                    Description = Resources.Room13,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_14" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_15" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.Up, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#GOLD",
                                        "PrintMessageX", Resources.DomeUnclimbable
                                    },
                                    "MoveToRoomX", "room_12"
                                }
                        },
                        { Function.East, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#GOLD",
                                        "PrintMessageX", Resources.DomeUnclimbable
                                    },
                                    "MoveToRoomX", "room_12"
                                }
                        },
                    }
                }
            },
            {
                "room_14",
                new Room()
                {
                    ShortDescription = "Low room",
                    Description = Resources.Room14,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Out, new List<object> { "MoveToRoomX", "room_13" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_13" } },
                    }
                }
            },
            {
                "room_15",
                new Room()
                {
                    ShortDescription = "East bank of bottomless pit",
                    Description = Resources.Room15,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_13" } },
                        { Function.Jump, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                        "PrintMessageX", Resources.CrossDontJump
                                    },
                                    "PrintMessageX",Resources.DidntMakeIt,
                                    "PlayerDied"
                                }
                        },
                        { Function.West, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                        "MoveToRoomX", "room_18"
                                    },
                                    "PrintMessageX", Resources.CantCrossPit,
                                }
                        },
                        { Function.Cross, new List<object>
                                {
                                    "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                    "MoveToRoomX", "room_18"
                                }
                        },
                        { Function.Wave, new List<object>
                                {
                                    "AssertItemXMatchesUserInput", "#SCEPTER",
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                        "MoveItemXToRoomY", "#bridge_15", "room_0",
                                        "MoveItemXToRoomY", "#bridge_18", "room_0",
                                        "PrintMessageX", Resources.BridgeRetracted
                                    },
                                    "MoveItemXToCurrentRoom", "#bridge_15",
                                    "MoveItemXToRoomY", "#bridge_18", "room_18",
                                    "PrintMessageX", Resources.BridgeAppears
                                }
                        },
                    }
                }
            },
            {
                "room_16",
                new Room()
                {
                    ShortDescription = "Pharaoh's chamber",
                    Description = Resources.Room16,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_13" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_13" } },
                        { Function.South, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", Resources.SerpentBlocks
                                    },
                                    "MoveToRoomX", "room_17"
                                }
                        },
                        { Function.North, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", Resources.SerpentBlocks
                                    },
                                    "MoveToRoomX", "room_25"
                                }
                        },
                        { Function.West, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", Resources.SerpentBlocks
                                    },
                                    "MoveToRoomX", "room_24"
                                }
                        },
                        { Function.Throw, new List<object>
                                {
                                    "AssertItemXMatchesUserInput", "#BIRD_boxed",
                                    "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                    "MoveItemXToRoomY", "#SERPENT", "room_0",
                                    "MoveItemXToCurrentRoom", "#BIRD",
                                    "MoveItemXToRoomY", "#BIRD_boxed", "room_0",
                                    "PrintMessageX", Resources.BirdAlive
                                }
                        },
                    }
                }
            },
            {
                "room_17",
                new Room()
                {
                    ShortDescription = "South side chamber",
                    Description = Resources.Room17,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_16" } },
                    }
                }
            },
            {
                "room_18",
                new Room()
                {
                    ShortDescription = "West side of bottomless pit",
                    Description = Resources.Room18,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Jump, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                        "PrintMessageX", Resources.CrossDontJump
                                    },
                                    "PrintMessageX", Resources.DidntMakeIt,
                                    "PlayerDied"
                                }
                        },
                        { Function.East, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                        "MoveToRoomX", "room_15"
                                    },
                                    "PrintMessageX", Resources.CantCrossPit
                                }
                        },
                        { Function.North, new List<object>
                                {
                                    "PrintMessageX", Resources.CrawlToPassage,
                                    "MoveToRoomX", "room_19"
                                }
                        },
                        { Function.Cross, new List<object>
                                {
                                    "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                    "MoveToRoomX", "room_15"
                                }
                        },
                        { Function.Wave, new List<object>
                                {
                                    "AssertItemXMatchesUserInput", "#SCEPTER",
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                        "MoveItemXToRoomY", "#bridge_18", "room_0",
                                        "MoveItemXToRoomY", "#bridge_15", "room_0",
                                        "PrintMessageX", Resources.BridgeRetracted
                                    },
                                    "MoveItemXToCurrentRoom", "#bridge_18",
                                    "MoveItemXToRoomY", "#bridge_15", "room_15",
                                    "PrintMessageX", Resources.BridgeAppears
                                }
                        },
                    }
                }
            },
            {
                "room_19",
                new Room()
                {
                    ShortDescription = "West end of hall of gods",
                    Description = Resources.Room19,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_28" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_28" } },
                        { Function.Climb, new List<object> { "MoveToRoomX", "room_28" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_18" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_18" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_20" } },
                    }
                }
            },
            {
                "room_20",
                new Room()
                {
                    ShortDescription = "East end of very long hall",
                    Description = Resources.Room20,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_19" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_19" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_21" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_22" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_21",
                new Room()
                {
                    ShortDescription = "West end of very long hall",
                    Description = Resources.Room21,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_20" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_22",
                new Room()
                {
                    ShortDescription = "Crossover of high N/S and low E/W",
                    Description = Resources.Room22,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object> { "MoveToRoomX", "room_20" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_23" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_24" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_21" } },
                    }
                }
            },
            {
                "room_23",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_22" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_24",
                new Room()
                {
                    ShortDescription = "West throne chamber",
                    Description = Resources.Room24,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_22" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_25",
                new Room()
                {
                    ShortDescription = "Low N/S passage at hole in floor",
                    Description = Resources.Room25,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Out, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_16" } },
                        { Function.North, new List<object> { "MoveToRoomX", "room_26" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_54" } },
                    }
                }
            },
            {
                "room_26",
                new Room()
                {
                    ShortDescription = "Large room with panel",
                    Description = Resources.Room26,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Panel, new List<object> { "MoveToRoomX", "room_2" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_25" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_27" } },
                    }
                }
            },
            {
                "room_27",
                new Room()
                {
                    ShortDescription = "Chamber of Anubis",
                    Description = Resources.Room27,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Down, new List<object> { "MoveToRoomX", "room_26" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_13" } },
                    }
                }
            },
            {
                "room_28",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_28" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_32" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_30" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_29" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_19" } },
                    }
                }
            },
            {
                "room_29",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_28" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_51" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_29" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_29" } },
                    }
                }
            },
            {
                "room_30",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_32" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_42" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_43" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_28" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_31" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_31" } },
                    }
                }
            },
            {
                "room_31",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_30" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_30" } },
                    }
                }
            },
            {
                "room_32",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_30" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_33" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_28" } },
                    }
                }
            },
            {
                "room_33",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_44" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_32" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_34" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_45" } },
                    }
                }
            },
            {
                "room_34",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_33" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_35" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_37" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_38" } },
                    }
                }
            },
            {
                "room_35",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_36" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_38" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_35" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_34" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_39" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_47" } },
                    }
                }
            },
            {
                "room_36",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_36" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_52" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_35" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_48" } },
                    }
                }
            },
            {
                "room_37",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_34" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_38" } },
                    }
                }
            },
            {
                "room_38",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_35" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_39" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_37" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_34" } },
                    }
                }
            },
            {
                "room_39",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_35" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_46" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_38" } },
                    }
                }
            },
            {
                "room_40",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_52" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_41" } },
                        { Function.NorthWest, new List<object> { "MoveToRoomX", "room_53" } },
                    }
                }
            },
            {
                "room_41",
                new Room()
                {
                    ShortDescription = "Maze of twisty passages",
                    Description = Resources.Maze,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_40" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_52" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_50" } },
                    }
                }
            },
            {
                "room_42",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object> { "MoveToRoomX", "room_30" } },
                    }
                }
            },
            {
                "room_43",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_30" } },
                    }
                }
            },
            {
                "room_44",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_33" } },
                    }
                }
            },
            {
                "room_45",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_33" } },
                    }
                }
            },
            {
                "room_46",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object> { "MoveToRoomX", "room_39" } },
                    }
                }
            },
            {
                "room_47",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_35" } },
                    }
                }
            },
            {
                "room_48",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_36" } },
                    }
                }
            },
            {
                "room_49",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_52" } },
                    }
                }
            },
            {
                "room_50",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_41" } },
                    }
                }
            },
            {
                "room_51",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object> { "MoveToRoomX", "room_29" } },
                        { Function.Drop, new List<object>
                                {
                                    "AssertItemXMatchesUserInput", "#COINS",
                                    "MoveItemXToRoomY", "#COINS", "room_0",
                                    "MoveItemXToCurrentRoom", "#BATTERIES_fresh",
                                    "PrintMessageX", Resources.FreshBatteries                                    
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
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_41" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_40" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_49" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_36" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_11" } },
                    }
                }
            },
            {
                "room_53",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.SouthEast, new List<object> { "MoveToRoomX", "room_40" } },
                    }
                }
            },
            {
                "room_54",
                new Room()
                {
                    ShortDescription = "Dirty broken passage",
                    Description = Resources.Room54,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_55" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_57" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_25" } },
                    }
                }
            },
            {
                "room_55",
                new Room()
                {
                    ShortDescription = "Brink of small clean pit",
                    Description = Resources.Room55,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object> { "MoveToRoomX", "room_54" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_56" } },
                        { Function.Climb, new List<object> { "MoveToRoomX", "room_56" } },
                    }
                }
            },
            {
                "room_56",
                new Room()
                {
                    ShortDescription = "Bottom of small pit with stream",
                    Description = Resources.Room56,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_55" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_55" } },
                        { Function.Climb, new List<object> { "MoveToRoomX", "room_55" } },
                        { Function.Down, new List<object> { "PrintMessageX", Resources.CantFitThroughTwoInchSlit } },
                        { Function.Fill, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#WATER",
                                        "PrintMessageX", Resources.BottleAlreadyFull
                                    },
                                    "MoveItemXToLocationY", "#WATER", "#BOTTLE"
                                }
                        },
                    }
                }
            },
            {
                "room_57",
                new Room()
                {
                    ShortDescription = "Room of Bes",
                    Description = Resources.Room57,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_54" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_58" } },
                    }
                }
            },
            {
                "room_58",
                new Room()
                {
                    ShortDescription = "Complex Junction",
                    Description = Resources.Room58,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_61" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_59" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_65" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_57" } },
                        { Function.Climb, new List<object> { "MoveToRoomX", "room_57" } },
                    }
                }
            },
            {
                "room_59",
                new Room()
                {
                    ShortDescription = "Anteroom of Seker",
                    Description = Resources.Room59,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_60" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_65" } },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_58" } },
                    }
                }
            },
            {
                "room_60",
                new Room()
                {
                    ShortDescription = "Land of the dead",
                    Description = Resources.Room60,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.East, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.South, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.NorthEast, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.SouthEast, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.SouthWest, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.NorthWest, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.Up, new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { Function.West, new List<object> {
                            "PrintMessageX", Resources.CrawledAround,
                            "MoveToRoomX", "room_60" }
                        },
                    }
                }
            },
            {
                "room_61",
                new Room()
                {
                    ShortDescription = "Large room with ancient drawings",
                    Description = Resources.Room61,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#SARCOPH_full",
                                        "PrintMessageX", Resources.SarcophagusDoesntFit
                                    },
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#SARCOPH_empty",
                                        "PrintMessageX", Resources.SarcophagusDoesntFit
                                    },
                                    "MoveToRoomX", "room_58"
                                }
                        },
                        { Function.Up, new List<object> { "MoveToRoomX", "room_62" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_63" } },
                    }
                }
            },
            {
                "room_62",
                new Room()
                {
                    ShortDescription = "Chamber of Khons",
                    Description = Resources.Room62,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Down, new List<object> { "MoveToRoomX", "room_61" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_61" } },
                    }
                }
            },
            {
                "room_63",
                new Room()
                {
                    ShortDescription = "Long sloping corridor",
                    Description = Resources.Room63,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_61" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_64" } },
                    }
                }
            },
            {
                "room_64",
                new Room()
                {
                    ShortDescription = "Cul-de-sac",
                    Description = Resources.Room64,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_63" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_63" } },
                    }
                }
            },
            {
                "room_65",
                new Room()
                {
                    ShortDescription = "Chamber of Horus",
                    Description = Resources.Room65,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_58" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_78" } },
                        { Function.Up, new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_72" } },
                        { Function.North, new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_73" } },
                        { Function.South, new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_66" } },
                        { Function.Down, new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_59" } },
                    }
                }
            },
            {
                "room_66",
                new Room()
                {
                    ShortDescription = "Large low circular chamber",
                    Description = Resources.Room66,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_65" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_80" } },
                    }
                }
            },
            // There is no room_67
            {
                "room_68",
                new Room()
                {
                    ShortDescription = "Chamber of Nekhebet",
                    Description = Resources.Room68,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_71" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_70",
                new Room()
                {
                    ShortDescription = "Fallen block",
                    Description = Resources.Room70,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.South, new List<object> { "MoveToRoomX", "room_71" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_71",
                new Room()
                {
                    ShortDescription = "Chamber of Osiris",
                    Description = Resources.Room71,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.North, new List<object> { "MoveToRoomX", "room_68" } },
                        { Function.East, new List<object> { "MoveToRoomX", "room_70" } },
                        { Function.South, new List<object> { "MoveToRoomX", "room_77" } },
                    }
                }
            },            
            {
                "room_72",
                new Room()
                {
                    ShortDescription = "Priest's bedroom",
                    Description = Resources.Room72,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object> { "MoveToRoomX", "room_65" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_65" } },
                    }
                }
            },
            {
                "room_73",
                new Room()
                {
                    ShortDescription = "Chamber of high priest",
                    Description = Resources.Room73,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.West, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_76"
                                    },
                                    "PrintMessageX", Resources.DropSomething
                                }
                        },
                        { Function.SouthEast, new List<object> { "MoveToRoomX", "room_65" } },
                    }
                }
            },
            // No room room_74
            // No room room_75
            {
                "room_76",
                new Room()
                {
                    ShortDescription = "High priest's treasure room",
                    Description = Resources.Room76,
                    Lit = true,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_73"
                                    },
                                    "PrintMessageX", Resources.DropSomething
                                }
                        },
                        { Function.Out, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_76"
                                    },
                                    "PrintMessageX", Resources.DropSomething
                                }
                        },
                    }
                }
            },
            {
                "room_77",
                new Room()
                {
                    ShortDescription = "Long narrow corridor",
                    Description = Resources.Room77,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_81" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_81" } },
                        { Function.Climb, new List<object> { "MoveToRoomX", "room_81" } },
                        { Function.Jump, new List<object> { "PrintMessageX", Resources.BrokenNeck,
                                                      "PlayerDied" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_78",
                new Room()
                {
                    ShortDescription = "East end of twopit room",
                    Description = Resources.Room78,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_65" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_80" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_79" } },
                    }
                }
            },
            {
                "room_79",
                new Room()
                {
                    ShortDescription = "Bottom of eastern pit",
                    Description = Resources.Room79,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_78" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_78" } },
                    }
                }
            },
            {
                "room_80",
                new Room()
                {
                    ShortDescription = "West end of twopit room",
                    Description = Resources.Room80,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.East, new List<object> { "MoveToRoomX", "room_78" } },
                        { Function.West, new List<object> { "MoveToRoomX", "room_66" } },
                        { Function.Down, new List<object> { "MoveToRoomX", "room_81" } },
                    }
                }
            },
            {
                "room_81",
                new Room()
                {
                    ShortDescription = "Bottom of western pit",
                    Description = Resources.Room81,
                    Commands = new Dictionary<Function, List<object>>()
                    {
                        { Function.Up, new List<object> { "MoveToRoomX", "room_80" } },
                        { Function.Out, new List<object> { "MoveToRoomX", "room_80" } },
                        { Function.Climb, new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_C",
                                        "PrintMessageX", Resources.ClimbPlant,
                                        "MoveToRoomX", "room_77"
                                    },
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_B",
                                        "PrintMessageX", Resources.ClimbedPlant
                                    },
                                    "MoveToRoomX", "room_80",
                                    "PrintMessageX", Resources.NothingToClimb
                                }
                        },
                        { Function.Pour, new List<object>
                                {
                                    "AssertItemXMatchesUserInput", "#WATER",
                                    "MoveItemXToRoomY", "#WATER", "room_0",
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_A",
                                        "MoveItemXToRoomY", "#PLANT_A", "room_0",
                                        "MoveItemXToCurrentRoom", "#PLANT_B",
                                        "PrintMessageX", Resources.PlantSpurts,
                                        "PrintMessageX", Resources.PlantBellowing
                                    },
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_B",
                                        "MoveItemXToRoomY", "#PLANT_B", "room_0",
                                        "MoveItemXToCurrentRoom", "#PLANT_C",
                                        "PrintMessageX", Resources.PlantGrows,
                                        "PrintMessageX", Resources.GiganticBeanStalk
                                    },
                                    "MoveItemXToRoomY", "#PLANT_C", "room_0",
                                    "MoveItemXToCurrentRoom", "#PLANT_A",
                                    "PrintMessageX", Resources.OverwateredPlant,
                                    "PrintMessageX", Resources.PlantMurmuring
                                }
                        },
                    }
                }
            },
        };
    }
}