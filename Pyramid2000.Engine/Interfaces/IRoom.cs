using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine.Interfaces
{
    public enum ExitType
    {
        North,
        South,
        East,
        West,
        NorthEast,
        SouthEast,
        NorthWest,
        SouthWest,
        Up,
        Down,
        In,
        Out
    }

    public interface IRoom
    {
        string ShortDescription { get; set; }
        string Description { get; set; }
        bool Lit { get; set; }
        IDictionary<Function, Script> Commands { get; set; }

        IList<ExitType> Exits { get; }
    }
}
