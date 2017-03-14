using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IDefaultScripter
    {
        Script GetDefaultScript(Function verb);
    }
}
