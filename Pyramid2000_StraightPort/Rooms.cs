using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
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
                    Description = "YOU ARE STANDING BEFORE THE ENTRANCE OF A PYRAMID. AROUND YOU IS A DESERT.",
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
                    Description = "YOU ARE IN THE ENTRANCE TO THE PYRAMID. A HOLE IN THE FLOOR LEADS TO A PASSAGE BENEATH THE SURFACE.",
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
                    Description = "YOU ARE IN THE DESERT.",
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
                    Description = "YOU ARE IN THE DESERT.",
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
                    Description = "YOU ARE IN THE DESERT.",
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
                    Description = "YOU ARE IN THE DESERT.",
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
                    Description = "YOU ARE IN A SMALL CHAMBER BENEATH A HOLE FROM THE SURFACE. A LOW CRAWL LEADS INWARD TO THE WEST.  HIEROGLYPHICS ON THE WALL TRANSLATE, \"CURSE ALL WHO ENTER THIS SACRED CRYPT.\".",
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
                    Description = "YOU ARE CRAWLING OVER PEBBLES IN A LOW PASSAGE. THERE IS A DIM LIGHT AT THE EAST END OF THE PASSAGE.",
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
                    Description = "YOU ARE IN A ROOM FILLED WITH BROKEN POTTERY SHARDS OF ANCIENT EGYPTIAN CRAFTS. AN AWKWARD CORRIDOR LEADS UPWARD AND WEST.",
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
                    Description = "YOU ARE IN AN AWKWARD SLOPING EAST/WEST CORRIDOR.",
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
                    Description = "YOU ARE IN A SPLENDID CHAMBER THIRTY FEET HIGH. THE WALLS ARE FROZEN RIVERS OF ORANGE STONE. AN AWKWARD CORRIDOR AND A GOOD PASSAGE EXIT FROM THE EAST AND WEST SIDES OF THE CHAMBER.",
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
                    Description = "AT YOUR FEET IS A SMALL PIT BREATHING TRACES OF WHITE MIST. AN EAST PASSAGE ENDS HERE EXCEPT FOR A SMALL CRACK LEADING ON. ROUGH STONE STEPS LEAD DOWN THE PIT.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_11" } },
                        { "_d", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#GOLD",
                                        "PrintMessageX", "YOU ARE AT THE BOTTOM OF THE PIT WITH A BROKEN NECK.",
                                        "PlayerDied"
                                    },
                                    "MoveToRoomX", "room_13"
                                }
                        },
                        { "_w", new List<object> { "PrintMessageX", "THE CRACK IS FAR TOO SMALL FOR YOU TO FOLLOW." } },
                    }
                }
            },
            {
                "room_13",
                new Room()
                {
                    Description = "YOU ARE AT ONE END OF A VAST HALL STRETCHING FORWARD OUT OF SIGHT TO THE WEST. THERE ARE OPENINGS TO EITHER SIDE. NEARBY, A WIDE STONE STAIRCASE LEADS DOWNWARD. THE HALL IS VERY MUSTY AND A COLD WIND BLOWS UP THE STAIRCASE. THERE IS A PASSAGE AT THE TOP OF A DOME BEHIND YOU. ROUGH STONE STEPS LEAD UP THE DOME.",
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
                                        "PrintMessageX", "THE DOME IS UNCLIMBABLE."
                                    },
                                    "MoveToRoomX", "room_12"
                                }
                        },
                        { "_e", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#GOLD",
                                        "PrintMessageX", "THE DOME IS UNCLIMBABLE."
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
                    Description = @"THIS IS A LOW ROOM WITH A HIEROGLYPH ON THE WALL. IT TRANSLATES ""YOU WON'T GET IT UP THE STEPS"".",
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
                    Description = "YOU ARE ON THE EAST BANK OF A BOTTOMLESS PIT STRETCHING ACROSS THE HALL. THE MIST IS QUITE THICK HERE, AND THE PIT IS TOO WIDE TO JUMP.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_jump", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_15",
                                        "PrintMessageX", "I RESPECTFULLY SUGGEST YOU GO ACROSS THE BRIDGE INSTEAD OF JUMPING."
                                    },
                                    "PrintMessageX","YOU DIDN'T MAKE IT.",
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
                                    "PrintMessageX", "THERE IS NO WAY ACROSS THE BOTTOMLESS PIT."
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
                                        "PrintMessageX", "THE STONE BRIDGE HAS RETRACTED!"
                                    },
                                    "MoveItemXToCurrentRoom", "#bridge_15",
                                    "MoveItemXToRoomY", "#bridge_18", "room_18",
                                    "PrintMessageX", "A STONE BRIDGE NOW SPANS THE BOTTOMLESS PIT."
                                }
                        },
                    }
                }
            },
            {
                "room_16",
                new Room()
                {
                    Description = "YOU ARE IN THE PHARAOH'S CHAMBER, WITH PASSAGES OFF IN ALL DIRECTIONS.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_e", new List<object> { "MoveToRoomX", "room_13" } },
                        { "_s", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", "YOU CAN'T GET BY THE SERPENT."
                                    },
                                    "MoveToRoomX", "room_17"
                                }
                        },
                        { "_n", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", "YOU CAN'T GET BY THE SERPENT."
                                    },
                                    "MoveToRoomX", "room_25"
                                }
                        },
                        { "_w", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#SERPENT",
                                        "PrintMessageX", "YOU CAN'T GET BY THE SERPENT."
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
                                    "PrintMessageX", "THE BIRD STATUE COMES TO LIFE AND ATTACKS THE SERPENT AND IN AN ASTOUNDING FLURRY, DRIVES THE SERPENT AWAY. THE BIRD TURNS BACK INTO A STATUE."
                                }
                        },
                    }
                }
            },
            {
                "room_17",
                new Room()
                {
                    Description = "YOU ARE IN THE SOUTH SIDE CHAMBER.",
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
                    Description = "YOU ARE ON THE WEST SIDE OF THE BOTTOMLESS PIT IN THE HALL OF GODS.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_jump", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#bridge_18",
                                        "PrintMessageX", "I RESPECTFULLY SUGGEST YOU GO ACROSS THE BRIDGE INSTEAD OF JUMPING."
                                    },
                                    "PrintMessageX", "YOU DIDN'T MAKE IT.",
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
                                    "PrintMessageX", "THERE IS NO WAY ACROSS THE BOTTOMLESS PIT."
                                }
                        },
                        { "_n", new List<object>
                                {
                                    "PrintMessageX", "YOU HAVE CRAWLED THROUGH A VERY LOW WIDE PASSAGE PARALLEL TO AND NORTH OF THE HALL OF GODS.",
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
                                        "PrintMessageX", "THE STONE BRIDGE HAS RETRACTED!"
                                    },
                                    "MoveItemXToCurrentRoom", "#bridge_18",
                                    "MoveItemXToRoomY", "#bridge_15", "room_15",
                                    "PrintMessageX", "A STONE BRIDGE NOW SPANS THE BOTTOMLESS PIT."
                                }
                        },
                    }
                }
            },
            {
                "room_19",
                new Room()
                {
                    Description = "YOU ARE AT THE WEST END OF THE HALL OF GODS. A LOW WIDE PASS CONTINUES WEST AND ANOTHER GOES NORTH. TO THE SOUTH IS A LITTLE PASSAGE SIX FEET OFF THE FLOOR.",
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
                    Description = "YOU ARE AT EAST END OF A VERY LONG HALL APPARENTLY WITHOUT SIDE CHAMBERS. TO THE EAST A LOW WIDE CRAWL SLANTS UP. TO THE NORTH A ROUND TWO FOOT HOLE SLANTS DOWN.",
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
                    Description = "YOU ARE AT THE WEST END OF A VERY LONG FEATURELESS HALL. THE HALL JOINS UP WITH A NARROW NORTH/SOUTH PASSAGE.",
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
                    Description = "YOU ARE AT A CROSSOVER OF A HIGH N/S PASSAGE AND A LOW E/W ONE.",
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
                    Description = "DEAD END.",
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
                    Description = "YOU ARE IN THE WEST THRONE CHAMBER. A PASSAGE CONTINUES WEST AND UP FROM HERE.",
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
                    Description = "YOU ARE IN A LOW N/S PASSAGE AT A HOLE IN THE FLOOR. THE HOLE GOES DOWN TO AN E/W PASSAGE.",
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
                    Description = "YOU ARE IN A LARGE ROOM, WITH A PASSAGE TO THE SOUTH, AND A WALL OF BROKEN ROCK TO THE EAST. THERE IS A PANEL ON THE NORTH WALL.",
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
                    Description = "YOU ARE IN THE CHAMBER OF ANUBIS.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "YOU ARE IN A MAZE OF TWISTY PASSAGES, ALL ALIKE.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
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
                    Description = "DEAD END.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object> { "MoveToRoomX", "room_29" } },
                        { "_drop", new List<object>
                                {
                                    "AssertItemXMatchesUserInput", "#COINS",
                                    "MoveItemXToRoomY", "#COINS", "room_0",
                                    "MoveItemXToCurrentRoom", "#BATTERIES_fresh",
                                    "PrintMessageX", "THERE ARE NOW SOME FRESH BATTERIES HERE."                                    
                                }
                        }
                    }
                }
            },
            {
                "room_52",
                new Room()
                {
                    Description = "YOU ARE ON THE BRINK OF A LARGE PIT. YOU COULD CLIMB DOWN, BUT YOU WOULD NOT BE ABLE TO CLIMB BACK UP. THE MAZE CONTINUES ON THIS LEVEL.",
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
                    Description = "DEAD END.",
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
                    Description = "YOU ARE IN A DIRTY BROKEN PASSAGE. TO THE EAST IS A CRAWL. TO THE WEST IS A LARGE PASSAGE. ABOVE YOU IS A HOLE TO ANOTHER PASSAGE.",
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
                    Description = "YOU ARE ON THE BRINK OF A SMALL CLEAN CLIMBABLE PIT. A CRAWL LEADS WEST.",
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
                    Description = "YOU ARE IN THE BOTTOM OF A SMALL PIT WITH A LITTLE STREAM, WHICH ENTERS AND EXITS THROUGH TINY SLITS.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_55" } },
                        { "_d", new List<object> { "PrintMessageX", "YOU DON'T FIT THROUGH TWO-INCH SLIT!" } },
                        { "_fill", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#WATER",
                                        "PrintMessageX", "YOUR BOTTLE IS ALREADY FULL."
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
                    Description = "YOU ARE IN A THE ROOM OF BES, WHOSE PICTURE IS ON THE WALL. THERE IS A BIG HOLE IN THE FLOOR. THERE IS A PASSAGE LEADING EAST.",
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
                    Description = "YOU ARE AT A COMPLEX JUNCTION. A LOW HANDS AND KNEES PASSAGE FROM THE NORTH JOINS A HIGHER CRAWL FROM THE EAST TO MAKE A WALKING PASSAGE GOING WEST. THERE IS ALSO A LARGE ROOM ABOVE. THE AIR IS DAMP HERE.",
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
                    Description = @"YOU ARE IN THE UNDERWORLD ANTEROOM OF SEKER. PASSAGES GO EAST, WEST, AND UP. HUMAN BONES ARE STREWN ABOUT ON THE FLOOR. HIEROGLYPHICS ON THE WALL ROUGHLY TRANSLATE TO ""THOSE WHO PROCEED EAST MAY NEVER RETURN.""",
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
                    Description = "YOU ARE AT THE LAND OF DEAD. PASSAGES LEAD OFF IN >ALL< DIRECTIONS.",
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
                            "PrintMessageX", "YOU HAVE CRAWLED AROUND IN SOME LITTLE HOLES AND FOUND YOUR WAY BLOCKED BY A FALLEN SLAB. YOU ARE NOW BACK IN THE MAIN PASSAGE.",
                            "MoveToRoomX", "room_60" }
                        },
                    }
                }
            },
            {
                "room_61",
                new Room()
                {
                    Description = "YOU'RE IN A LARGE ROOM WITH ANCIENT DRAWINGS ON ALL WALLS. THE PICTURES DEPICT ATUM, A PHARAOH WEARING THE DOUBLE CROWN. A SHALLOW PASSAGE PROCEEDS DOWNWARD, AND A SOMEWHAT STEEPER ONE LEADS UP. A LOW HANDS AND KNEES PASSAGE ENTERS FROM THE SOUTH. ",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_s", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#SARCOPH_full",
                                        "PrintMessageX", "YOU CAN'T FIT THIS BIG SARCOPHAGUS THROUGH THAT LITTLE PASSAGE!"
                                    },
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInPack", "#SARCOPH_empty",
                                        "PrintMessageX", "YOU CAN'T FIT THIS BIG SARCOPHAGUS THROUGH THAT LITTLE PASSAGE!"
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
                    Description = "YOU ARE IN A CHAMBER WHOSE WALL CONTAINS A PICTURE OF A MAN WEARING THE LUNAR DISK ON HIS HEAD.  HE IS THE GOD KHONS, THE MOON GOD.",
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
                    Description = "YOU ARE IN A LONG SLOPING CORRIDOR WITH RAGGED WALLS.",
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
                    Description = "YOU ARE IN A CUL-DE-SAC ABOUT EIGHT FEET ACROSS.",
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
                    Description = "YOU ARE IN THE CHAMBER OF HORUS, A LONG EAST/WEST PASSAGE WITH HOLES EVERYWHERE. TO EXPLORE AT RANDOM, SELECT NORTH, SOUTH, UP, OR DOWN.",
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
                    Description = "YOU ARE IN A LARGE LOW CIRCULAR CHAMBER WHOSE FLOOR IS AN IMMENSE SLAB FALLEN FROM THE CEILING. EAST AND WEST THERE ONCE WERE LARGE PASSAGES, BUT THEY ARE NOW FILLED WITH SAND. LOW SMALL PASSAGES GO NORTH AND SOUTH.",
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
                    Description = "YOU ARE IN THE CHAMBER OF NEKHEBET, A WOMAN WITH THE HEAD OF A VULTURE, WEARING THE CROWN OF EGYPT. A PASSAGE EXITS TO THE SOUTH.",
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
                    Description = "THE PASSAGE HERE IS BLOCKED BY A FALLEN BLOCK.",
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
                    Description = "YOU ARE IN THE CHAMBER OF OSIRIS. THE CEILING IS TOO HIGH UP FOR YOUR LAMP TO SHOW IT. PASSAGES LEAD EAST, NORTH, AND SOUTH.",
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
                    Description = "YOU ARE IN THE PRIEST'S BEDROOM. THE WALLS ARE COVERED WITH CURTAINS, THE FLOOR WITH A THICK PILE CARPET. MOSS COVERS THE CEILING.",
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
                    Description = "THIS IS THE CHAMBER OF THE HIGH PRIEST. ANCIENT DRAWINGS COVER THE WALLS. AN EXTREMELY TIGHT TUNNEL LEADS WEST. IT LOOKS LIKE A TIGHT SQUEEZE. ANOTHER PASSAGE LEADS SE.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_w", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_76"
                                    },
                                    "PrintMessageX", "SOMETHING YOU'RE CARRYING WON'T FIT THROUGH THE TUNNEL WITH YOU. YOU'D BEST TAKE INVENTORY AND DROP SOMETHING."
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
                    Description = "YOU ARE IN THE HIGH PRIEST'S TREASURE ROOM LIT BY AN EERIE GREEN LIGHT. A NARROW TUNNEL EXITS TO THE EAST.",
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
                                    "PrintMessageX", "SOMETHING YOU'RE CARRYING WON'T FIT THROUGH THE TUNNEL WITH YOU. YOU'D BEST TAKE INVENTORY AND DROP SOMETHING."
                                }
                        },
                        { "_out", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertPackIsEmptyExceptForEmerald",
                                        "MoveToRoomX", "room_76"
                                    },
                                    "PrintMessageX", "SOMETHING YOU'RE CARRYING WON'T FIT THROUGH THE TUNNEL WITH YOU. YOU'D BEST TAKE INVENTORY AND DROP SOMETHING."
                                }
                        },
                    }
                }
            },
            {
                "room_77",
                new Room()
                {
                    Description = "YOU ARE IN A LONG, NARROW CORRIDOR STRETCHING OUT OF SIGHT TO THE WEST. AT THE EASTERN END IS A HOLE THROUGH WHICH YOU CAN SEE A PROFUSION OF LEAVES.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_e", new List<object> { "MoveToRoomX", "room_81" } },
                        { "_d", new List<object> { "MoveToRoomX", "room_81" } },
                        { "_climb", new List<object> { "MoveToRoomX", "room_81" } },
                        { "_jump", new List<object> { "PrintMessageX", "YOU ARE AT THE BOTTOM OF THE PIT WITH A BROKEN NECK.",
                                                      "PlayerDied" } },
                        { "_w", new List<object> { "MoveToRoomX", "room_71" } },
                    }
                }
            },
            {
                "room_78",
                new Room()
                {
                    Description = "YOU ARE AT THE EAST END OF THE TWOPIT ROOM. THE FLOOR HERE IS LITTERED WITH THIN ROCK SLABS, WHICH MAKE IT EASY TO DESCEND THE PITS. THERE IS A PATH HERE BYPASSING THE PITS TO CONNECT PASSAGES EAST AND WEST. THERE ARE HOLES ALL OVER, BUT THE ONLY BIG ONE IS ON THE WALL DIRECTLY OVER THE WEST PIT WHERE YOU CAN'T GET TO IT.",
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
                    Description = "YOU ARE AT THE BOTTOM OF THE EASTERN PIT IN THE TWOPIT ROOM.",
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
                    Description = "YOU ARE AT THE WEST END OF THE TWOPIT ROOM. THERE IS A LARGE HOLE IN THE WALL ABOVE THE PIT AT THIS END OF THE ROOM.",
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
                    Description = "YOU ARE AT THE BOTTOM OF THE WEST PIT IN THE TWOPIT ROOM. THERE IS A LARGE HOLE IN THE WALL ABOUT TWENTY FIVE FEET ABOVE YOU.",
                    Commands = new Dictionary<string, List<object>>()
                    {
                        { "_u", new List<object> { "MoveToRoomX", "room_80" } },
                        { "_out", new List<object> { "MoveToRoomX", "room_80" } },
                        { "_climb", new List<object>
                                {
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_C",
                                        "PrintMessageX", "YOU CLAMBER UP THE PLANT AND SCURRY THROUGH THE HOLE AT THE TOP.",
                                        "MoveToRoomX", "room_77"
                                    },
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_B",
                                        "PrintMessageX", "YOU'VE CLIMBED UP THE PLANT AND OUT OF THE PIT."
                                    },
                                    "MoveToRoomX", "room_80",
                                    "PrintMessageX", "THERE IS NOTHING HERE TO CLIMB. USE UP OR OUT TO LEAVE THE PIT."
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
                                        "PrintMessageX", "THE PLANT SPURTS INTO FURIOUS GROWTH FOR A FEW SECONDS.",
                                        "PrintMessageX", @"THERE IS A TWELVE FOOT BEAN STALK STRETCHING UP OUT OF THE PIT, BELLOWING ""WATER... WATER..."""
                                    },
                                    "SubScriptXAbortIfPass", new List<object>
                                    {
                                        "AssertItemXIsInCurrentRoomOrPack", "#PLANT_B",
                                        "MoveItemXToRoomY", "#PLANT_B", "room_0",
                                        "MoveItemXToCurrentRoom", "#PLANT_C",
                                        "PrintMessageX", "THE PLANT GROWS EXPLOSIVELY, ALMOST FILLING THE BOTTOM OF THE PIT.",
                                        "PrintMessageX", "THERE IS A GIGANTIC BEAN STALK STRETCHING ALL THE WAY UP TO THE HOLE."
                                    },
                                    "MoveItemXToRoomY", "#PLANT_C", "room_0",
                                    "MoveItemXToCurrentRoom", "#PLANT_A",
                                    "PrintMessageX", "YOU'VE OVER-WATERED THE PLANT! IT'S SHRIVELING UP!",
                                    "PrintMessageX", @"THERE IS A TINY PLANT IN THE PIT, MURMURING ""WATER, WATER, ..."""
                                }
                        },
                    }
                }
            },






        };
    }
}
