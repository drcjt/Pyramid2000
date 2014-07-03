using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public interface IItems
    {
        Item GetInputItem(Noun noun, Predicate<Location> locationPredicate);
        Item GetItemByName(string name);      
        Item GetTopItemByName(string name);
        IList<Item> GetAllItems();
        IList<Item> GetItemsAtLocation(Location location);
    }
}
