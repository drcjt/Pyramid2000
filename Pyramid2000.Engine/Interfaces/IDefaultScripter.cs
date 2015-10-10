using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IDefaultScripter
    {
        List<object> GetDefaultScript(Function verb);
    }
}
