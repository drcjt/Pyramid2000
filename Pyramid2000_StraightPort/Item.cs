using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
{
    public class Item
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Packable { get; set; }
        public bool Treasure { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Time { get; set; }
    }
}
