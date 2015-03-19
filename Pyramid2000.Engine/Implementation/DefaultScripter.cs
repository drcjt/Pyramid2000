using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class DefaultScripter : IDefaultScripter
    {
        private IDictionary<string, List<object>> _defaultHandler = new Dictionary<string, List<object>>()
        {
            {
                "_n", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_e", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_s", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_w", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_ne", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_se", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_sw", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_nw", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_u", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_d", new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                "_in", new List<object> { "PrintMessageX", Resources.UseCompassPoints }
            },
            {
                "_out", new List<object> { "PrintMessageX", Resources.UseCompassPoints }
            },
            {
                "_left", new List<object> { "PrintMessageX", Resources.UnsureHowYouAreFacing }
            },
            {
                "_right", new List<object> { "PrintMessageX", Resources.UnsureHowYouAreFacing }
            },
            {
                "_panel", new List<object> { "PrintMessageX", Resources.NothingHappens }
            },
            {
                "_back", new List<object> { "MoveToLastRoom" }
            },
            {
                "_swim", new List<object> { "PrintMessageX", Resources.DontKnowHow }
            },
            {
                "_on", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_off",
                        "MoveItemXToRoomY", "#LAMP_off", "room_0",
                        "MoveItemXToRoomY", "#LAMP_on", "pack",
                        "PrintMessageX", Resources.LampIsNowOn
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_on",
                        "PrintMessageX", Resources.LampIsNowOn
                    },
                    "PrintMessageX", Resources.NoSourceOfLight
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
                        "PrintMessageX", Resources.LampIsNowOff
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXIsInPack", "#LAMP_off",
                        "PrintMessageX", Resources.LampIsNowOff
                    },
                    "PrintMessageX", Resources.NoSourceOfLight
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
                        "PrintMessageX", Resources.PlantCantBePulledFree
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#SCEPTER",
                            "PrintMessageX", Resources.StatueComesToLife
                        },
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#BOX",
                            "MoveItemXToRoomY", "#BIRD", "room_0",
                            "MoveItemXToLocationY", "#BIRD_boxed", "#BOX"
                        },
                        "PrintMessageX", Resources.CantCarryStatue
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
                            "PrintMessageX", Resources.BottleAlreadyFull
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
                            "PrintMessageX", Resources.VaseRestingOnPillow
                        },
                        "MoveItemXToCurrentRoom", "#POTTERY",
                        "PrintMessageX", Resources.VaseDropsWithCrash
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
                        "PrintMessageX", Resources.VaseHurledToGround
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
                            "PrintMessageX", Resources.PutSarcophagusDown
                        },
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#KEY",
                            "PrintMessageX", Resources.PearlFallsOut,
                            "MoveItemXToRoomY", "#PEARL", "room_64",
                            "MoveItemXToRoomY", "#SARCOPH_full", "room_0",
                            "MoveItemXToCurrentRoom", "#SARCOPH_empty",
                        },
                        "PrintMessageX", Resources.NotStrongEnoughToOpenSarcophagus
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_empty",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#SARCOPH_empty",
                            "PrintMessageX", Resources.PutSarcophagusDown,
                        },
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#KEY",
                            "PrintMessageX", Resources.EmptySarcophagus,
                        },
                        "PrintMessageX", Resources.NotStrongEnoughToOpenSarcophagus,
                    },
                    "PrintMessageX", Resources.DontKnowHowToLockUnlock
                }
            },
            {
                "_wave", new List<object> { "PrintMessageX", Resources.NothingHappens }
            },
            {
                "_pour", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#WATER",
                        "MoveItemXToRoomY", "#WATER", "room_0",
                        "PrintMessageX", Resources.EmptyBottleWetGround,
                    },
                    "PrintMessageX", Resources.CantPourThat,
                }
            },
            {
                "_rub", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#LAMP_off",
                        "PrintMessageX", Resources.RubbingNothingHappens
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#LAMP_on",
                        "PrintMessageX", Resources.RubbingNothingHappens
                    },
                    "PrintMessageX", Resources.Peculiar
                }
            },
            {
                "_fill", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BOTTLE",
                        "PrintMessageX", Resources.NothingToFillBottleWith
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#VASE_solo",
                        "PrintMessageX", Resources.DontBeRidiculous,
                    },
                    "PrintMessageX", Resources.CantFillThat
                }
            },
            {
                "_attack", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "MoveItemXToRoomY", "#BIRD", "room_0",
                        "PrintMessageX", Resources.BirdStatueDead
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD_boxed",
                        "MoveItemXToRoomY", "#BIRD_boxed", "room_0",
                        "PrintMessageX", Resources.BirdStatueDead
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_full",
                        "PrintMessageX", Resources.StoneVeryStrong
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_empty",
                        "PrintMessageX", Resources.StoneVeryStrong
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SERPENT",
                        "PrintMessageX", Resources.AttackingSerpentFails
                    },
                    "PrintMessageX", Resources.CantBeSerious
                }
            },
            {
                "_break", new List<object> { "PrintMessageX", Resources.BeyondYourPower }
            },
            {
                "_eat", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#FOOD",
                        "MoveItemXToRoomY", "#FOOD", "room_0",
                        "PrintMessageX", Resources.Delicious
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#-10-",
                        "PrintMessageX", Resources.LostAppetite
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "PrintMessageX", Resources.LostAppetite
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD_boxed",
                        "PrintMessageX", Resources.LostAppetite
                    },
                    "PrintMessageX", Resources.DontBeRidiculous
                }
            },
            {
                "_drink", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#WATER",
                        "MoveItemXToRoomY", "#WATER", "room_0",
                        "PrintMessageX", Resources.EmptyBottle
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#stream_56",
                        "PrintMessageX", Resources.DrinkFromStream
                    },
                    "PrintMessageX", Resources.CantBeSerious
                }
            },
            {
                "_feed", new List<object>
                {
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD",
                        "PrintMessageX", Resources.BirdNotHungry
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#BIRD_boxed",
                        "PrintMessageX", Resources.BirdNotHungry
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertObjectXMatchesUserInput", "#SERPENT",
                        "SubScriptXAbortIfPass", new List<object>
                        {
                            "AssertItemXIsInPack", "#BIRD_boxed",
                            "MoveItemXToRoomY", "#BIRD_boxed", "room_0",
                            "PrintMessageX", Resources.SerpentEatenBird
                        },
                        "PrintMessageX", Resources.SerpentHasNothingToEat
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_full",
                        "PrintMessageX", Resources.ImGame
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#SARCOPH_empty",
                        "PrintMessageX", Resources.ImGame
                    },
                    "SubScriptXAbortIfPass", new List<object>
                    {
                        "AssertItemXMatchesUserInput", "#-13-",
                        "PrintMessageX", Resources.SerpentHasNothingToEat
                    },
                    "PrintMessageX", Resources.DontBeRidiculous
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
            },
            {
                "_help", new List<object> { "PrintMessageX", Resources.Help }
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
