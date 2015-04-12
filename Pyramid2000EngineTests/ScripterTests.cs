using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;

using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000EngineTests
{
    [TestFixture]
    public class ScripterTests
    {
        [Test]
        public void TestRoomScripts()
        {
            ISettings settings = new Settings();
            IPrinter printer = new Mock<IPrinter>().Object;
            IItems items = new Items();
            IPlayer player = new Player();
            player.CurrentRoom = "room_1";
            IParser parser = new Parser(player, printer, items, settings);
            IRooms rooms = new Rooms(items);
            IGameState gameState = new GameState();
            IScripter scripter = new Scripter(printer, items, rooms, player, gameState, settings);
            IDefaultScripter defaultScripter = new DefaultScripter();

            var roomNames = rooms.GetRoomNames();
            foreach (var roomName in roomNames)
            {
                var room = rooms.GetRoom(roomName);
                player.CurrentRoom = roomName;

                var commands = room.Commands;
                foreach (var command in commands.Values)
                {
                    scripter.ParseScriptRec(command);
                }
            }

            // Create scripter
            // Enumerate rooms and run all scripts
        }
    }
}
