using System;
using System.Collections.Generic;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Parser : IParser
    {
        private IPrinter _printer;
        private IItems _items;
        private IPlayer _player;
        private IGameSettings _settings;

        private IResources Resources { get; set; }

        public Parser(IPlayer player, IPrinter printer, IItems items, IGameSettings settings, IResources resources)
        {
            _settings = settings;
            _player = player;
            _printer = printer;
            _items = items;
            Resources = resources;

            BuildErrors();
        }

        private void BuildErrors()
        {
            _errors = new string[] { Resources.What, Resources.DontKnowThatWord, Resources.DontUnderstand, Resources.DontKnowWhatYouMean };
        }

        enum Grammar
        {
            noun,
            alone,
            withNounInPack,
            withNounInSight
        }

        class Word
        {
            public Grammar Grammar { get; set; }
            public IList<string> Items { get; set; }
            public Function Function { get; set; }
        }

        class ParsedWord
        {
            public string Original { get; set; }
            public Word Word { get; set; }
        }

        private IDictionary<string, Word> _words = new Dictionary<string, Word>()
        {
            // Nouns
            { "LAMP", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#LAMP_off", "#LAMP_on", "#LAMP_dead" } } },
            { "LANTER", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#LAMP_off", "#LAMP_on", "#LAMP_dead" } } },
            { "BOX", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#BOX" } } },
            { "SCEPTE", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#SCEPTER" } } },
            { "BIRD", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#BIRD", "#BIRD_boxed" } } },
            { "STATUE", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#BIRD", "#BIRD_boxed" } } },
            { "PILLOW", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#PILLOW" } } },
            { "VELVET", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#PILLOW" } } },
            { "SERPEN", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#SERPENT" } } },
            { "SARCOP", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#SARCOPH_full", "#SARCOPH_empty" } } },
            { "MAGAZI", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#MAGAZINES" } } },
            { "ISSUE", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#MAGAZINES" } } },
            { "EGYPTI", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#MAGAZINES" } } },
            { "FOOD", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#FOOD" } } },
            { "BOTTLE", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#BOTTLE" } } },
            { "WATER", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#WATER", "#stream_56" } } },
            { "PLANT", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#PLANT_A", "#PLANT_B", "#PLANT_C" } } },
            { "BEANST", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#PLANT_A", "#PLANT_B", "#PLANT_C" } } },
            { "MACHIN", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#MACHINE" } } },
            { "VENDIN", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#MACHINE" } } },
            { "BATTER", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#BATTERIES_fresh", "#BATTERIES_worn" } } },
            { "GOLD", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#GOLD" } } },
            { "NUGGET", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#GOLD" } } },
            { "DIAMON", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#DIAMONDS" } } },
            { "SILVER", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#SILVER" } } },
            { "BARS", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#SILVER" } } },
            { "JEWELR", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#JEWELRY" } } },
            { "COINS", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#COINS" } } },
            { "CHEST", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#CHEST" } } },
            { "TREASU", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#CHEST" } } },
            { "EGGS", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#NEST" } } },
            { "EGG", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#NEST" } } },
            { "NEST", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#NEST" } } },
            { "KEY", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#KEY" } } },
            { "VASE", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#VASE_pillow", "#VASE_solo" } } },
            { "SHARDS", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#POTTERY" } } },
            { "POTTER", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#POTTERY" } } },
            { "EMERAL", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#EMERALD" } } },
            { "PEARL", new Word { Grammar = Grammar.noun, Items = new List<string>() { "#PEARL" } } },

            // Verbs
            { "N", new Word { Grammar = Grammar.alone, Function = Function.North } },
            { "NORTH", new Word { Grammar = Grammar.alone, Function = Function.North } },
            { "E", new Word { Grammar = Grammar.alone, Function = Function.East } },
            { "EAST", new Word { Grammar = Grammar.alone, Function = Function.East } },
            { "S", new Word { Grammar = Grammar.alone, Function = Function.South } },
            { "SOUTH", new Word { Grammar = Grammar.alone, Function = Function.South } },
            { "W", new Word { Grammar = Grammar.alone, Function = Function.West } },
            { "WEST", new Word { Grammar = Grammar.alone, Function = Function.West } },
            { "NE", new Word { Grammar = Grammar.alone, Function = Function.NorthEast } },
            { "NORTHE", new Word { Grammar = Grammar.alone, Function = Function.NorthEast } },
            { "SE", new Word { Grammar = Grammar.alone, Function = Function.SouthEast } },
            { "SOUTHE", new Word { Grammar = Grammar.alone, Function = Function.SouthEast } },
            { "SW", new Word { Grammar = Grammar.alone, Function = Function.SouthWest } },
            { "SOUTHW", new Word { Grammar = Grammar.alone, Function = Function.SouthWest } },
            { "NW", new Word { Grammar = Grammar.alone, Function = Function.NorthWest } },
            { "NORTHW", new Word { Grammar = Grammar.alone, Function = Function.NorthWest} },
            { "U", new Word { Grammar = Grammar.alone, Function = Function.Up } },
            { "UP", new Word { Grammar = Grammar.alone, Function = Function.Up } },
            { "D", new Word { Grammar = Grammar.alone, Function = Function.Down } },
            { "DOWN", new Word { Grammar = Grammar.alone, Function = Function.Down } },
            { "IN", new Word { Grammar = Grammar.alone, Function = Function.In } },
            { "INSIDE", new Word { Grammar = Grammar.alone, Function = Function.In } },
            { "OUT", new Word { Grammar = Grammar.alone, Function = Function.Out } },
            { "OUTSID", new Word { Grammar = Grammar.alone, Function = Function.Out } },
            { "CROSS", new Word { Grammar = Grammar.alone, Function = Function.Cross } },
            { "LEFT", new Word { Grammar = Grammar.alone, Function = Function.Left } },
            { "RIGHT", new Word { Grammar = Grammar.alone, Function = Function.Right } },
            { "JUMP", new Word { Grammar = Grammar.alone, Function = Function.Jump } },
            { "CLIMB", new Word { Grammar = Grammar.alone, Function = Function.Climb } },
            { "PANEL", new Word { Grammar = Grammar.alone, Function = Function.Panel } },
            { "BACK", new Word { Grammar = Grammar.alone, Function = Function.Back } },
            { "SWIM", new Word { Grammar = Grammar.alone, Function = Function.Swim } },
            { "ON", new Word { Grammar = Grammar.alone, Function = Function.On } },
            { "OFF", new Word { Grammar = Grammar.alone, Function = Function.Off } },
            { "QUIT", new Word { Grammar = Grammar.alone, Function = Function.Quit } },
            { "STOP", new Word { Grammar = Grammar.alone, Function = Function.Stop } },
            { "SCORE", new Word { Grammar = Grammar.alone, Function = Function.Score } },
            { "INVENT", new Word { Grammar = Grammar.alone, Function = Function.Inventory } },
            { "LOOK", new Word { Grammar = Grammar.alone, Function = Function.Look } },
            //
            { "DROP", new Word { Grammar = Grammar.withNounInPack, Function = Function.Drop } },
            { "RELEAS", new Word { Grammar = Grammar.withNounInPack, Function = Function.Drop } },
            { "FREE", new Word { Grammar = Grammar.withNounInPack, Function = Function.Drop } },
            { "DISCAR", new Word { Grammar = Grammar.withNounInPack, Function = Function.Drop } },
            { "LIGHT", new Word { Grammar = Grammar.withNounInPack, Function = Function.On } },
            { "WAVE", new Word { Grammar = Grammar.withNounInPack, Function = Function.Wave } },
            { "SHAKE", new Word { Grammar = Grammar.withNounInPack, Function = Function.Wave } },
            { "SWING", new Word { Grammar = Grammar.withNounInPack, Function = Function.Wave } },
            { "POUR", new Word { Grammar = Grammar.withNounInPack, Function = Function.Pour } },
            { "RUB", new Word { Grammar = Grammar.withNounInPack, Function = Function.Rub } },
            { "THROW", new Word { Grammar = Grammar.withNounInPack, Function = Function.Throw } },
            { "TOSS", new Word { Grammar = Grammar.withNounInPack, Function = Function.Throw } },
            { "FILL", new Word { Grammar = Grammar.withNounInPack, Function = Function.Fill } },
            //
            { "TAKE", new Word { Grammar = Grammar.withNounInSight, Function = Function.Get } },
            { "GET", new Word { Grammar = Grammar.withNounInSight, Function = Function.Get } },
            { "CARRY", new Word { Grammar = Grammar.withNounInSight, Function = Function.Get } },
            { "CATCH", new Word { Grammar = Grammar.withNounInSight, Function = Function.Get } },
            { "STEAL", new Word { Grammar = Grammar.withNounInSight, Function = Function.Get } },
            { "CAPTUR", new Word { Grammar = Grammar.withNounInSight, Function = Function.Get } },
            { "OPEN", new Word { Grammar = Grammar.withNounInSight, Function = Function.Open } },
            { "ATTACK", new Word { Grammar = Grammar.withNounInSight, Function = Function.Attack } },
            { "KILL", new Word { Grammar = Grammar.withNounInSight, Function = Function.Attack } },
            { "HIT", new Word { Grammar = Grammar.withNounInSight, Function = Function.Attack } },
            { "FIGHT", new Word { Grammar = Grammar.withNounInSight, Function = Function.Attack } },
            { "FEED", new Word { Grammar = Grammar.withNounInSight, Function = Function.Feed } },
            { "EAT", new Word { Grammar = Grammar.withNounInSight, Function = Function.Eat } },
            { "DRINK", new Word { Grammar = Grammar.withNounInSight, Function = Function.Drink } },
            { "BREAK", new Word { Grammar = Grammar.withNounInSight, Function = Function.Break } },
            { "SMASH", new Word { Grammar = Grammar.withNounInSight, Function = Function.Break } },
            //
            //{ "LOAD", new Word { Grammar = Grammar.alone, Function = Function.Load } },
            //{ "SAVE", new Word { Grammar = Grammar.alone, Function = Function.Save } },
            { "PLUGH", new Word { Grammar = Grammar.alone, Function = Function.Plugh } },
        };

        private IDictionary<string, Word> _trs80words = new Dictionary<string, Word>()
        {
            { "HELP", new Word { Grammar = Grammar.alone, Function = Function.Help } },
        };

        IList<string> verbs = new List<string> { "N", "E", "S", "W", "NE", "SE", "SW", "NW", "UP", "DOWN", "IN", "OUT", "CROSS", "LEFT", "RIGHT", "JUMP", "CLIMB", "PANEL", "BACK", "SWIM", "ON", "OFF", "QUIT", "STOP", "SCORE", "INVENTORY", "LOOK", "DROP", "WAVE", "POUR", "RUB", "THROW", "FILL", "GET", "OPEN", "ATTACK", "FEED", "EAT", "DRINK", "BREAK", "PLUGH", "HELP" };
        IList<string> nouns = new List<string> { "LAMP", "BOX", "SCEPTER", "BIRD", "PILLOW", "SERPENT", "SARCOPHAGUS", "MAGAZINES", "FOOD", "BOTTLE", "WATER", "PLANT", "MACHINE", "BATTERIES", "GOLD", "DIAMONDS", "SILVER", "JEWELRY", "COINS", "CHEST", "NEST", "KEY", "VASE", "POTTERY", "EMERALD", "PEARL" };

        public  IList<string> GetWords(bool getNouns)
        {
            if (getNouns)
            {
                return nouns;
            }
            else
            {
                return verbs;
            }
        }

        private int _errRoll = 0;
        private string[] _errors;

        private ParsedWord _heldNoun = null;
        private ParsedWord _heldVerb = null;

        private ParsedWord FindWord(string input)
        {
            var keyToFind = input.ToUpper();
            if (keyToFind.Length > 6)
            {
                keyToFind = keyToFind.Substring(0, 6);
            }

            if (_settings.Trs80Mode && _trs80words.ContainsKey(keyToFind))
            {
                return new ParsedWord { Original = input, Word = _trs80words[keyToFind] };
            }
            if (_words.ContainsKey(keyToFind))
            {
                return new ParsedWord { Original = input, Word = _words[keyToFind] };
            }

            return null;
        }

        public IParsedCommand ParseInput(string command)
        {
            // TODO : IMPLEMENT LOAD COMMAND HERE

            var words = command.Trim().Split();

            // Ignore blank input
            if (words.Length == 0)
            {
                return null;
            }

            // Parse words into known verbs and nouns
            ParsedWord noun = null;
            ParsedWord verb = null;
            foreach(var word in words)
            {
                var p = FindWord(word);
                if (p != null)
                {
                    if (p.Word.Grammar == Grammar.noun)
                    {
                        noun = p;
                    }
                    else
                    {
                        verb = p;
                    }
                }
            }

            // Unknown noun/verbs
            if (noun == null && verb == null)
            {
                _errRoll = (_errRoll + 1) % 3;
                _printer.PrintLn(_errors[_errRoll]);
                _heldNoun = null;
                _heldVerb = null;
                return null;
            }

            // If we are holding a word from the last input then use it instead of a word not given
            noun = noun == null ? _heldNoun : noun;
            verb = verb == null ? _heldVerb : verb;

            // We never hold words over one turn
            _heldNoun = null;
            _heldVerb = null;

            // A noun by itself is never a valid command
            if (noun != null && verb == null)
            {
                foreach (var itemName in noun.Word.Items)
                {
                    var o = _items.GetExactItemByName(itemName);
                    var po = _items.GetTopItemByName(o.Name);

                    if (po.Location == "pack" || po.Location == _player.CurrentRoom)
                    {
                        _printer.PrintLn(string.Format(Resources.WhatDoYouWantToDoWith, noun.Original));
                        return null;
                    }
                }
                _printer.PrintLn(string.Format(Resources.ISeeNo, noun.Original));
                return null;
            }

            // An action command - ignore the noun if any was provided
            if (verb != null && verb.Word.Grammar == Grammar.alone)
            {
                return new ParsedCommand() { Function = verb.Word.Function };
            }

            // A verb was provided that requires a noun but none was given
            if (verb != null && noun == null)
            {
                _printer.PrintLn(string.Format(Resources.VerbWhat, verb.Original));
                _heldVerb = verb;
                return null;
            }

            // We have a valid verb and noun. Determine the item the noun refers to.
            IItem nounItem = null;
            if (verb.Word.Grammar == Grammar.withNounInSight)
            {
                // Requires an item in either the player's pack or the current room
                foreach (var itemName in noun.Word.Items)
                {
                    var o = _items.GetExactItemByName(itemName);
                    var po = _items.GetTopItemByName(o.Name);
                    if (po.Location == "pack" || po.Location == _player.CurrentRoom)
                    {
                        nounItem = po;
                        break;
                    }
                }
                if (nounItem == null)
                {
                    _printer.PrintLn(string.Format(Resources.ISeeNo, noun.Original));
                    return null;
                }
            }
            else
            {
                // The item the noun refers to must be in the players pack
                foreach (var itemName in noun.Word.Items)
                {
                    var o = _items.GetExactItemByName(itemName);
                    var po = _items.GetTopItemByName(o.Name);
                    if (po.Location == "pack")
                    {
                        nounItem = o;
                        break;
                    }
                }

                if (nounItem == null)
                {
                    _printer.PrintLn(Resources.ArentCarryingIt);
                    return null;
                }
            }

            // Return the parsed command details
            return new ParsedCommand() { Function = verb.Word.Function, Item = nounItem };
        }
    }
}
