using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public class Room
    {
        public enum Exit
        {
            North,
            South,
            East,
            West,
            NorthEast,
            SouthEast,
            NorthWest,
            SouthWest,
            Up,
            Down,
            In,
            Out
        }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Lit { get; set; }
        public IDictionary<string, List<object>> Commands { get; set; }

        public IList<Exit> Exits
        {
            get
            {
                var exits = new List<Exit>();
                foreach (var command in Commands)
                {
                    switch (command.Key)
                    {
                        case "_n": exits.Add(Exit.North); break;
                        case "_s": exits.Add(Exit.South); break;
                        case "_e": exits.Add(Exit.East); break;
                        case "_w": exits.Add(Exit.West); break;
                        case "_ne": exits.Add(Exit.NorthEast); break;
                        case "_se": exits.Add(Exit.SouthEast); break;
                        case "_nw": exits.Add(Exit.NorthWest); break;
                        case "_sw": exits.Add(Exit.SouthWest); break;
                        case "_u": exits.Add(Exit.Up); break;
                        case "_d": exits.Add(Exit.Down); break;
                        case "_in": exits.Add(Exit.In); break;
                        case "_out": exits.Add(Exit.Out); break;
                    }
                }

                return exits;
            }
        }
    }
}
