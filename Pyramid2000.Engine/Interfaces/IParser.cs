using System.Collections.Generic;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IParser
    {
        IParsedCommand ParseInput(string command);

        IList<string> GetWords(bool nouns);
    }
}
