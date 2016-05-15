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
    class GameTests
    {
        [Test]
        public void Init_PrintsWelcomeMessageLooksAndPromptsForInput()
        {
            // Arrange
            var resources = new Resources();
            var settings = Mock.Of<IGameSettings>();
            var printer = Mock.Of<IPrinter>();
            var items = Mock.Of<IItems>();
            var rooms = Mock.Of<IRooms>();
            var player = Mock.Of<IPlayer>();
            var gameState = Mock.Of<IGameState>();
            var parser = Mock.Of<IParser>();
            var scripter = Mock.Of<IScripter>();
            var defaultScripter = Mock.Of<IDefaultScripter>();

            var game = new Game(player, printer, parser, scripter, rooms, defaultScripter, items, gameState, resources);

            // Act
            game.Init();

            // Assert
            Mock.Get(printer).Verify(p => p.PrintLn(resources.Welcome));
            Mock.Get(printer).Verify(p => p.PrintLn(""));
            Mock.Get(scripter).Verify(s => s.Look());
            Mock.Get(printer).Verify(p => p.Print(resources.Prompt));
        }

        [Test]
        public void ProcessPlayerInput_WhenInputIsLookAndPlayerInStartRoom_ShouldPrintRoom1Description()
        {
            // Arrange
            var resources = new Resources();
            var settings = new GameSettings();
            var printer = new Mock<IPrinter>().Object;
            var items = new Items(resources);
            var player = new Player(items);
            player.CurrentRoom = "room_1";
            var parser = new Parser(player, printer, items, settings, resources);
            var rooms = new Rooms(items, resources);
            var gameState = new GameState();
            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);
            var defaultScripter = new DefaultScripter(resources);

            var game = new Game(player, printer, parser, scripter, rooms, defaultScripter, items, gameState, resources);

            // Act
            game.ProcessPlayerInput("Look");

            // Assert
            Mock.Get(printer).Verify(p => p.PrintLn(resources.Room1));
            Mock.Get(printer).Verify(p => p.Print(resources.Prompt));
        }

        [Test]
        public void Save_WhenGameIsInInitialState_ResultsInInitialStateSerialised()
        {
            // Arrange
            var resources = new Resources();
            var settings = new GameSettings();
            var printer = new Mock<IPrinter>().Object;
            var items = new Items(resources);
            var player = new Player(items);
            player.CurrentRoom = "room_1";
            var parser = new Parser(player, printer, items, settings, resources);
            var rooms = new Rooms(items, resources);
            var gameState = new GameState();
            var scripter = new Scripter(printer, items, rooms, player, gameState, settings, resources);
            var defaultScripter = new DefaultScripter(resources);

            var game = new Game(player, printer, parser, scripter, rooms, defaultScripter, items, gameState, resources);

            // Act
            var result = game.State;

            // Assert
            Assert.AreEqual("LOAD ,,,,,_51,_81,,,,_16,,,_2,,_8,_9,_72,_11,,,,_61,,_59,_2,_2,#BOTTLE,,_56,_76,,_73,_68,,,_14,_17,_25,_18,_24,,_71,,room_1,,0,False,310,0", result);
        }
    }
}
