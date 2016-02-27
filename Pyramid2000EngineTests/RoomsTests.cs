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
    public class RoomsTests
    {
        [Test]
        public void Scripter_GetScripter_ReturnsScripterSet()
        {
            // Arrange
            var resources = Mock.Of<IResources>();
            var items = Mock.Of<IItems>();
            var scripter = Mock.Of<IScripter>();
            var rooms = new Rooms(items, resources);
            rooms.Scripter = scripter;

            // Act
            var result = rooms.Scripter;

            // Assert
            Assert.AreEqual(result, scripter);
        }

        [Test]
        public void GetRoom_WithUnknownName_ReturnsNull()
        {
            // Arrange
            var resources = Mock.Of<IResources>();
            var items = Mock.Of<IItems>();
            var rooms = new Rooms(items, resources);

            // Act
            var result = rooms.GetRoom("Unknown Room");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CalculateScore_ReturnsZero()
        {
            // Arrange
            var resources = Mock.Of<IResources>();
            var items = Mock.Of<IItems>();
            var rooms = new Rooms(items, resources);

            // Act
            var result = rooms.CalculateScore();

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
