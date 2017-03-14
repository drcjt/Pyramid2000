using System.Collections.Generic;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Player : IPlayer
    {
        private readonly IItems _items;
        public Player(IItems items)
        {
            _items = items;
        }
        public string CurrentRoom { get; set; }

        public IList<IItem> Items { get { return _items.GetItemsAtLocation("pack"); } }
    }
}
