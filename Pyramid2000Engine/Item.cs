using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public class Item
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsPackable { get; set; }
        public bool IsTreasure { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
