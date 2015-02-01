using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
{
    public interface IScripter
    {
        bool Look();
        bool ParseScript(List<object> script, Item item);
        bool ParseScriptRec(List<object> script);
    }
}
