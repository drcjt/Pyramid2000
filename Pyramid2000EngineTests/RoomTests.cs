using NUnit.Framework;
using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000EngineTests
{
    [TestFixture]
    class RoomTests
    {
        [TestCase(Function.North, ExitType.North)]
        [TestCase(Function.South, ExitType.South)]
        [TestCase(Function.East, ExitType.East)]
        [TestCase(Function.West, ExitType.West)]
        [TestCase(Function.NorthEast, ExitType.NorthEast)]
        [TestCase(Function.SouthEast, ExitType.SouthEast)]
        [TestCase(Function.NorthWest, ExitType.NorthWest)]
        [TestCase(Function.SouthWest, ExitType.SouthWest)]
        [TestCase(Function.Up, ExitType.Up)]
        [TestCase(Function.Down, ExitType.Down)]
        [TestCase(Function.In, ExitType.In)]
        [TestCase(Function.Out, ExitType.Out)]
        public void Exits_GetAllExits(Function f, ExitType e)
        {
            // Arrange
            var room = new Room();
            room.Commands = new Dictionary<Function, Script>
            {
                { f, null },
            };

            // Act
            var result = room.Exits;

            // Assert
            Assert.IsTrue(result.Contains(e));
        }
    }
}
