using System.Collections.Generic;
using System.Linq;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    partial class Rooms : IRooms
    {
        private IDictionary<string, Room> BuildRooms_UpperFloor()
        {
            return new Dictionary<string, Room>()
            {
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
            };
        }
    }
}