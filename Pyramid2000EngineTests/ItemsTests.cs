using NUnit.Framework;
using Pyramid2000.Engine;
using Pyramid2000.Engine.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000EngineTests
{
    [TestFixture]
    public class ItemsTests
    {
        [Test]
        public void GetExactItemByName_WhenItemNameUnknown_ReturnsNull()
        {
            // Arrange
            var resources = new Resources();

            var items = new Items(resources);

            // Act
            var result = items.GetExactItemByName("Unknown Item");

            // Assert
            Assert.IsNull(result);
        }
    }
}
