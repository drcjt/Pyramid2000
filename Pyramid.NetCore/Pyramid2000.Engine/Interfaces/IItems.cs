using System.Collections.Generic;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IItems
    {
        IItem GetExactItemByName(string name);
        IItem GetTopItemByName(string name);
        IItem[] GetAllItems();
        IList<IItem> GetItemsAtLocation(string location);
    }
}
