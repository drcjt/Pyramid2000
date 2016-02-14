using System.Collections.Generic;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IPlayer
    {
        string CurrentRoom { get; set; }
        IList<IItem> Items { get; }
    }
}
