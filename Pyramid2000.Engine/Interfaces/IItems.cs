using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
