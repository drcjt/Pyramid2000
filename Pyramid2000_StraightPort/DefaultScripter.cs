using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
{
    public class DefaultScripter : IDefaultScripter
    {
        private IDictionary<string, List<object>> _defaultHandler = new Dictionary<string, List<object>>()
        {
            {
                "_n", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_e", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_s", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_w", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_ne", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_se", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_sw", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_nw", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_u", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_d", new List<object> { "PrintMessageX", "THERE IS NO WAY FOR YOU TO GO THAT DIRECTION." }
            },
            {
                "_in", new List<object> { "PrintMessageX", "I DON'T KNOW IN FROM OUT HERE. USE COMPASS POINTS." }
            },
            {
                "_out", new List<object> { "PrintMessageX", "I DON'T KNOW IN FROM OUT HERE. USE COMPASS POINTS." }
            },
            {
                "_left", new List<object> { "PrintMessageX", "I AM UNSURE HOW YOU ARE FACING. USE COMPASS POINTS." }
            },
            {
                "_right", new List<object> { "PrintMessageX", "I AM UNSURE HOW YOU ARE FACING. USE COMPASS POINTS." }
            },
            {
                "_panel", new List<object> { "PrintMessageX", "NOTHING HAPPENS." }
            },
            {
                "_back", new List<object> { "MoveToLastRoom" }
            },
            {
                "_swim", new List<object> { "PrintMessageX", "I DON'T KNOW HOW." }
            },
            {
                "_on", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_off",
                        "MoveItemXToRoomY", "#LAMP_off", "room_0",
                        "MoveItemXToRoomY", "#LAMP_on", "pack",
                        "PrintMessageX", "YOUR LAMP IS NOW ON."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_on",
                        "PrintMessageX", "YOUR LAMP IS NOW ON."
                    },
                    "PrintMessageX", "YOU HAVE NO SOURCE OF LIGHT."
                }
            },
            {
                "_off", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_on",
                        "MoveItemXToRoomY", "#LAMP_on", "room_0",
                        "MoveItemXToRoomY", "#LAMP_off", "pack",
                        "PrintMessageX", "YOUR LAMP IS NOW OFF."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_off",
                        "PrintMessageX", "YOUR LAMP IS NOW OFF."
                    },
                    "PrintMessageX", "YOU HAVE NO SOURCE OF LIGHT."
                }
            },
            {
                "_quit", new List<object> { "Quit" }
            },
            {
                "_score", new List<object> { "PrintScore" }
            },
            {
                "_inv", new List<object> { "PrintInventory" }
            },
            {
                "_look", new List<object> { "PrintRoomDescription" }
            },
            {
                "_get", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#PLANT_A",
                        "PrintMessageX", "THE PLANT HAS EXCEPTIONALLY DEEP ROOTS AND CANNOT BE PULLED FREE."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#SCEPTER",
                            "PrintMessageX", "AS YOU APPROACH THE STATUE, IT COMES TO LIFE AND FLIES ACROSS THE CHAMBER WHERE IT LANDS AND RETURNS TO STONE."
                        },
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#BOX",
                            "MoveItemXToRoomY", "#BIRD", "room_0",
                            "MoveItemXToLocationY", "#BIRD_boxed", "#BOX"
                        },
                        "PrintMessageX", "YOU CAN LIFT THE STATUE, BUT YOU CANNOT CARRY IT."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#VASE_pillow",
                        "GetItemXFromRoom", "#VASE_solo",
                        "MoveItemXToRoomY", "#VASE_pillow", "room_0",
                        "MoveItemXToCurrentRoom", "#PILLOW"
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#stream_56",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#WATER",
                            "PrintMessageX", "YOUR BOTTLE IS ALREADY FULL."
                        },
                        "MoveItemXToLocationY", "#WATER", "#BOTTLE"
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#PILLOW",
                        "AssertItemXIsInCurrentRoom", "#VASE_pillow",
                        "MoveItemXToRoomY", "#VASE_pillow", "room_0",
                        "MoveItemXToCurrentRoom", "#VASE_solo",
                        "GetItemXFromRoom", "#PILLOW"
                    },
                    "GetUserInputItem"
                }
            },
            {
                "_drop", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#VASE_solo",
                        "MoveItemXToRoomY", "#VASE_solo", "room_0",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInCurrentRoom", "#PILLOW",
                            "MoveItemXToCurrentRoom", "#VASE_pillow",
                            "PrintMessageX", "THE VASE IS NOW RESTING, DELICATELY, ON A VELVET PILLOW."
                        },
                        "MoveItemXToCurrentRoom", "#POTTERY",
                        "PrintMessageX", "THE VASE DROPS WITH A DELICATE CRASH."
                    },
                    "DropUserInputItem"
                }
            },
            {
                "_throw", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#VASE_solo",
                        "MoveItemXToRoomY", "#VASE_solo", "room_0",
                        "MoveItemXToCurrentRoom", "#POTTERY",
                        "PrintMessageX", "YOU HAVE TAKEN THE VASE AND HURLED IT DELICATELY TO THE GROUND."
                    },
                    "DropUserInputItem"
                }
            },
            {
                "_open", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_full",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#SARCOPH_full",
                            "PrintMessageX", "I'D ADVISE YOU TO PUT DOWN THE SARCOPHAGUS BEFORE OPENING IT!!"
                        },
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#KEY",
                            "PrintMessageX", "A GLISTENING PEARL FALLS OUT OF THE SARCOPHAGUS AND ROLLS AWAY. THE SARCOPHAGUS SNAPS SHUT AGAIN.",
                            "MoveItemXToRoomY", "#PEARL", "room_64",
                            "MoveItemXToRoomY", "#SARCOPH_full", "room_0",
                            "MoveItemXToCurrentRoom", "#SARCOPH_empty",
                        },
                        "PrintMessageX", "YOU DON'T HAVE ANYTHING STRONG ENOUGH TO OPEN THE SARCOPHAGUS."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_empty",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#SARCOPH_empty",
                            "PrintMessageX", "I'D ADVISE YOU TO PUT DOWN THE SARCOPHAGUS BEFORE OPENING IT!!",
                        },
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#KEY",
                            "PrintMessageX", "THE SARCOPHAGUS CREAKS OPEN, REVEALING NOTHING INSIDE. IT PROMPTLY SNAPS SHUT AGAIN.",
                        },
                        "PrintMessageX", "YOU DON'T HAVE ANYTHING STRONG ENOUGH TO OPEN THE SARCOPHAGUS.",
                    },
                    "PrintMessageX", "I DON'T KNOW HOW TO LOCK OR UNLOCK SUCH A THING."
                }
            },
            {
                "_wave", new List<object> { "PrintMessageX", "NOTHING HAPPENS." }
            },
            {
                "_pour", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#WATER",
                        "MoveItemXToRoomY", "#WATER", "room_0",
                        "PrintMessageX", "YOUR BOTTLE IS EMPTY AND THE GROUND IS WET.",
                    },
                    "PrintMessageX","YOU CAN'T POUR THAT.",
                }
            },
            {
                "_rub", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#LAMP_off",
                        "PrintMessageX", "RUBBING THE ELECTRIC LAMP IS NOT PARTICULARLY REWARDING. ANYWAY, NOTHING EXCITING HAPPENS."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#LAMP_on",
                        "PrintMessageX", "RUBBING THE ELECTRIC LAMP IS NOT PARTICULARLY REWARDING. ANYWAY, NOTHING EXCITING HAPPENS."
                    },
                    "PrintMessageX", "PECULIAR. NOTHING UNEXPECTED HAPPENS."
                }
            },
            {
                "_fill", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BOTTLE",
                        "PrintMessageX", "THERE IS NOTHING HERE WITH WHICH TO FILL THE BOTTLE."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#VASE_solo",
                        "PrintMessageX", "DON'T BE RIDICULOUS!",
                    },
                    "PrintMessageX", "YOU CAN'T FILL THAT."
                }
            },
            {
                "_attack", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "MoveItemXToRoomY", "#BIRD", "room_0",
                        "PrintMessageX", "THE BIRD STATUE IS NOW DEAD. ITS BODY DISAPPEARS."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD_boxed",
                        "MoveItemXToRoomY", "#BIRD_boxed", "room_0",
                        "PrintMessageX", "THE BIRD STATUE IS NOW DEAD. ITS BODY DISAPPEARS."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_full",
                        "PrintMessageX", "THE STONE IS VERY STRONG AND IS IMPERVIOUS TO ATTACK."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_empty",
                        "PrintMessageX", "THE STONE IS VERY STRONG AND IS IMPERVIOUS TO ATTACK."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SERPENT",
                        "PrintMessageX", "ATTACKING THE SERPENT BOTH DOESN'T WORK AND IS VERY DANGEROUS."
                    },
                    "PrintMessageX", "YOU CAN'T BE SERIOUS!"
                }
            },
            {
                "_break", new List<object> { "PrintMessageX", "IT IS BEYOND YOUR POWER TO DO THAT." }
            },
            {
                "_eat", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#FOOD",
                        "MoveItemXToRoomY", "#FOOD", "room_0",
                        "PrintMessageX", "THANK YOU, IT WAS DELICIOUS!"
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#-10-",
                        "PrintMessageX", "I THINK I JUST LOST MY APPETITE."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "PrintMessageX", "I THINK I JUST LOST MY APPETITE."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD_boxed",
                        "PrintMessageX", "I THINK I JUST LOST MY APPETITE."
                    },
                    "PrintMessageX","DON'T BE RIDICULOUS!"
                }
            },
            {
                "_drink", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#WATER",
                        "MoveItemXToRoomY", "#WATER", "room_0",
                        "PrintMessageX", "THE BOTTLE IS NOW EMPTY."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#stream_56",
                        "PrintMessageX", "YOU HAVE TAKEN A DRINK FROM THE STREAM. THE WATER TASTES STRONGLY OF MINERALS, BUT IS NOT UNPLEASANT. IT IS EXTREMELY COLD."
                    },
                    "PrintMessageX", "YOU CAN'T BE SERIOUS!"
                }
            },
            {
                "_feed", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "PrintMessageX", "IT'S NOT HUNGRY. BESIDES, YOU HAVE NO BIRD SEED."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD_boxed",
                        "PrintMessageX", "IT'S NOT HUNGRY. BESIDES, YOU HAVE NO BIRD SEED."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertObjectXMatchesUserInput", "#SERPENT",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#BIRD_boxed",
                            "MoveItemXToRoomY", "#BIRD_boxed", "room_0",
                            "PrintMessageX", "THE SERPENT HAS NOW DEVOURED YOUR BIRD STATUE."
                        },
                        "PrintMessageX", "THERE IS NOTHING HERE IT WANTS TO EAT - EXCEPT PERHAPS YOU."
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_full",
                        "PrintMessageX", "I'M GAME. WOULD YOU CARE TO EXPLAIN HOW?"
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_empty",
                        "PrintMessageX", "I'M GAME. WOULD YOU CARE TO EXPLAIN HOW?"
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#-13-",
                        "PrintMessageX", "THERE IS NOTHING HERE IT WANTS TO EAT - EXCEPT PERHAPS YOU."
                    },
                    "PrintMessageX","DON'T BE RIDICULOUS!"
                }
            },
            {
                "_plugh", new List<object> { "JumpToTopOfGameLoop" }
            },
            {
                "_load", new List<object> { "LoadGame" }
            },
            {
                "_save", new List<object> { "SaveGame" }
            }
        };

        public List<object> GetDefaultScript(string verb)
        {
            if (_defaultHandler.ContainsKey(verb))
            {
                return _defaultHandler[verb];
            }

            return null;
        }
    }
}
