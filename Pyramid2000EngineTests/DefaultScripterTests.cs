using Moq;
using NUnit.Framework;
using Pyramid2000.Engine;
using Pyramid2000.Engine.Implementation;
using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000EngineTests
{
    [TestFixture]
    class DefaultScripterTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void TestRoomScripts(bool trs80Mode)
        {
            var resources = new Resources();
            var settings = new GameSettings();
            settings.Trs80Mode = trs80Mode;
            var printer = new Mock<IPrinter>().Object;
            var items = new Items(resources);
            var player = new Player(items);
            player.CurrentRoom = "room_1";
            var parser = new Parser(player, printer, items, settings, resources);
            var rooms = new Rooms(items, resources);
            var gameState = new GameState();

            var defaultScripter = new DefaultScripter(resources);
            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);

            foreach (Function function in Enum.GetValues(typeof(Function)))
            {
                var defaultScript = defaultScripter.GetDefaultScript(function);
                if (defaultScript != null)
                {
                    scripter.ParseScript(defaultScript, null);
                }
            }
        }
    }
}
