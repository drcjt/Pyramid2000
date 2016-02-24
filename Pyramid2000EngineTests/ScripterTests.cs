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
        [Test]
        public void PlayerDied_WhenPlayerFirstDies_ShouldAskPlayerIfTheyWantToReincarnate()
        {
            // Arrange
            var resources = new Resources();
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = true;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(gameState.AskToReincarnate);
            Assert.IsFalse(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(resources.GottenKilled));
        }

        [Test]
        public void PlayerDied_WhenPlayerDiesForSecondTime_ShouldAskPlayerIfTheyWantToReincarnate()
        {
            // Arrange
            var resources = new Resources();
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = true;
            gameState.ReincarnateCount = 1;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(gameState.AskToReincarnate);
            Assert.IsFalse(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(resources.ClumsyOaf));
        }

        [Test]
        public void PlayerDied_WhenPlayerDiesForThirdTime_PlayerIsntAskedToReincarnate()
        {
            // Arrange
            var resources = new Resources();
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = true;
            gameState.ReincarnateCount = 2;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(gameState.AskToReincarnate);
            Assert.IsTrue(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(resources.CantReincarnate));

            // TODO Verify score is printed
        }

        [Test]
        public void PlayerDied_WhenNotTrs80Mode_ScoreIsPrintedAndGameIsOver()
        {
            // Arrange
            var resources = new Resources();
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = false;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(gameState.GameOver);

            // TODO Verify score is printed
        }

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
