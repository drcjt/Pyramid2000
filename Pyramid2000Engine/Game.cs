using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public class Game
    {
        public String CurrentRoom { get; set; }
        public String LastRoom { get; set; }
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

            CurrentRoom = "room_1";
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

            printer.PrintLn("WELCOME TO PYRAMID 2000!!");
            printer.PrintLn("");

            scripter.Look();
            printer.Print(": ");
        }

        public void ProcessPlayerInput(string input)
        {
            ParsedCommand parsedCommand = parser.Parse(input);
            if (parsedCommand != null)
            {
                var room = Room.Rooms[CurrentRoom];

                var passed = false;

                bool processCommand = true;
                if (parsedCommand.Noun != null)
                {
                    bool nounInSight = Parser.CanVerbBeUsedWithNounInSight(parsedCommand.Verb.Value);
                    Predicate<string> itemPredicate = (l => l == "pack" || (nounInSight && l == CurrentRoom));
                    scripter.inputItem = Items.GetInputItem(parsedCommand.Noun.Value, itemPredicate);

                    if (scripter.inputItem == null)
                    {
                        if (nounInSight)
                        {
                            printer.PrintLn("I SEE NO " + parsedCommand.OriginalNoun + " HERE.");
                        }
                        else
                        {
                            printer.PrintLn("YOU AREN'T CARRYING IT.");
                        }
                        processCommand = false;
                    }
                }

                if (processCommand)
                {
                    Script script;
                    if (room.Commands.TryGetValue(parsedCommand.Verb.Value, out script))
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
                        printer.PrintLn("I DON'T KNOW HOW TO APPLY THAT WORD HERE.");
                    }                

                    AfterPlayerTurnProcessing();
                }
            }

            printer.Print(": ");
        }

        public void AfterPlayerTurnProcessing()
        {
            TurnCount++;
        }
    }
}
