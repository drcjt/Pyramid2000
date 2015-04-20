using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Parser : IParser
    {
        private IPrinter _printer;
        private IItems _items;
        private IPlayer _player;
        private ISettings _settings;

        public Parser(IPlayer player, IPrinter printer, IItems items, ISettings settings)
        {
            _settings = settings;
            _player = player;
            _printer = new Printer(printer, _settings);
            _items = items;
        }

        class Word
        {
            public string Grammar { get; set; }
            public IList<string> Items { get; set; }
            public string Function { get; set; }
        }

        class ParsedWord
        {
            public string Original { get; set; }
            public Word Word { get; set; }
        }

        private IDictionary<string, Word> _words = new Dictionary<string, Word>()
        {
            // Nouns
            { "LAMP", new Word() { Grammar = "noun", Items = new List<string>() { "#LAMP_off", "#LAMP_on", "#LAMP_dead" } } },
            { "LANTER", new Word() { Grammar = "noun", Items = new List<string>() { "#LAMP_off", "#LAMP_on", "#LAMP_dead" } } },
            { "BOX", new Word() { Grammar = "noun", Items = new List<string>() { "#BOX" } } },
            { "SCEPTE", new Word() { Grammar = "noun", Items = new List<string>() { "#SCEPTER" } } },
            { "BIRD", new Word() { Grammar = "noun", Items = new List<string>() { "#BIRD", "#BIRD_boxed" } } },
            { "STATUE", new Word() { Grammar = "noun", Items = new List<string>() { "#BIRD", "#BIRD_boxed" } } },
            { "PILLOW", new Word() { Grammar = "noun", Items = new List<string>() { "#PILLOW" } } },
            { "VELVET", new Word() { Grammar = "noun", Items = new List<string>() { "#PILLOW" } } },
            { "SERPEN", new Word() { Grammar = "noun", Items = new List<string>() { "#SERPENT" } } },
            { "SARCOP", new Word() { Grammar = "noun", Items = new List<string>() { "#SARCOPH_full", "#SARCOPH_empty" } } },
            { "MAGAZI", new Word() { Grammar = "noun", Items = new List<string>() { "#MAGAZINES" } } },
            { "ISSUE", new Word() { Grammar = "noun", Items = new List<string>() { "#MAGAZINES" } } },
            { "EGYPTI", new Word() { Grammar = "noun", Items = new List<string>() { "#MAGAZINES" } } },
            { "FOOD", new Word() { Grammar = "noun", Items = new List<string>() { "#FOOD" } } },
            { "BOTTLE", new Word() { Grammar = "noun", Items = new List<string>() { "#BOTTLE" } } },
            { "WATER", new Word() { Grammar = "noun", Items = new List<string>() { "#WATER", "#stream_56" } } },
            { "PLANT", new Word() { Grammar = "noun", Items = new List<string>() { "#PLANT_A", "#PLANT_B", "#PLANT_C" } } },
            { "BEANST", new Word() { Grammar = "noun", Items = new List<string>() { "#PLANT_A", "#PLANT_B", "#PLANT_C" } } },
            { "MACHIN", new Word() { Grammar = "noun", Items = new List<string>() { "#MACHINE" } } },
            { "VENDIN", new Word() { Grammar = "noun", Items = new List<string>() { "#MACHINE" } } },
            { "BATTER", new Word() { Grammar = "noun", Items = new List<string>() { "#BATTERIES_fresh", "#BATTERIES_worn" } } },
            { "GOLD", new Word() { Grammar = "noun", Items = new List<string>() { "#GOLD" } } },
            { "NUGGET", new Word() { Grammar = "noun", Items = new List<string>() { "#GOLD" } } },
            { "DIAMON", new Word() { Grammar = "noun", Items = new List<string>() { "#DIAMONDS" } } },
            { "SILVER", new Word() { Grammar = "noun", Items = new List<string>() { "#SILVER" } } },
            { "BARS", new Word() { Grammar = "noun", Items = new List<string>() { "#SILVER" } } },
            { "JEWELR", new Word() { Grammar = "noun", Items = new List<string>() { "#JEWELRY" } } },
            { "COINS", new Word() { Grammar = "noun", Items = new List<string>() { "#COINS" } } },
            { "CHEST", new Word() { Grammar = "noun", Items = new List<string>() { "#CHEST" } } },
            { "TREASU", new Word() { Grammar = "noun", Items = new List<string>() { "#CHEST" } } },
            { "EGGS", new Word() { Grammar = "noun", Items = new List<string>() { "#NEST" } } },
            { "EGG", new Word() { Grammar = "noun", Items = new List<string>() { "#NEST" } } },
            { "NEST", new Word() { Grammar = "noun", Items = new List<string>() { "#NEST" } } },
            { "KEY", new Word() { Grammar = "noun", Items = new List<string>() { "#KEY" } } },
            { "VASE", new Word() { Grammar = "noun", Items = new List<string>() { "#VASE_pillow", "#VASE_solo" } } },
            { "SHARDS", new Word() { Grammar = "noun", Items = new List<string>() { "#POTTERY" } } },
            { "POTTER", new Word() { Grammar = "noun", Items = new List<string>() { "#POTTERY" } } },
            { "EMERAL", new Word() { Grammar = "noun", Items = new List<string>() { "#EMERALD" } } },
            { "PEARL", new Word() { Grammar = "noun", Items = new List<string>() { "#PEARL" } } },

            // Verbs
            { "N", new Word() { Grammar = "alone", Function = "_n" } },
            { "NORTH", new Word() { Grammar = "alone", Function = "_n" } },
            { "E", new Word() { Grammar = "alone", Function = "_e" } },
            { "EAST", new Word() { Grammar = "alone", Function = "_e" } },
            { "S", new Word() { Grammar = "alone", Function = "_s" } },
            { "SOUTH", new Word() { Grammar = "alone", Function = "_s" } },
            { "W", new Word() { Grammar = "alone", Function = "_w" } },
            { "WEST", new Word() { Grammar = "alone", Function = "_w" } },
            { "NE", new Word() { Grammar = "alone", Function = "_ne" } },
            { "NORTHE", new Word() { Grammar = "alone", Function = "_ne" } },
            { "SE", new Word() { Grammar = "alone", Function = "_se" } },
            { "SOUTHE", new Word() { Grammar = "alone", Function = "_se" } },
            { "SW", new Word() { Grammar = "alone", Function = "_sw" } },
            { "SOUTHW", new Word() { Grammar = "alone", Function = "_sw" } },
            { "NW", new Word() { Grammar = "alone", Function = "_nw" } },
            { "NORTHW", new Word() { Grammar = "alone", Function = "_nw" } },
            { "U", new Word() { Grammar = "alone", Function = "_u" } },
            { "UP", new Word() { Grammar = "alone", Function = "_u" } },
            { "D", new Word() { Grammar = "alone", Function = "_d" } },
            { "DOWN", new Word() { Grammar = "alone", Function = "_d" } },
            { "IN", new Word() { Grammar = "alone", Function = "_in" } },
            { "INSIDE", new Word() { Grammar = "alone", Function = "_in" } },
            { "OUT", new Word() { Grammar = "alone", Function = "_out" } },
            { "OUTSID", new Word() { Grammar = "alone", Function = "_out" } },
            { "CROSS", new Word() { Grammar = "alone", Function = "_cross" } },
            { "LEFT", new Word() { Grammar = "alone", Function = "_left" } },
            { "RIGHT", new Word() { Grammar = "alone", Function = "_right" } },
            { "JUMP", new Word() { Grammar = "alone", Function = "_jump" } },
            { "CLIMB", new Word() { Grammar = "alone", Function = "_climb" } },
            { "PANEL", new Word() { Grammar = "alone", Function = "_panel" } },
            { "BACK", new Word() { Grammar = "alone", Function = "_back" } },
            { "SWIM", new Word() { Grammar = "alone", Function = "_swim" } },
            { "ON", new Word() { Grammar = "alone", Function = "_on" } },
            { "OFF", new Word() { Grammar = "alone", Function = "_off" } },
            { "QUIT", new Word() { Grammar = "alone", Function = "_quit" } },
            { "STOP", new Word() { Grammar = "alone", Function = "_stop" } },
            { "SCORE", new Word() { Grammar = "alone", Function = "_score" } },
            { "INVENT", new Word() { Grammar = "alone", Function = "_inv" } },
            { "LOOK", new Word() { Grammar = "alone", Function = "_look" } },
            //
            { "DROP", new Word() { Grammar = "withNounInPack", Function = "_drop" } },
            { "RELEAS", new Word() { Grammar = "withNounInPack", Function = "_drop" } },
            { "FREE", new Word() { Grammar = "withNounInPack", Function = "_drop" } },
            { "DISCAR", new Word() { Grammar = "withNounInPack", Function = "_drop" } },
            { "LIGHT", new Word() { Grammar = "withNounInPack", Function = "_on" } },
            { "WAVE", new Word() { Grammar = "withNounInPack", Function = "_wave" } },
            { "SHAKE", new Word() { Grammar = "withNounInPack", Function = "_wave" } },
            { "SWING", new Word() { Grammar = "withNounInPack", Function = "_wave" } },
            { "POUR", new Word() { Grammar = "withNounInPack", Function = "_pour" } },
            { "RUB", new Word() { Grammar = "withNounInPack", Function = "_rub" } },
            { "THROW", new Word() { Grammar = "withNounInPack", Function = "_throw" } },
            { "TOSS", new Word() { Grammar = "withNounInPack", Function = "_throw" } },
            { "FILL", new Word() { Grammar = "withNounInPack", Function = "_fill" } },
            //
            { "TAKE", new Word() { Grammar = "withNounInSight", Function = "_get" } },
            { "GET", new Word() { Grammar = "withNounInSight", Function = "_get" } },
            { "CARRY", new Word() { Grammar = "withNounInSight", Function = "_get" } },
            { "CATCH", new Word() { Grammar = "withNounInSight", Function = "_get" } },
            { "STEAL", new Word() { Grammar = "withNounInSight", Function = "_get" } },
            { "CAPTUR", new Word() { Grammar = "withNounInSight", Function = "_get" } },
            { "OPEN", new Word() { Grammar = "withNounInSight", Function = "_open" } },
            { "ATTACK", new Word() { Grammar = "withNounInSight", Function = "_attack" } },
            { "KILL", new Word() { Grammar = "withNounInSight", Function = "_attack" } },
            { "HIT", new Word() { Grammar = "withNounInSight", Function = "_attack" } },
            { "FIGHT", new Word() { Grammar = "withNounInSight", Function = "_attack" } },
            { "FEED", new Word() { Grammar = "withNounInSight", Function = "_feed" } },
            { "EAT", new Word() { Grammar = "withNounInSight", Function = "_eat" } },
            { "DRINK", new Word() { Grammar = "withNounInSight", Function = "_drink" } },
            { "BREAK", new Word() { Grammar = "withNounInSight", Function = "_break" } },
            { "SMASH", new Word() { Grammar = "withNounInSight", Function = "_break" } },
            //
            //{ "LOAD", new Word() { Grammar = "alone", Function = "_load" } },
            //{ "SAVE", new Word() { Grammar = "alone", Function = "_save" } },
            { "PLUGH", new Word() { Grammar = "alone", Function = "_plugh" } },
        };

        private IDictionary<string, Word> _trs80words = new Dictionary<string, Word>()
        {
            { "HELP", new Word() { Grammar = "alone", Function = "_help" } },
        };

        public IList<String> GetNouns()
        {
            IList<String> nouns = new List<String>();
            foreach (var entry in _words)
            {
                var word = entry.Value as Word;
                if (word.Grammar == "noun")
                {
                    nouns.Add(entry.Key);
                }
            }

            return nouns;
        }

        private int _errRoll = 0;
        private string[] _errors = new string[] { Resources.What, Resources.DontKnowThatWord, Resources.DontUnderstand, Resources.DontKnowWhatYouMean };

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
                return new ParsedWord() { Original = input, Word = _trs80words[keyToFind] };
            }
            if (_words.ContainsKey(keyToFind))
            {
                return new ParsedWord() { Original = input, Word = _words[keyToFind] };
            }

            return null;
        }

        public ParsedCommand ParseInput(string command)
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
                    if (p.Word.Grammar == "noun")
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
            if (verb != null && verb.Word.Grammar == "alone")
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
            Item nounItem = null;
            if (verb.Word.Grammar == "withNounInSight")
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
