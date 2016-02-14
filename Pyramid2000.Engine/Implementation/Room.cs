using System.Collections.Generic;

using Pyramid2000.Engine.Interfaces;

using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine
{
    public class Room : IRoom
    {
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Lit { get; set; }
        public IDictionary<Function, Script> Commands { get; set; }

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
