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
    public class ParserTests
    {
        /*
        [Test]
        public void TestEmptyInput()
        {
            var printer = new Mock<IPrinter>(MockBehavior.Strict);
            var parser = new Parser(printer.Object);
            Assert.IsNull(parser.Parse(""));
            printer.VerifyAll();
        }

        [Test]
        public void TestUnknownInput()
        {
            var printer = new Mock<IPrinter>();
            printer.Setup(m => m.PrintLn("I DON'T KNOW THAT WORD."));
            printer.Setup(m => m.PrintLn("I DON'T UNDERSTAND."));
            printer.Setup(m => m.PrintLn("I DON'T KNOW WHAT YOU MEAN."));
            printer.Setup(m => m.PrintLn("WHAT?"));
            printer.Setup(m => m.PrintLn("I DON'T KNOW THAT WORD."));
            printer.Setup(m => m.PrintLn("I DON'T UNDERSTAND."));
            printer.Setup(m => m.PrintLn("I DON'T KNOW WHAT YOU MEAN."));
            printer.Setup(m => m.PrintLn("WHAT?"));

            var parser = new Parser(printer.Object);
            for (var count = 0; count < 8; count++)
            {
                Assert.IsNull(parser.Parse("UNKNOWN"));
            }

            printer.VerifyAll();
        }

        [Test]
        public void TestNounWithoutVerb()
        {
            var printer = new Mock<IPrinter>();
            printer.Setup(m => m.PrintLn("I SEE NO LAMP HERE."));
            var parser = new Parser(printer.Object);
            Assert.IsNull(parser.Parse("LAMP"));
            printer.VerifyAll();
        }

        [TestCase("N", Verb.North)]
        [TestCase("NORTH", Verb.North)]
        [TestCase("E", Verb.East)]
        [TestCase("EAST", Verb.East)]
        [TestCase("W", Verb.West)]
        [TestCase("WEST", Verb.West)]
        [TestCase("S", Verb.South)]
        [TestCase("SOUTH", Verb.South)]
        [TestCase("U", Verb.Up)]
        [TestCase("UP", Verb.Up)]
        [TestCase("D", Verb.Down)]
        [TestCase("DOWN", Verb.Down)]
        [TestCase("IN", Verb.In)]
        [TestCase("INSIDE", Verb.In)]
        [TestCase("OUT", Verb.Out)]
        [TestCase("OUTSID", Verb.Out)]
        [TestCase("PANEL", Verb.Panel)]
        [TestCase("QUIT", Verb.Quit)]
        [TestCase("STOP", Verb.Quit)]
        [TestCase("SCORE", Verb.Score)]
        [TestCase("INVENT", Verb.Inventory)]
        [TestCase("LOOK", Verb.Look)]
        public void TestActionVerb(string originalVerb, Verb verb)
        {
            var printer = new Mock<IPrinter>(MockBehavior.Strict);
            var parser = new Parser(printer.Object);
            var parsedCommand = parser.Parse(originalVerb);
            Assert.IsNotNull(parsedCommand);
            Assert.AreEqual(verb, parsedCommand.Verb);
            Assert.IsNull(parsedCommand.Noun);
            Assert.IsNull(parsedCommand.OriginalNoun);
            Assert.AreEqual(originalVerb, parsedCommand.OriginalVerb);
        }
        */
    }
}
