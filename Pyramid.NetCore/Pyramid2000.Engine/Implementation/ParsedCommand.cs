using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class ParsedCommand : IParsedCommand
    {
        public Function Function { get; set; }
        public IItem Item { get; set; }
    }
}
