using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IDefaultScripter
    {
        Script GetDefaultScript(Function verb);
    }
}
