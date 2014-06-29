using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public enum Noun
    {
        Lamp,        
        Box,
        Scepter,
        Bird,
        Pillow,
        Serpent,
        Sarcophagus,
        Magazines,
        Food,
        Bottle,
        Water,
        Plant,
        Machine,
        Batteries,
        Gold,
        Diamonds,
        Silver,
        Jewelry,
        Coins,
        Chest,
        Nest,
        Key,
        Vase,
        Pottery,
        Emerald,
        Pearl
    };

    public enum Verb 
    { 
        North,
        East,
        West,
        South,
        NorthEast,
        SouthEast,
        SouthWest,
        NorthWest,
        Up,
        Down,
        In,
        Out,
        Cross,
        Left,
        Right,
        Jump,
        Climb,
        Panel,
        Back,

        Quit,
        Score,
        Inventory,
        Look,
        Drop,
        Get,
        Open,
        Attack,
        Feed,
        Eat,
        Drink,
        Break
    };

    public class ParsedCommand
    {
        public Verb? Verb { get; set; }
        public Noun? Noun { get; set; }

        public string OriginalVerb { get; set; }
        public string OriginalNoun { get; set; }
    };

    public class Parser
    {
        private static IDictionary<String, Verb> Verbs = new Dictionary<String, Verb>();
        private static IDictionary<String, Noun> Nouns = new Dictionary<String, Noun>();

        public Noun? HeldNoun { get; set; }
        public Verb? HeldVerb { get; set; }

        private IPrinter printer;

        private int errorIndex = 0;
        private string[] errors = new string[] { "WHAT?", "I DON'T KNOW THAT WORD.", "I DON'T UNDERSTAND.", "I DON'T KNOW WHAT YOU MEAN." };

        static Parser()
        {
            Nouns.Add("LAMP", Noun.Lamp);
            Nouns.Add("LANTER", Noun.Lamp);
            Nouns.Add("BOX", Noun.Box);
            Nouns.Add("SCEPTER", Noun.Scepter);
            Nouns.Add("BIRD", Noun.Bird);
            Nouns.Add("STATUE", Noun.Bird);
            Nouns.Add("PILLOW", Noun.Pillow);
            Nouns.Add("VELVET", Noun.Pillow);
            Nouns.Add("SERPEN", Noun.Serpent);
            Nouns.Add("SARCOP", Noun.Sarcophagus);
            Nouns.Add("MAGAZI", Noun.Magazines);
            Nouns.Add("ISSUE", Noun.Magazines);
            Nouns.Add("EGYPTI", Noun.Magazines);
            Nouns.Add("FOOD", Noun.Food);
            Nouns.Add("BOTTLE", Noun.Bottle);
            Nouns.Add("WATER", Noun.Water);
            Nouns.Add("PLANT", Noun.Plant);
            Nouns.Add("BEANST", Noun.Plant);
            Nouns.Add("MACHIN", Noun.Machine);
            Nouns.Add("VENDIN", Noun.Machine);
            Nouns.Add("BATTER", Noun.Batteries);
            Nouns.Add("GOLD", Noun.Gold);
            Nouns.Add("NUGGET", Noun.Gold);
            Nouns.Add("DIAMON", Noun.Diamonds);
            Nouns.Add("SILVER", Noun.Silver);
            Nouns.Add("BARS", Noun.Silver);
            Nouns.Add("JEWELR", Noun.Jewelry);
            Nouns.Add("COINS", Noun.Coins);
            Nouns.Add("CHEST", Noun.Chest);
            Nouns.Add("TREASU", Noun.Chest);
            Nouns.Add("EGGS", Noun.Nest);
            Nouns.Add("EGG", Noun.Nest);
            Nouns.Add("NEST", Noun.Nest);
            Nouns.Add("KEY", Noun.Key);
            Nouns.Add("VASE", Noun.Vase);
            Nouns.Add("SHARDS", Noun.Pottery);
            Nouns.Add("POTTER", Noun.Pottery);
            Nouns.Add("EMERAL", Noun.Emerald);
            Nouns.Add("PEARL", Noun.Pearl);

            Verbs.Add("N", Verb.North);
            Verbs.Add("NORTH", Verb.North);
            Verbs.Add("E", Verb.East);
            Verbs.Add("EAST", Verb.East);
            Verbs.Add("W", Verb.West);
            Verbs.Add("WEST", Verb.West);
            Verbs.Add("S", Verb.South);
            Verbs.Add("SOUTH", Verb.South);
            Verbs.Add("NE", Verb.NorthEast);
            Verbs.Add("NORTHE", Verb.NorthEast);
            Verbs.Add("SE", Verb.SouthEast);
            Verbs.Add("SOUTHE", Verb.SouthEast);
            Verbs.Add("SW", Verb.SouthWest);
            Verbs.Add("SOUTHW", Verb.SouthWest);
            Verbs.Add("NW", Verb.NorthWest);
            Verbs.Add("NORTHW", Verb.NorthWest);
            Verbs.Add("U", Verb.Up);
            Verbs.Add("UP", Verb.Up);
            Verbs.Add("D", Verb.Down);
            Verbs.Add("DOWN", Verb.Down);
            Verbs.Add("IN", Verb.In);
            Verbs.Add("INSIDE", Verb.In);
            Verbs.Add("OUT", Verb.Out);
            Verbs.Add("OUTSID", Verb.Out);
            Verbs.Add("CROSS", Verb.Cross);
            Verbs.Add("LEFT", Verb.Left);
            Verbs.Add("RIGHT", Verb.Right);
            Verbs.Add("JUMP", Verb.Jump);
            Verbs.Add("CLIMB", Verb.Climb);
            Verbs.Add("PANEL", Verb.Panel);
            Verbs.Add("BACK", Verb.Back);
            Verbs.Add("QUIT", Verb.Quit);
            Verbs.Add("STOP", Verb.Quit);
            Verbs.Add("SCORE", Verb.Score);
            Verbs.Add("INVENT", Verb.Inventory);
            Verbs.Add("LOOK", Verb.Look);
            Verbs.Add("DROP", Verb.Drop);
            Verbs.Add("RELEAS", Verb.Drop);
            Verbs.Add("FREE", Verb.Drop);
            Verbs.Add("DISCAR", Verb.Drop);
            Verbs.Add("TAKE", Verb.Get);
            Verbs.Add("GET", Verb.Get);
            Verbs.Add("CARRY", Verb.Get);
            Verbs.Add("CATCH", Verb.Get);
            Verbs.Add("STEAL", Verb.Get);
            Verbs.Add("CAPTUR", Verb.Get);
            Verbs.Add("OPEN", Verb.Open);
            Verbs.Add("ATTACK", Verb.Attack);
            Verbs.Add("KILL", Verb.Attack);
            Verbs.Add("HIT", Verb.Attack);
            Verbs.Add("FIGHT", Verb.Attack);
            Verbs.Add("FEED", Verb.Feed);
            Verbs.Add("EAT", Verb.Eat);
            Verbs.Add("DRINK", Verb.Drink);
            Verbs.Add("BREAK", Verb.Break);
            Verbs.Add("SMASH", Verb.Break);
        }

        private static bool CanVerbBeUsedAlone(Verb verb)
        {
            return (verb == Verb.North || verb == Verb.East || verb == Verb.South || verb == Verb.West || 
                    verb == Verb.NorthEast || verb == Verb.SouthEast || verb == Verb.SouthWest || verb == Verb.NorthWest ||
                    verb == Verb.Up || verb == Verb.Down || verb == Verb.In || verb == Verb.Out || verb == Verb.Cross ||
                    verb == Verb.Left || verb == Verb.Right || verb == Verb.Climb || verb == Verb.Back || verb == Verb.Panel || 
                    verb == Verb.Quit || verb == Verb.Score || verb == Verb.Inventory || verb == Verb.Look);
        }

        public static bool CanVerbBeUsedWithNounInSight(Verb verb)
        {
            return (verb == Verb.Get || verb == Verb.Open || verb == Verb.Attack || verb == Verb.Feed || verb == Verb.Eat ||
                verb == Verb.Drink || verb == Verb.Break);
        }

        public Parser(IPrinter printer)
        {
            this.printer = printer;
        }

        public ParsedCommand Parse(String command)
        {
            var words = command.ToUpper().Trim().Split(null);

            // Ignore blank input
            if (words[0].Length == 0)
            {
                return null;
            }

            // Parse into known Verbs
            var parsedCommand = new ParsedCommand();
            foreach (var word in words)
            {
                var searchWord = String.Concat(word.Take(6));

                Verb verb;
                Noun noun;
                if (Nouns.TryGetValue(searchWord, out noun))
                {
                    parsedCommand.Noun = noun;
                    parsedCommand.OriginalNoun = word;
                }
                else if (Verbs.TryGetValue(searchWord, out verb))
                {
                    parsedCommand.Verb = verb;
                    parsedCommand.OriginalVerb = word;
                }                
            }

            // Didn't recognise any nouns or verbs
            if (parsedCommand.Noun == null && parsedCommand.Verb == null)
            {
                errorIndex = (errorIndex + 1) & 3;

                printer.PrintLn(errors[errorIndex]);
                HeldNoun = null;
                HeldVerb = null;

                return null;
            }

            parsedCommand.Noun = parsedCommand.Noun ?? HeldNoun;
            parsedCommand.Verb = parsedCommand.Verb ?? HeldVerb;

            HeldNoun = null;
            HeldVerb = null;

            if (parsedCommand.Noun != null && parsedCommand.Verb == null)
            {
                printer.PrintLn(string.Format("I SEE NO {0} HERE.", parsedCommand.OriginalNoun));
                return null;
            }

            // Is this an action command, i.e. a verb that can be used without a noun
            if (parsedCommand.Verb != null && CanVerbBeUsedAlone(parsedCommand.Verb.Value))
            {
                return parsedCommand;
            }

            if (parsedCommand.Verb != null && parsedCommand.Noun == null)
            {
                printer.PrintLn(string.Format("{0} WHAT?", parsedCommand.OriginalVerb));
                HeldVerb = parsedCommand.Verb;
                return null;
            }

            return parsedCommand;
        }
    }
}
