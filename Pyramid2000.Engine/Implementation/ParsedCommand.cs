using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public class ParsedCommand : IParsedCommand
    {
        public Function Function { get; set; }
        public IItem Item { get; set; }
    }
}
