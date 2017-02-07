using System.Collections.Generic;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    public class DefaultScripter : IDefaultScripter
    {
        private IResources Resources { get; set; }
        public DefaultScripter(IResources resources)
        {
            Resources = resources;
            BuildDefaultHandlers();
        }

        private IDictionary<Function, Script> _defaultHandler;
        
        private void BuildDefaultHandlers()
        {
            _defaultHandler = new Dictionary<Function, Script>()
            {
                {
                    Function.North, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.East, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.South, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.West, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.NorthEast, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.SouthEast, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.SouthWest, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.NorthWest, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.Up, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.Down, new Script { s => s.PrintMessageX(Resources.NoWayToGoThatDirection) }
                },
                {
                    Function.In, new Script { s => s.PrintMessageX(Resources.UseCompassPoints) }
                },
                {
                    Function.Out, new Script { s => s.PrintMessageX(Resources.UseCompassPoints) }
                },
                {
                    Function.Left, new Script { s => s.PrintMessageX(Resources.UnsureHowYouAreFacing) }
                },
                {
                    Function.Right, new Script { s => s.PrintMessageX(Resources.UnsureHowYouAreFacing) }
                },
                {
                    Function.Panel, new Script { s => s.PrintMessageX(Resources.NothingHappens) }
                },
                {
                    Function.Back, new Script { s => s.MoveToLastRoom() }
                },
                {
                    Function.Swim, new Script { s => s.PrintMessageX(Resources.DontKnowHow) }
                },
                {
                    Function.On, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXIsInPack("#LAMP_off"),
                            t => t.MoveItemXToRoomY("#LAMP_off", "room_0"),
                            t => t.MoveItemXToRoomY("#LAMP_on", "pack"),
                            t => t.PrintMessageX(Resources.LampIsNowOn)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXIsInPack("#LAMP_on"),
                            t => t.PrintMessageX(Resources.LampIsNowOn)
                        }),
                        s => s.PrintMessageX(Resources.NoSourceOfLight)
                    }
                },
                {
                    Function.Off, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXIsInPack("#LAMP_on"),
                            t => t.MoveItemXToRoomY("#LAMP_on", "room_0"),
                            t => t.MoveItemXToRoomY("#LAMP_off", "pack"),
                            t => t.PrintMessageX(Resources.LampIsNowOff)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXIsInPack("#LAMP_off"),
                            t => t.PrintMessageX(Resources.LampIsNowOff)
                        }),
                        s => s.PrintMessageX(Resources.NoSourceOfLight)
                    }
                },
                {
                    Function.Quit, new Script { s => s.Quit() }
                },
                {
                    Function.Score, new Script { s => s.PrintScore() }
                },
                {
                    Function.Inventory, new Script { s => s.PrintInventory() }
                },
                {
                    Function.Look, new Script { s => s.PrintRoomDescription() }
                },
                {
                    Function.Get, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#PLANT_A"),
                            t => t.PrintMessageX(Resources.PlantCantBePulledFree)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD"),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#SCEPTER"),
                                u => u.PrintMessageX(Resources.StatueComesToLife)
                            }),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#BOX"),
                                u => u.MoveItemXToRoomY("#BIRD", "room_0"),
                                u => u.MoveItemXToLocationY("#BIRD_boxed", "#BOX"),
                                u => u.AwardAchievementX("GetBird")
                            }),
                            t => t.PrintMessageX(Resources.CantCarryStatue)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#VASE_pillow"),
                            t => t.GetItemXFromRoom("#VASE_solo"),
                            t => t.MoveItemXToRoomY("#VASE_pillow", "room_0"),
                            t => t.MoveItemXToCurrentRoom("#PILLOW")
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#stream_56"),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#WATER"),
                                u => u.PrintMessageX(Resources.BottleAlreadyFull)
                            }),
                            t => t.MoveItemXToLocationY("#WATER", "#BOTTLE")
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#PILLOW"),
                            t => t.AssertItemXIsInCurrentRoom("#VASE_pillow"),
                            t => t.MoveItemXToRoomY("#VASE_pillow", "room_0"),
                            t => t.MoveItemXToCurrentRoom("#VASE_solo"),
                            t => t.GetItemXFromRoom("#PILLOW")
                        }),
                        s => s.GetUserInputItem()
                    }
                },
                {
                    Function.Drop, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#VASE_solo"),
                            t => t.MoveItemXToRoomY("#VASE_solo", "room_0"),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInCurrentRoom("#PILLOW"),
                                u => u.MoveItemXToCurrentRoom("#VASE_pillow"),
                                u => u.PrintMessageX(Resources.VaseRestingOnPillow)
                            }),
                            t => t.MoveItemXToCurrentRoom("#POTTERY"),
                            t => t.PrintMessageX(Resources.VaseDropsWithCrash)
                        }),
                        s => s.DropUserInputItem()
                    }
                },
                {
                    Function.Throw, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#VASE_solo"),
                            t => t.MoveItemXToRoomY("#VASE_solo", "room_0"),
                            t => t.MoveItemXToCurrentRoom("#POTTERY"),
                            t => t.PrintMessageX(Resources.VaseHurledToGround)
                        }),
                        s => s.DropUserInputItem()
                    }
                },
                {
                    Function.Open, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SARCOPH_full"),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#SARCOPH_full"),
                                u => u.PrintMessageX(Resources.PutSarcophagusDown)
                            }),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#KEY"),
                                u => u.PrintMessageX(Resources.PearlFallsOut),
                                u => u.MoveItemXToRoomY("#PEARL", "room_64"),
                                u => u.MoveItemXToRoomY("#SARCOPH_full", "room_0"),
                                u => u.MoveItemXToCurrentRoom("#SARCOPH_empty"),
                            }),
                            t => t.PrintMessageX(Resources.NotStrongEnoughToOpenSarcophagus)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SARCOPH_empty"),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#SARCOPH_empty"),
                                u => u.PrintMessageX(Resources.PutSarcophagusDown),
                            }),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#KEY"),
                                u => u.PrintMessageX(Resources.EmptySarcophagus),
                            }),
                            t => t.PrintMessageX(Resources.NotStrongEnoughToOpenSarcophagus),
                        }),
                        s => s.PrintMessageX(Resources.DontKnowHowToLockUnlock)
                    }
                },
                {
                    Function.Wave, new Script { s => s.PrintMessageX(Resources.NothingHappens) }
                },
                {
                    Function.Pour, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#WATER"),
                            t => t.MoveItemXToRoomY("#WATER", "room_0"),
                            t => t.PrintMessageX(Resources.EmptyBottleWetGround),
                        }),
                        s => s.PrintMessageX(Resources.CantPourThat),
                    }
                },
                {
                    Function.Rub, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#LAMP_off"),
                            t => t.PrintMessageX(Resources.RubbingNothingHappens)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#LAMP_on"),
                            t => t.PrintMessageX(Resources.RubbingNothingHappens)
                        }),
                        s => s.PrintMessageX(Resources.Peculiar)
                    }
                },
                {
                    Function.Fill, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BOTTLE"),
                            t => t.PrintMessageX(Resources.NothingToFillBottleWith)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#VASE_solo"),
                            t => t.PrintMessageX(Resources.DontBeRidiculous),
                        }),
                        s => s.PrintMessageX(Resources.CantFillThat)
                    }
                },
                {
                    Function.Attack, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD"),
                            t => t.MoveItemXToRoomY("#BIRD", "room_0"),
                            t => t.PrintMessageX(Resources.BirdStatueDead)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD_boxed"),
                            t => t.MoveItemXToRoomY("#BIRD_boxed", "room_0"),
                            t => t.PrintMessageX(Resources.BirdStatueDead)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SARCOPH_full"),
                            t => t.PrintMessageX(Resources.StoneVeryStrong)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SARCOPH_empty"),
                            t => t.PrintMessageX(Resources.StoneVeryStrong)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SERPENT"),
                            t => t.PrintMessageX(Resources.AttackingSerpentFails)
                        }),
                        s => s.PrintMessageX(Resources.CantBeSerious)
                    }
                },
                {
                    Function.Break, new Script { s => s.PrintMessageX(Resources.BeyondYourPower) }
                },
                {
                    Function.Eat, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#FOOD"),
                            t => t.MoveItemXToRoomY("#FOOD", "room_0"),
                            t => t.PrintMessageX(Resources.Delicious)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#-10-"),
                            t => t.PrintMessageX(Resources.LostAppetite)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD"),
                            t => t.PrintMessageX(Resources.LostAppetite)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD_boxed"),
                            t => t.PrintMessageX(Resources.LostAppetite)
                        }),
                        s => s.PrintMessageX(Resources.DontBeRidiculous)
                    }
                },
                {
                    Function.Drink, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#WATER"),
                            t => t.MoveItemXToRoomY("#WATER", "room_0"),
                            t => t.PrintMessageX(Resources.EmptyBottle)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#stream_56"),
                            t => t.PrintMessageX(Resources.DrinkFromStream)
                        }),
                        s => s.PrintMessageX(Resources.CantBeSerious)
                    }
                },
                {
                    Function.Feed, new Script
                    {
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD"),
                            t => t.PrintMessageX(Resources.BirdNotHungry)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#BIRD_boxed"),
                            t => t.PrintMessageX(Resources.BirdNotHungry)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SERPENT"),
                            t => t.SubScriptXAbortIfPass(new Script
                            {
                                u => u.AssertItemXIsInPack("#BIRD_boxed"),
                                u => u.MoveItemXToRoomY("#BIRD_boxed", "room_0"),
                                u => u.PrintMessageX(Resources.SerpentEatenBird)
                            }),
                            t => t.PrintMessageX(Resources.SerpentHasNothingToEat)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SARCOPH_full"),
                            t => t.PrintMessageX(Resources.ImGame)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#SARCOPH_empty"),
                            t => t.PrintMessageX(Resources.ImGame)
                        }),
                        s => s.SubScriptXAbortIfPass(new Script
                        {
                            t => t.AssertItemXMatchesUserInput("#-13-"),
                            t => t.PrintMessageX(Resources.SerpentHasNothingToEat)
                        }),
                        s => s.PrintMessageX(Resources.DontBeRidiculous)
                    }
                },
                {
                    Function.Plugh, new Script { s => s.JumpToTopOfGameLoop() }
                },
                {
                    Function.Help, new Script { s => s.PrintMessageX(Resources.Help) }
                }
            };
        }

        public Script GetDefaultScript(Function verb)
        {
            if (_defaultHandler.ContainsKey(verb))
            {
                return _defaultHandler[verb];
            }

            return null;
        }
    }
}
