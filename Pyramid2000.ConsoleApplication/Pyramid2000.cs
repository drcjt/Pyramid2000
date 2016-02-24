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
            IResources resources = new Resources();
            IGameSettings settings = new GameSettings();
            IPrinter printer = new Printer(new ConsolePrinter(), settings);
            IItems items = new Items(resources);
            IPlayer player = new Player(items);
            player.CurrentRoom = "room_1";
            IParser parser = new Parser(player, printer, items, settings, resources);
            IRooms rooms = new Rooms(items, resources);
            IGameState gameState = new GameState();
            IScripter scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);
            IDefaultScripter defaultScripter = new DefaultScripter(resources);

            IGame game = new Game(player, printer, parser, scripter, rooms, defaultScripter, items, gameState);

            game.Init();

            while (!gameState.GameOver)
            {
                var input = Console.ReadLine();
                game.ProcessPlayerInput(input);
            }

            Console.ReadLine();
        }
    }
}
