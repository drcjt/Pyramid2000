using Moq;
using NUnit.Framework;
using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000EngineTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Items_WhenPlayerNotCarryingAnything_ReturnsEmptyList()
        {
            // Arrange
            var items = Mock.Of<IItems>();
            Mock.Get<IItems>(items).Setup(i => i.GetItemsAtLocation("pack")).Returns(new List<IItem> { });
            var player = new Player(items);

            // Act
            var playersItems = player.Items;

            // Assert
            Assert.AreEqual(0, playersItems.Count);
        }

        [Test]
        public void Items_WhenPlayerCarryingSomething_ReturnsListOfSomething()
        {
            // Arrange
            var items = Mock.Of<IItems>();
            Mock.Get<IItems>(items).Setup(i => i.GetItemsAtLocation("pack")).Returns(new List<IItem> { new Item() });
            var player = new Player(items);

            // Act
            var playersItems = player.Items;

            // Assert
            Assert.AreEqual(1, playersItems.Count);
        }
    }
}
