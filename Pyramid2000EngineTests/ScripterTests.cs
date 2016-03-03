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
        static private Resources _resources = new Resources();
        
        [Test]
        public void PlayerDied_WhenPlayerFirstDies_ShouldAskPlayerIfTheyWantToReincarnate()
        {
            // Arrange
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = true;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(gameState.AskToReincarnate);
            Assert.IsFalse(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(_resources.GottenKilled));
        }

        [Test]
        public void PlayerDied_WhenPlayerDiesForSecondTime_ShouldAskPlayerIfTheyWantToReincarnate()
        {
            // Arrange
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = true;
            gameState.ReincarnateCount = 1;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(gameState.AskToReincarnate);
            Assert.IsFalse(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(_resources.ClumsyOaf));
        }

        [Test]
        public void PlayerDied_WhenPlayerDiesForThirdTime_PlayerIsntAskedToReincarnate()
        {
            // Arrange
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = true;
            gameState.ReincarnateCount = 2;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(gameState.AskToReincarnate);
            Assert.IsTrue(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(_resources.CantReincarnate));
            Mock.Get(printer).Verify(p => p.PrintLn(String.Format(_resources.YouHaveScored, -30, 0)));
        }

        [Test]
        public void PlayerDied_WhenNotTrs80Mode_ScoreIsPrintedAndGameIsOver()
        {
            // Arrange
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = false;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);

            // Act
            var result = scripter.PlayerDied();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(String.Format(_resources.YouHaveScored, 0, 0)));
        }

        [Test]
        public void ProcessReincarnation_WhenInputIsNotY_ScoreIsPrintedAndGameIsOver()
        {
            // Arrange
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            settings.Trs80Mode = false;

            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);

            // Act
            scripter.ProcessReincarnation("N");

            // Assert
            Assert.IsTrue(gameState.GameOver);
            Mock.Get(printer).Verify(p => p.PrintLn(String.Format(_resources.YouHaveScored, 0, 0)));
        }

        [Test]
        public void ProcessReincarnation_WhenInputIsYAndReincarnateCountIsOne_ReincarnationMessageIsPrintedAndLook()
        {
            ProcessReincarnation_WhenInputIsYWithGivenReincarnateCount_GivenReincarnationMessageIsPrintedAndLook(1, _resources.DontBlameMe);
        }

        [Test]
        public void ProcessReincarnation_WhenInputIsYAndReincarnateCountIsTwo_ReincarnationMessageIsPrintedAndLook()
        {
            ProcessReincarnation_WhenInputIsYWithGivenReincarnateCount_GivenReincarnationMessageIsPrintedAndLook(2, _resources.WhereDidIPutMyOrangeSmoke);
        }

        private void ProcessReincarnation_WhenInputIsYWithGivenReincarnateCount_GivenReincarnationMessageIsPrintedAndLook(int reincarnateCount, string expectedMessage)
        {
            // Arrange
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();

            gameState.ReincarnateCount = reincarnateCount;
            settings.Trs80Mode = false;

            player.CurrentRoom = "CurrentRoom";

            var lampOffItem = new Item();

            var room2 = new Room() { Description = "Room 2 Description" };

            var itemInPack = new Item();

            Mock.Get(items).Setup(i => i.GetExactItemByName("#LAMP_off")).Returns(lampOffItem);
            Mock.Get(items).Setup(i => i.GetItemsAtLocation("pack")).Returns(new List<IItem> { itemInPack });
            Mock.Get(rooms).Setup(r => r.GetRoom("room_2")).Returns(room2);
            Mock.Get(rooms).Setup(r => r.IsRoomLit(It.IsAny<string>())).Returns(true);
            Mock.Get(items).Setup(i => i.GetItemsAtLocation("room_2")).Returns(new List<IItem>());
            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);

            // Act
            scripter.ProcessReincarnation("Y");

            // Assert
            Assert.IsFalse(gameState.GameOver);
            Assert.AreEqual("room_1", lampOffItem.Location);
            Assert.AreEqual("CurrentRoom", gameState.LastRoom);
            Assert.AreEqual("room_2", player.CurrentRoom);
            Assert.AreEqual("CurrentRoom", itemInPack.Location);

            Mock.Get(printer).Verify(p => p.PrintLn(expectedMessage));
            Mock.Get(printer).Verify(p => p.PrintLn(room2.Description));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void TestRoomScripts(bool trs80Mode)
        {
            var settings = new GameSettings();
            settings.Trs80Mode = trs80Mode;
            var printer = new Mock<IPrinter>().Object;
            var items = new Items(_resources);
            var player = new Player(items);
            player.CurrentRoom = "room_1";
            var parser = new Parser(player, printer, items, settings, _resources);
            var rooms = new Rooms(items, _resources);
            var gameState = new GameState();

            // Enumerate rooms and run all scripts
            var roomNames = rooms.GetRoomNames();
            foreach (var roomName in roomNames)
            {
                var room = rooms.GetRoom(roomName);
                player.CurrentRoom = roomName;

                var commands = room.Commands;
                foreach (var command in commands.Values)
                {
                    // Create scripter
                    var scripter = new Scripter(printer, items, rooms, player, gameState, settings, _resources);
                    scripter.ParseScriptRec(command);
                }
            }
        }
    }
}
