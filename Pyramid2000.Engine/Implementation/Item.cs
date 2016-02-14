using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Item : IItem
    {
        public Item()
        {
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public bool Packable { get; set; }
        public bool Treasure { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Time { get; set; }
    }
}
