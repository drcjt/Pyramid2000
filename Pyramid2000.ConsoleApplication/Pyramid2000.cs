﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000_StraightPort;

namespace Pyramid2000.ConsoleApplication
{
    class Pyramid2000
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            IItems items = new Items();
            IPlayer player = new Player();
            player.CurrentRoom = "room_1";
            IParser parser = new Parser(player, printer, items);
            IRooms rooms = new Rooms(items);
            IGameState gameState = new GameState();
            IScripter scripter = new Scripter(printer, items, rooms, player, gameState);
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
