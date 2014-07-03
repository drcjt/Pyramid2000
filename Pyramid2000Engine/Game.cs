using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public class Game
    {
        public Location.Room CurrentRoom { get; set; }
        public Location.Room LastRoom { get; set; }
        public int TurnCount { get; set; }
        public bool GameOver { get; set; }
        public int BatteryLife { get; set; }

        public Items Items { get; private set; }

        private IPrinter printer;
        private Parser parser;
        private Scripter scripter;

        public Game(IPrinter printer)
        {
            this.printer = printer;

            CurrentRoom = Location.Room_1;
            LastRoom = null;
            TurnCount = 0;
            GameOver = false;
            BatteryLife = 310;

            Items = new Items();
        }

        public void StartGame()
        {
            parser = new Parser(printer);
            scripter = new Scripter(printer, this);

            printer.PrintLn(Resources.Message_Welcome);
            printer.PrintLn(String.Empty);

            scripter.Look();
            printer.Print(Resources.Message_Prompt);
        }

        public void ProcessPlayerInput(string input)
        {
            ParsedCommand parsedCommand = parser.Parse(input);
            if (parsedCommand != null)
            {
                var passed = false;

                bool processCommand = true;
                if (parsedCommand.Noun != null)
                {
                    bool nounInSight = Parser.CanVerbBeUsedWithNounInSight(parsedCommand.Verb.Value);
                    Predicate<Location> itemPredicate = (l => l is Location.Pack || (nounInSight && l == CurrentRoom));
                    scripter.inputItem = Items.GetInputItem(parsedCommand.Noun.Value, itemPredicate);

                    if (scripter.inputItem == null)
                    {
                        if (nounInSight)
                        {
                            printer.PrintLn(string.Format(Resources.Message_Not_Here, parsedCommand.OriginalNoun));
                        }
                        else
                        {
                            printer.PrintLn(Resources.Message_Not_Carrying_It);
                        }
                        processCommand = false;
                    }
                }

                if (processCommand)
                {
                    Script script;
                    if (CurrentRoom.Commands.TryGetValue(parsedCommand.Verb.Value, out script))
                    {
                        passed = script(scripter);
                    }

                    if (!passed)
                    {
                        script = DefaultScripter.GetDefaultScript(parsedCommand.Verb.Value);
                        if (script != null)
                        {
                            passed = script(scripter);
                        }
                    }

                    if (!passed)
                    {
                        printer.PrintLn(Resources.Message_Inapplicable_Word);
                    }                

                    AfterPlayerTurnProcessing();
                }
            }

            printer.Print(Resources.Message_Prompt);
        }

        public void AfterPlayerTurnProcessing()
        {
            TurnCount++;
        }
    }
}
