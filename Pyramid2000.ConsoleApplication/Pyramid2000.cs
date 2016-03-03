using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using Pyramid2000.Engine.Implementation;

namespace Pyramid2000.ConsoleApplication
{
    class Pyramid2000
    {
        static void Main(string[] args)
        {
            // Show usage with details of command line options
            if (args.Length == 1 && args[0] == "/?")
            {
                Console.WriteLine("Usage: Pyramid2000.ConsoleApplication [options]");
                Console.WriteLine();
                Console.WriteLine("Pyramid 2000 Options");
                Console.WriteLine();
                Console.WriteLine("Allcaps={true|false}               Specifies if all captials should be used");
                Console.WriteLine("Trs80Mode={true|false}             Specifies if exact TRS-80 mode should be used");
            }
            else
            {
                // Setup all of the game's dependencies
                var resources = new Resources();
                var settings = new GameSettings();
                var printer = new Printer(new ConsolePrinter(), settings);
                var items = new Items(resources);
                var player = new Player(items);
                player.CurrentRoom = "room_1";
                var parser = new Parser(player, printer, items, settings, resources);
                var rooms = new Rooms(items, resources);
                var gameState = new GameState();
                var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);
                var defaultScripter = new DefaultScripter(resources);

                // Parse the command line arguments
                var cmdLineArgs = new CommandLineArgs();
                cmdLineArgs.ParseArgs(args, "allcaps=true;trs80mode=true");

                // Initialise the settings based on the command line arguments/default arugments
                settings.AllCaps = cmdLineArgs.AsBool("allcaps");
                settings.Trs80Mode = cmdLineArgs.AsBool("trs80mode");

                // Create the game
                var game = new Game(player, printer, parser, scripter, rooms, defaultScripter, items, gameState);

                // Initialise the game
                game.Init();

                // While the game isn't over keep playing
                while (!gameState.GameOver)
                {
                    // Read the player's input and process it
                    var input = Console.ReadLine();
                    game.ProcessPlayerInput(input);
                }

                // Game over - give the player a chance to read any final messages before quitting
                Console.ReadLine();
            }
        }
    }
}
