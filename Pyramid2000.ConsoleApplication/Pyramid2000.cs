using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.ConsoleApplication
{
    class Pyramid2000
    {
        static void Main(string[] args)
        {
            IGameSettings settings = new GameSettings();
            IPrinter printer = new ConsolePrinter();
            IPlayer player = new Player();
            IItems items = new Items(player);
            player.CurrentRoom = "room_1";
            IParser parser = new Parser(player, printer, items, settings);
            IRooms rooms = new Rooms(items);
            IGameState gameState = new GameState();
            IScripter scripter = new Scripter(printer, items, rooms, player, gameState, settings);
            IDefaultScripter defaultScripter = new DefaultScripter();

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
