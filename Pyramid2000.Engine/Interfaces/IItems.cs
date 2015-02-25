using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public interface IItems
    {
        Item GetExactItemByName(string name);
        Item GetTopItemByName(string name);
        Item[] GetAllItems();
        IList<Item> GetItemsAtLocation(string location);
    }
}
