using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;

using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using Pyramid2000.Engine.Implementation;

namespace Pyramid2000EngineTests
{
    [TestFixture]
    public class ScripterTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void TestRoomScripts(bool trs80Mode)
        {
            IResources resources = new Resources();
            IGameSettings settings = new GameSettings();
            settings.Trs80Mode = trs80Mode;
            IPrinter printer = new Mock<IPrinter>().Object;
            IItems items = new Items(resources);
            IPlayer player = new Player(items);
            player.CurrentRoom = "room_1";
            IParser parser = new Parser(player, printer, items, settings, resources);
            IRooms rooms = new Rooms(items, resources);
            IGameState gameState = new GameState();
            IScripter scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);
            IDefaultScripter defaultScripter = new DefaultScripter(resources);

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
