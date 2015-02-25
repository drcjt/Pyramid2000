using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Description = Resources.Room1,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_2" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_3" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_4" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_5" } },
                        { "_in", new List<object> { "MoveToRoomX", "room_2" } },
                    }
                }
            },
            {
                "room_2",
                new Room() 
                {
                    Description = Resources.Room2,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_1" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_7" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_1" } },
                        { "_panel", new List<object> { "MoveToRoomX", "room_26" } },
                    }
                }
            },
            {
                "room_3",
                new Room() 
                {
                    Description = Resources.Desert,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_6" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_3" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_4" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_1" } },
                    }
                }
            },
            {
                "room_4",
                new Room() 
                {
                    Description = Resources.Desert,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_1" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_3" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_4" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_5" } },
                    }
                }
            },
            {
                "room_5",
                new Room() 
                {
                    Description = Resources.Desert,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_6" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_1" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_4" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_5" } },
                    }
                }
            },
            {
                "room_6",
                new Room() 
                {
                    Description = Resources.Desert,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_6" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_3" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_1" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_5" } },
                    }
                }
            },
            {
                "room_7",
                new Room() 
                {
                    Description = Resources.Room7,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_2" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_2" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_8" } },
                        { "_in", new List<object> { "MoveToRoomX", "room_8" } },
                    }
                }
            },
            {
                "room_8",
                new Room()
                {
                    Description = Resources.Room8,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_7" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_7" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_9" } },
                        { "_in", new List<object> { "MoveToRoomX", "room_9" } },
                    }
                }
            },
            {
                "room_9",
                new Room()
                {
                    Description = Resources.Room9,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_8" } },
                        { "_in", new List<object> { "MoveToRoomX", "room_10" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_10" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_10" } },
                    }
                }
            },
            {
                "room_10",
                new Room()
                {
                    Description = Resources.Room10,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_d", new List<object> { "MoveToRoomX", "room_9" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_9" } },
                        { "_in", new List<object> { "MoveToRoomX", "room_11" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_11" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_11" } },
                    }
                }
            },
            {
                "room_11",
                new Room()
                {
                    Description = Resources.Room11,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_10" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_12" } },
                    }
                }
            },
            {
                "room_12",
                new Room()
                {
                    Description = Resources.Room12,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_11" } },
                        { "_d", new List<object>
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
                        { "_w", new List<object> { "PrintMessageX", Resources.CrackTooSmall } },
                    }
                }
            },
            {
                "room_13",
                new Room()
                {
                    Description = Resources.Room13,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_14" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_15" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_u", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#GOLD",
                                        "PrintMessageX", Resources.DomeUnclimbable
                                    },
                                    "MoveToRoomX", "room_12"
                                }
                        },
                        { "_e", new List<object>
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
                    Description = Resources.Room14,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_out", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_13" } },
                    }
                }
            },
            {
                "room_15",
                new Room()
                {
                    Description = Resources.Room15,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_jump", new List<object>
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
                        { "_w", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                        "MoveToRoomX", "room_18"
                                    },
                                    "PrintMessageX", Resources.BridgeRetracted
                                }
                        },
                        { "_cross", new List<object>
                                {
                                    "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                    "MoveToRoomX", "room_18"
                                }
                        },
                        { "_wave", new List<object>
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
                    Description = Resources.Room16,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_s", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", Resources.SerpentBlocks
                                    },
                                    "MoveToRoomX", "room_17"
                                }
                        },
                        { "_n", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", Resources.SerpentBlocks
                                    },
                                    "MoveToRoomX", "room_25"
                                }
                        },
                        { "_w", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", Resources.SerpentBlocks
                                    },
                                    "MoveToRoomX", "room_24"
                                }
                        },
                        { "_throw", new List<object>
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
                    Description = Resources.Room17,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_16" } },
                    }
                }
            },
            {
                "room_18",
                new Room()
                {
                    Description = Resources.Room18,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_jump", new List<object>
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
                        { "_e", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                        "MoveToRoomX", "room_15"
                                    },
                                    "PrintMessageX", Resources.CantCrossPit
                                }
                        },
                        { "_n", new List<object>
                                {
                                    "PrintMessageX", Resources.CrawlToPassage,
                                    "MoveToRoomX", "room_19"
                                }
                        },
                        { "_cross", new List<object>
                                {
                                    "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                    "MoveToRoomX", "room_15"
                                }
                        },
                        { "_wave", new List<object>
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
                    Description = Resources.Room19,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_28" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_28" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_28" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_18" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_18" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_20" } },
                    }
                }
            },
            {
                "room_20",
                new Room()
                {
                    Description = Resources.Room20,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_19" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_19" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_21" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_22" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_21",
                new Room()
                {
                    Description = Resources.Room21,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_20" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_22",
                new Room()
                {
                    Description = Resources.Room22,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_20" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_23" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_24" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_21" } },
                    }
                }
            },
            {
                "room_23",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_22" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_24",
                new Room()
                {
                    Description = Resources.Room24,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_22" } },
                        { "_up", new List<object> { "MoveToRoomX", "room_22" } },
                    }
                }
            },
            {
                "room_25",
                new Room()
                {
                    Description = Resources.Room25,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_out", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_16" } },
                        { "_n", new List<object> { "MoveToRoomX", "room_26" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_54" } },
                    }
                }
            },
            {
                "room_26",
                new Room()
                {
                    Description = Resources.Room26,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_panel", new List<object> { "MoveToRoomX", "room_2" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_25" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_27" } },
                    }
                }
            },
            {
                "room_27",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_d", new List<object> { "MoveToRoomX", "room_26" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_13" } },
                    }
                }
            },
            {
                "room_28",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_28" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_32" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_30" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_29" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_19" } },
                    }
                }
            },
            {
                "room_29",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_28" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_51" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_29" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_29" } },
                    }
                }
            },
            {
                "room_30",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_32" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_42" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_43" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_28" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_31" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_31" } },
                    }
                }
            },
            {
                "room_31",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_30" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_30" } },
                    }
                }
            },
            {
                "room_32",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_30" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_33" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_28" } },
                    }
                }
            },
            {
                "room_33",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_44" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_32" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_34" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_45" } },
                    }
                }
            },
            {
                "room_34",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_33" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_35" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_37" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_38" } },
                    }
                }
            },
            {
                "room_35",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_36" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_38" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_35" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_34" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_39" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_47" } },
                    }
                }
            },
            {
                "room_36",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_36" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_52" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_35" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_48" } },
                    }
                }
            },
            {
                "room_37",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_34" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_38" } },
                    }
                }
            },
            {
                "room_38",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_35" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_39" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_37" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_34" } },
                    }
                }
            },
            {
                "room_39",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_35" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_46" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_38" } },
                    }
                }
            },
            {
                "room_40",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_52" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_41" } },
                        { "_nw", new List<object> { "MoveToRoomX", "room_53" } },
                    }
                }
            },
            {
                "room_41",
                new Room()
                {
                    Description = Resources.Maze,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_40" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_52" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_50" } },
                    }
                }
            },
            {
                "room_42",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_30" } },
                    }
                }
            },
            {
                "room_43",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_30" } },
                    }
                }
            },
            {
                "room_44",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_33" } },
                    }
                }
            },
            {
                "room_45",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_33" } },
                    }
                }
            },
            {
                "room_46",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_39" } },
                    }
                }
            },
            {
                "room_47",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_35" } },
                    }
                }
            },
            {
                "room_48",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_36" } },
                    }
                }
            },
            {
                "room_49",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_52" } },
                    }
                }
            },
            {
                "room_50",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_41" } },
                    }
                }
            },
            {
                "room_51",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_29" } },
                        { "_drop", new List<object>
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
                    Description = Resources.Room52,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_41" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_40" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_49" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_36" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_11" } },
                    }
                }
            },
            {
                "room_53",
                new Room()
                {
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_se", new List<object> { "MoveToRoomX", "room_40" } },
                    }
                }
            },
            {
                "room_54",
                new Room()
                {
                    Description = Resources.Room54,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_57" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_25" } },
                    }
                }
            },
            {
                "room_55",
                new Room()
                {
                    Description = Resources.Room55,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_54" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_56" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_56" } },
                    }
                }
            },
            {
                "room_56",
                new Room()
                {
                    Description = Resources.Room56,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_d", new List<object> { "PrintMessageX", Resources.CantFitThroughTwoInchSlit } },
                        { "_fill", new List<object>
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
                    Description = Resources.Room57,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_54" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_58" } },
                    }
                }
            },
            {
                "room_58",
                new Room()
                {
                    Description = Resources.Room58,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_61" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_59" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_65" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_57" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_57" } },
                    }
                }
            },
            {
                "room_59",
                new Room()
                {
                    Description = Resources.Room59,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_60" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_65" } },
                        { "_u", new List<object> { "MoveToRoomX", "room_58" } },
                    }
                }
            },
            {
                "room_60",
                new Room()
                {
                    Description = Resources.Room60,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_e", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_s", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_ne", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_se", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_sw", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_nw", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_u", new List<object> {
                            "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "240" },
                            "MoveToRoomX","room_59" }
                        },
                        { "_w", new List<object> {
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
                    Description = Resources.Room61,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object>
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
                        { "_u", new List<object> { "MoveToRoomX", "room_62" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_63" } },
                    }
                }
            },
            {
                "room_62",
                new Room()
                {
                    Description = Resources.Room62,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_d", new List<object> { "MoveToRoomX", "room_61" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_61" } },
                    }
                }
            },
            {
                "room_63",
                new Room()
                {
                    Description = Resources.Room63,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_61" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_64" } },
                    }
                }
            },
            {
                "room_64",
                new Room()
                {
                    Description = Resources.Room64,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_63" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_63" } },
                    }
                }
            },
            {
                "room_65",
                new Room()
                {
                    Description = Resources.Room65,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_58" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_78" } },
                        { "_u", new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_72" } },
                        { "_n", new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_73" } },
                        { "_s", new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_66" } },
                        { "_d", new List<object> { "SubScriptXAbortIfPass", new List<object> { "AssertRandomIsGreaterThanX", "204" }, "MoveToRoomX", "room_59" } },
                    }
                }
            },
            {
                "room_66",
                new Room()
                {
                    Description = Resources.Room66,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_65" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_80" } },
                    }
                }
            },
            // There is no room_67
            {
                "room_68",
                new Room()
                {
                    Description = Resources.Room68,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_71" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_70",
                new Room()
                {
                    Description = Resources.Room70,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object> { "MoveToRoomX", "room_71" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_71",
                new Room()
                {
                    Description = Resources.Room71,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_n", new List<object> { "MoveToRoomX", "room_68" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_70" } },
                        { "_s", new List<object> { "MoveToRoomX", "room_77" } },
                    }
                }
            },            
            {
                "room_72",
                new Room()
                {
                    Description = Resources.Room72,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_65" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_65" } },
                    }
                }
            },
            {
                "room_73",
                new Room()
                {
                    Description = Resources.Room73,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_76"
                                    },
                                    "PrintMessageX", Resources.DropSomething
                                }
                        },
                        { "_se", new List<object> { "MoveToRoomX", "room_65" } },
                    }
                }
            },
            // No room room_74
            // No room room_75
            {
                "room_76",
                new Room()
                {
                    Description = Resources.Room76,
                    Lit = true,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_73"
                                    },
                                    "PrintMessageX", Resources.DropSomething
                                }
                        },
                        { "_out", new List<object>
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
                    Description = Resources.Room77,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_81" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_81" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_81" } },
                        { "_jump", new List<object> { "PrintMessageX", Resources.BrokenNeck,
                                                      "PlayerDied" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_78",
                new Room()
                {
                    Description = Resources.Room78,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_65" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_80" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_79" } },
                    }
                }
            },
            {
                "room_79",
                new Room()
                {
                    Description = Resources.Room79,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_78" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_78" } },
                    }
                }
            },
            {
                "room_80",
                new Room()
                {
                    Description = Resources.Room80,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_78" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_66" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_81" } },
                    }
                }
            },
            {
                "room_81",
                new Room()
                {
                    Description = Resources.Room81,
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_80" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_80" } },
                        { "_climb", new List<object>
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
                        { "_pour", new List<object>
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