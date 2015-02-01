using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
{
    public class Room
    {
        public string Description { get; set; }
        public bool Lit { get; set; }
        public IDictionary<string, List<object>> Commands { get; set; }
    }
}
