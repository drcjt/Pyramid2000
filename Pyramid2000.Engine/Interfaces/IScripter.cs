using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IScripter
    {
        bool Look();
        bool ParseScript(List<object> script, IItem item);
        bool ParseScriptRec(List<object> script);
    }
}
