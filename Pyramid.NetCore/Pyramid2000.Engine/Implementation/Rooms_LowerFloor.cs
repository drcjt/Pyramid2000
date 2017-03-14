using System.Collections.Generic;
using System.Linq;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    partial class Rooms : IRooms
    {
        private IDictionary<string, Room> BuildRooms_LowerFloor()
        {
            return new Dictionary<string, Room>()
            {
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
}