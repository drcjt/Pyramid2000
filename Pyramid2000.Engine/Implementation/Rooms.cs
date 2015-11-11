using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    public class Rooms : IRooms
    {
        private IItems _items;

        public Rooms(IItems items)
        {
            _items = items;
        }

        public IScripter Scripter { get; set; }

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
                "room_2",
                new Room()
                {
                    ShortDescription = "In Pyramid entrance",
                    Description = Resources.Room2,
                    Lit = true,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script { s => s.MoveToRoomX("room_1") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_7") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_1") } },
                        { Function.Panel, new Script { s => s.MoveToRoomX("room_26") } },
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
            },
            {
                "room_7",
                new Room()
                {
                    ShortDescription = "Small chamber beneath hole",
                    Description = Resources.Room7,
                    Lit = true,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_2") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_2") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_8") } },
                        { Function.In, new Script { s => s.MoveToRoomX("room_8") } },
                    }
                }
            },
            {
                "room_8",
                new Room()
                {
                    ShortDescription = "Crawling over pebbles",
                    Description = Resources.Room8,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_7") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_7") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_9") } },
                        { Function.In, new Script { s => s.MoveToRoomX("room_9") } },
                    }
                }
            },
            {
                "room_9",
                new Room()
                {
                    ShortDescription = "Broken Pottery Shards",
                    Description = Resources.Room9,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_8") } },
                        { Function.In, new Script { s => s.MoveToRoomX("room_10") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_10") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_10") } },
                    }
                }
            },
            {
                "room_10",
                new Room()
                {
                    ShortDescription = "Awkward sloping corridor",
                    Description = Resources.Room10,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Down, new Script { s => s.MoveToRoomX("room_9") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_9") } },
                        { Function.In, new Script { s => s.MoveToRoomX("room_11") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_11") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_11") } },
                    }
                }
            },
            {
                "room_11",
                new Room()
                {
                    ShortDescription = "Splendid chamber",
                    Description = Resources.Room11,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_10") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_12") } },
                    }
                }
            },
            {
                "room_12",
                new Room()
                {
                    ShortDescription = "Small pit",
                    Description = Resources.Room12,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_11") } },
                        { Function.Down, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInPack("#GOLD"),
                                        t => t.PrintMessageX(Resources.BrokenNeck),
                                        t => t.PlayerDied()
                                    }),
                                    s => s.MoveToRoomX("room_13")
                                }
                        },
                        { Function.West, new Script { s => s.PrintMessageX(Resources.CrackTooSmall) } },
                    }
                }
            },
            {
                "room_13",
                new Room()
                {
                    ShortDescription = "One end of vast hall",
                    Description = Resources.Room13,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script { s => s.MoveToRoomX("room_14") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_15") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.Up, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInPack("#GOLD"),
                                        t => t.PrintMessageX(Resources.DomeUnclimbable)
                                    }),
                                    s => s.MoveToRoomX("room_12")
                                }
                        },
                        { Function.East, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInPack("#GOLD"),
                                        t => t.PrintMessageX(Resources.DomeUnclimbable)
                                    }),
                                    s => s.MoveToRoomX("room_12")
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Out, new Script { s => s.MoveToRoomX("room_13") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_13") } },
                    }
                }
            },
            {
                "room_15",
                new Room()
                {
                    ShortDescription = "East bank of bottomless pit",
                    Description = Resources.Room15,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_13") } },
                        { Function.Jump, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#bridge_15"),
                                        t => t.PrintMessageX(Resources.CrossDontJump)
                                    }),
                                    s => s.PrintMessageX(Resources.DidntMakeIt),
                                    s => s.PlayerDied()
                                }
                        },
                        { Function.West, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#bridge_15"),
                                        t => t.MoveToRoomX("room_18")
                                    }),
                                    s => s.PrintMessageX(Resources.CantCrossPit),
                                }
                        },
                        { Function.Cross, new Script
                                {
                                    s => s.AssertItemXIsInCurrentRoomOrPack("#bridge_15"),
                                    s => s.MoveToRoomX("room_18")
                                }
                        },
                        { Function.Wave, new Script
                                {
                                    s => s.AssertItemXMatchesUserInput("#SCEPTER"),
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#bridge_15"),
                                        t => t.MoveItemXToRoomY("#bridge_15", "room_0"),
                                        t => t.MoveItemXToRoomY("#bridge_18", "room_0"),
                                        t => t.PrintMessageX(Resources.BridgeRetracted)
                                    }),
                                    s => s.MoveItemXToCurrentRoom("#bridge_15"),
                                    s => s.MoveItemXToRoomY("#bridge_18", "room_18"),
                                    s => s.PrintMessageX(Resources.BridgeAppears)
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_13") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_13") } },
                        { Function.South, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#SERPENT"),
                                        t => t.PrintMessageX(Resources.SerpentBlocks)
                                    }),
                                    s => s.MoveToRoomX("room_17")
                                }
                        },
                        { Function.North, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#SERPENT"),
                                        t => t.PrintMessageX(Resources.SerpentBlocks)
                                    }),
                                    s => s.MoveToRoomX("room_25")
                                }
                        },
                        { Function.West, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#SERPENT"),
                                        t => t.PrintMessageX(Resources.SerpentBlocks)
                                    }),
                                    s => s.MoveToRoomX("room_24")
                                }
                        },
                        { Function.Throw, new Script
                                {
                                    s => s.AssertItemXMatchesUserInput("#BIRD_boxed"),
                                    s => s.AssertItemXIsInCurrentRoomOrPack("#SERPENT"),
                                    s => s.MoveItemXToRoomY("#SERPENT", "room_0"),
                                    s => s.MoveItemXToCurrentRoom("#BIRD"),
                                    s => s.MoveItemXToRoomY("#BIRD_boxed", "room_0"),
                                    s => s.PrintMessageX(Resources.BirdAlive),
                                    s => s.AwardAchievementX("DefeatSerpent")
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.North, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_16") } },
                    }
                }
            },
            {
                "room_18",
                new Room()
                {
                    ShortDescription = "West side of bottomless pit",
                    Description = Resources.Room18,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Jump, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#bridge_18"),
                                        t => t.PrintMessageX(Resources.CrossDontJump)
                                    }),
                                    s => s.PrintMessageX(Resources.DidntMakeIt),
                                    s => s.PlayerDied()
                                }
                        },
                        { Function.East, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#bridge_18"),
                                        t => t.MoveToRoomX("room_15")
                                    }),
                                    s => s.PrintMessageX(Resources.CantCrossPit)
                                }
                        },
                        { Function.North, new Script
                                {
                                    s => s.PrintMessageX(Resources.CrawlToPassage),
                                    s => s.MoveToRoomX("room_19")
                                }
                        },
                        { Function.Cross, new Script
                                {
                                    s => s.AssertItemXIsInCurrentRoomOrPack("#bridge_18"),
                                    s => s.MoveToRoomX("room_15")
                                }
                        },
                        { Function.Wave, new Script
                                {
                                    s => s.AssertItemXMatchesUserInput("#SCEPTER"),
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#bridge_18"),
                                        t => t.MoveItemXToRoomY("#bridge_18", "room_0"),
                                        t => t.MoveItemXToRoomY("#bridge_15", "room_0"),
                                        t => t.PrintMessageX(Resources.BridgeRetracted)
                                    }),
                                    s => s.MoveItemXToCurrentRoom("#bridge_18"),
                                    s => s.MoveItemXToRoomY("#bridge_15", "room_15"),
                                    s => s.PrintMessageX(Resources.BridgeAppears)
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script { s => s.MoveToRoomX("room_28") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_28") } },
                        { Function.Climb, new Script { s => s.MoveToRoomX("room_28") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_18") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_18") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_20") } },
                    }
                }
            },
            {
                "room_20",
                new Room()
                {
                    ShortDescription = "East end of very long hall",
                    Description = Resources.Room20,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_19") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_19") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_21") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_22") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_22") } },
                    }
                }
            },
            {
                "room_21",
                new Room()
                {
                    ShortDescription = "West end of very long hall",
                    Description = Resources.Room21,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_20") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_22") } },
                    }
                }
            },
            {
                "room_22",
                new Room()
                {
                    ShortDescription = "Crossover of high N/S and low E/W",
                    Description = Resources.Room22,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.West, new Script { s => s.MoveToRoomX("room_20") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_23") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_24") } },
                        { Function.South, new Script { s => s.MoveToRoomX("room_21") } },
                    }
                }
            },
            {
                "room_23",
                new Room()
                {
                    ShortDescription = "Dead end",
                    Description = Resources.DeadEnd,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script { s => s.MoveToRoomX("room_22") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_22") } },
                    }
                }
            },
            {
                "room_24",
                new Room()
                {
                    ShortDescription = "West throne chamber",
                    Description = Resources.Room24,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_22") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_22") } },
                    }
                }
            },
            {
                "room_25",
                new Room()
                {
                    ShortDescription = "Low N/S passage at hole in floor",
                    Description = Resources.Room25,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Out, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.South, new Script { s => s.MoveToRoomX("room_16") } },
                        { Function.North, new Script { s => s.MoveToRoomX("room_26") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_54") } },
                    }
                }
            },
            {
                "room_26",
                new Room()
                {
                    ShortDescription = "Large room with panel",
                    Description = Resources.Room26,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Panel, new Script { s => s.MoveToRoomX("room_2") } },
                        { Function.South, new Script{ s => s.MoveToRoomX("room_25") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_27") } },
                    }
                }
            },
            {
                "room_27",
                new Room()
                {
                    ShortDescription = "Chamber of Anubis",
                    Description = Resources.Room27,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Down, new Script { s => s.MoveToRoomX("room_26") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_13") } },
                    }
                }
            },
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
            {
                "room_54",
                new Room()
                {
                    ShortDescription = "Dirty broken passage",
                    Description = Resources.Room54,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_55") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_57") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_25") } },
                    }
                }
            },
            {
                "room_55",
                new Room()
                {
                    ShortDescription = "Brink of small clean pit",
                    Description = Resources.Room55,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.West, new Script { s => s.MoveToRoomX("room_54") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_56") } },
                        { Function.Climb, new Script { s => s.MoveToRoomX("room_56") } },
                    }
                }
            },
            {
                "room_56",
                new Room()
                {
                    ShortDescription = "Bottom of small pit with stream",
                    Description = Resources.Room56,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_55") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_55") } },
                        { Function.Climb, new Script { s => s.MoveToRoomX("room_55") } },
                        { Function.Down, new Script { s => s.PrintMessageX(Resources.CantFitThroughTwoInchSlit) } },
                        { Function.Fill, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInPack("#WATER"),
                                        t => t.PrintMessageX(Resources.BottleAlreadyFull)
                                    }),
                                    s => s.MoveItemXToLocationY("#WATER", "#BOTTLE")
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_54") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_58") } },
                    }
                }
            },
            {
                "room_58",
                new Room()
                {
                    ShortDescription = "Complex Junction",
                    Description = Resources.Room58,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.North, new Script { s => s.MoveToRoomX("room_61") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_59") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_65") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_57") } },
                        { Function.Climb, new Script { s => s.MoveToRoomX("room_57") } },
                    }
                }
            },
            {
                "room_59",
                new Room()
                {
                    ShortDescription = "Anteroom of Seker",
                    Description = Resources.Room59,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_60") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_65") } },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_58") } },
                    }
                }
            },
            {
                "room_60",
                new Room()
                {
                    ShortDescription = "Land of the dead",
                    Description = Resources.Room60,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.North, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.East, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.South, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.NorthEast, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.SouthEast, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.SouthWest, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.NorthWest, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.Up, new Script {
                            s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("240") }),
                            s => s.MoveToRoomX("room_59") }
                        },
                        { Function.West, new Script {
                            s => s.PrintMessageX(Resources.CrawledAround),
                            s => s.MoveToRoomX("room_60") }
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInPack("#SARCOPH_full"),
                                        t => t.PrintMessageX(Resources.SarcophagusDoesntFit)
                                    }),
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInPack("#SARCOPH_empty"),
                                        t => t.PrintMessageX(Resources.SarcophagusDoesntFit)
                                    }),
                                    s => s.MoveToRoomX("room_58")
                                }
                        },
                        { Function.Up, new Script { s => s.MoveToRoomX("room_62") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_63") } },
                    }
                }
            },
            {
                "room_62",
                new Room()
                {
                    ShortDescription = "Chamber of Khons",
                    Description = Resources.Room62,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Down, new Script { s => s.MoveToRoomX("room_61") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_61") } },
                    }
                }
            },
            {
                "room_63",
                new Room()
                {
                    ShortDescription = "Long sloping corridor",
                    Description = Resources.Room63,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_61") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_64") } },
                    }
                }
            },
            {
                "room_64",
                new Room()
                {
                    ShortDescription = "Cul-de-sac",
                    Description = Resources.Room64,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_63") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_63") } },
                    }
                }
            },
            {
                "room_65",
                new Room()
                {
                    ShortDescription = "Chamber of Horus",
                    Description = Resources.Room65,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_58") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_78") } },
                        { Function.Up, new Script { s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("204") }), s => s.MoveToRoomX("room_72") } },
                        { Function.North, new Script { s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("204") }), s => s.MoveToRoomX("room_73") } },
                        { Function.South, new Script { s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("204") }), s => s.MoveToRoomX("room_66") } },
                        { Function.Down, new Script { s => s.SubScriptXAbortIfPass(new Script { t => t.AssertRandomIsGreaterThanX("204") }), s => s.MoveToRoomX("room_59") } },
                    }
                }
            },
            {
                "room_66",
                new Room()
                {
                    ShortDescription = "Large low circular chamber",
                    Description = Resources.Room66,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.North, new Script { s => s.MoveToRoomX("room_65") } },
                        { Function.South, new Script { s => s.MoveToRoomX("room_80") } },
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script { s => s.MoveToRoomX("room_71") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_71") } },
                    }
                }
            },
            {
                "room_70",
                new Room()
                {
                    ShortDescription = "Fallen block",
                    Description = Resources.Room70,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.South, new Script { s => s.MoveToRoomX("room_71") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_71") } },
                    }
                }
            },
            {
                "room_71",
                new Room()
                {
                    ShortDescription = "Chamber of Osiris",
                    Description = Resources.Room71,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.North, new Script { s => s.MoveToRoomX("room_68") } },
                        { Function.East, new Script { s => s.MoveToRoomX("room_70") } },
                        { Function.South, new Script { s => s.MoveToRoomX("room_77") } },
                    }
                }
            },
            {
                "room_72",
                new Room()
                {
                    ShortDescription = "Priest's bedroom",
                    Description = Resources.Room72,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.West, new Script { s => s.MoveToRoomX("room_65") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_65") } },
                    }
                }
            },
            {
                "room_73",
                new Room()
                {
                    ShortDescription = "Chamber of high priest",
                    Description = Resources.Room73,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.West, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertPackIsEmptyExceptForEmerald(),
                                        t => t.MoveToRoomX("room_76")
                                    }),
                                    s => s.PrintMessageX(Resources.DropSomething)
                                }
                        },
                        { Function.SouthEast, new Script { s => s.MoveToRoomX("room_65") } },
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertPackIsEmptyExceptForEmerald(),
                                        t => t.MoveToRoomX("room_73")
                                    }),
                                    s => s.PrintMessageX(Resources.DropSomething)
                                }
                        },
                        { Function.Out, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertPackIsEmptyExceptForEmerald(),
                                        t => t.MoveToRoomX("room_76")
                                    }),
                                    s => s.PrintMessageX(Resources.DropSomething)
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
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_81") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_81") } },
                        { Function.Climb, new Script { s => s.MoveToRoomX("room_81") } },
                        { Function.Jump, new Script { s => s.PrintMessageX(Resources.BrokenNeck),
                                                      s => s.PlayerDied() } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_71") } },
                    }
                }
            },
            {
                "room_78",
                new Room()
                {
                    ShortDescription = "East end of twopit room",
                    Description = Resources.Room78,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_65") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_80") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_79") } },
                    }
                }
            },
            {
                "room_79",
                new Room()
                {
                    ShortDescription = "Bottom of eastern pit",
                    Description = Resources.Room79,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_78") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_78") } },
                    }
                }
            },
            {
                "room_80",
                new Room()
                {
                    ShortDescription = "West end of twopit room",
                    Description = Resources.Room80,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.East, new Script { s => s.MoveToRoomX("room_78") } },
                        { Function.West, new Script { s => s.MoveToRoomX("room_66") } },
                        { Function.Down, new Script { s => s.MoveToRoomX("room_81") } },
                    }
                }
            },
            {
                "room_81",
                new Room()
                {
                    ShortDescription = "Bottom of western pit",
                    Description = Resources.Room81,
                    Commands = new Dictionary<Function, Script>()
                    {
                        { Function.Up, new Script { s => s.MoveToRoomX("room_80") } },
                        { Function.Out, new Script { s => s.MoveToRoomX("room_80") } },
                        { Function.Climb, new Script
                                {
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#PLANT_C"),
                                        t => t.PrintMessageX(Resources.ClimbPlant),
                                        t => t.MoveToRoomX("room_77")
                                    }),
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#PLANT_B"),
                                        t => t.PrintMessageX(Resources.ClimbedPlant)
                                    }),
                                    s => s.MoveToRoomX("room_80"),
                                    s => s.PrintMessageX(Resources.NothingToClimb)
                                }
                        },
                        { Function.Pour, new Script
                                {
                                    s => s.AssertItemXMatchesUserInput("#WATER"),
                                    s => s.MoveItemXToRoomY("#WATER", "room_0"),
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#PLANT_A"),
                                        t => t.MoveItemXToRoomY("#PLANT_A", "room_0"),
                                        t => t.MoveItemXToCurrentRoom("#PLANT_B"),
                                        t => t.PrintMessageX(Resources.PlantSpurts),
                                        t => t.PrintMessageX(Resources.PlantBellowing)
                                    }),
                                    s => s.SubScriptXAbortIfPass(new Script
                                    {
                                        t => t.AssertItemXIsInCurrentRoomOrPack("#PLANT_B"),
                                        t => t.MoveItemXToRoomY("#PLANT_B", "room_0"),
                                        t => t.MoveItemXToCurrentRoom("#PLANT_C"),
                                        t => t.PrintMessageX(Resources.PlantGrows),
                                        t => t.PrintMessageX(Resources.GiganticBeanStalk)
                                    }),
                                    s => s.MoveItemXToRoomY("#PLANT_C", "room_0"),
                                    s => s.MoveItemXToCurrentRoom("#PLANT_A"),
                                    s => s.PrintMessageX(Resources.OverwateredPlant),
                                    s => s.PrintMessageX(Resources.PlantMurmuring)
                                }
                        },
                    }
                }
            },
        };
    }
}