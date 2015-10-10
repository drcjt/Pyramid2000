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
        private IDictionary<Function, List<object>> _defaultHandler = new Dictionary<Function, List<object>>()
        {
            {
                Function.North, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.East, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.South, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.West, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.NorthEast, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.SouthEast, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.SouthWest, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.NorthWest, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.Up, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.Down, new List<object> { "PrintMessageX", Resources.NoWayToGoThatDirection }
            },
            {
                Function.In, new List<object> { "PrintMessageX", Resources.UseCompassPoints }
            },
            {
                Function.Out, new List<object> { "PrintMessageX", Resources.UseCompassPoints }
            },
            {
                Function.Left, new List<object> { "PrintMessageX", Resources.UnsureHowYouAreFacing }
            },
            {
                Function.Right, new List<object> { "PrintMessageX", Resources.UnsureHowYouAreFacing }
            },
            {
                Function.Panel, new List<object> { "PrintMessageX", Resources.NothingHappens }
            },
            {
                Function.Back, new List<object> { "MoveToLastRoom" }
            },
            {
                Function.Swim, new List<object> { "PrintMessageX", Resources.DontKnowHow }
            },
            {
                Function.On, new List<object>
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
                Function.Off, new List<object>
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
                Function.Quit, new List<object> { "Quit" }
            },
            {
                Function.Score, new List<object> { "PrintScore" }
            },
            {
                Function.Inventory, new List<object> { "PrintInventory" }
            },
            {
                Function.Look, new List<object> { "PrintRoomDescription" }
            },
            {
                Function.Get, new List<object>
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
                Function.Drop, new List<object>
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
                Function.Throw, new List<object>
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
                Function.Open, new List<object>
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
                Function.Wave, new List<object> { "PrintMessageX", Resources.NothingHappens }
            },
            {
                Function.Pour, new List<object>
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
                Function.Rub, new List<object>
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
                Function.Fill, new List<object>
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
                Function.Attack, new List<object>
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
                Function.Break, new List<object> { "PrintMessageX", Resources.BeyondYourPower }
            },
            {
                Function.Eat, new List<object>
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
                Function.Drink, new List<object>
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
                Function.Feed, new List<object>
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
                        "AssertItemXMatchesUserInput", "#SERPENT",
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
                Function.Plugh, new List<object> { "JumpToTopOfGameLoop" }
            },
            {
                Function.Load, new List<object> { "LoadGame" }
            },
            {
                Function.Save, new List<object> { "SaveGame" }
            },
            {
                Function.Help, new List<object> { "PrintMessageX", Resources.Help }
            }
        };

        public List<object> GetDefaultScript(Function verb)
        {
            if (_defaultHandler.ContainsKey(verb))
            {
                return _defaultHandler[verb];
            }

            return null;
        }
    }
}
