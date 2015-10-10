using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public class Room : IRoom
    {
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Lit { get; set; }
        public IDictionary<Function, List<object>> Commands { get; set; }

        public IList<ExitType> Exits
        {
            get
            {
                var exits = new List<ExitType>();
                foreach (var command in Commands)
                {
                    switch (command.Key)
                    {
                        case Function.North: exits.Add(ExitType.North); break;
                        case Function.South: exits.Add(ExitType.South); break;
                        case Function.East: exits.Add(ExitType.East); break;
                        case Function.West: exits.Add(ExitType.West); break;
                        case Function.NorthEast: exits.Add(ExitType.NorthEast); break;
                        case Function.SouthEast: exits.Add(ExitType.SouthEast); break;
                        case Function.NorthWest: exits.Add(ExitType.NorthWest); break;
                        case Function.SouthWest: exits.Add(ExitType.SouthWest); break;
                        case Function.Up: exits.Add(ExitType.Up); break;
                        case Function.Down: exits.Add(ExitType.Down); break;
                        case Function.In: exits.Add(ExitType.In); break;
                        case Function.Out: exits.Add(ExitType.Out); break;
                    }
                }

                return exits;
            }
        }
    }
}
