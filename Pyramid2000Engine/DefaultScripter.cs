using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public class DefaultScripter
    {
        private static IDictionary<Verb, Script> defaultHandler = new Dictionary<Verb, Script>();

        static DefaultScripter()
        {
            defaultHandler[Verb.North] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.East] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.West] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.South] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.NorthEast] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.SouthEast] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.NorthWest] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.SouthWest] = new Script(s => s.PrintMessageX("THERE IS NO WAY FOR YOU TO GO THAT DIRECTION."));
            defaultHandler[Verb.In] = new Script(s => s.PrintMessageX("I DON'T KNOW IN FROM OUT HERE. USE COMPASS POINTS."));
            defaultHandler[Verb.Out] = new Script(s => s.PrintMessageX("I DON'T KNOW IN FROM OUT HERE. USE COMPASS POINTS."));
            defaultHandler[Verb.Left] = new Script(s => s.PrintMessageX("I AM UNSURE HOW YOU ARE FACING. USE COMPASS POINTS."));
            defaultHandler[Verb.Right] = new Script(s => s.PrintMessageX("I AM UNSURE HOW YOU ARE FACING. USE COMPASS POINTS."));
            defaultHandler[Verb.Panel] = new Script(s => s.PrintMessageX("NOTHING HAPPENS."));
            defaultHandler[Verb.Back] = new Script(s => s.MoveToLastRoom());
            defaultHandler[Verb.Look] = new Script(s => s.PrintRoomDescription());
            defaultHandler[Verb.Score] = new Script(s => s.PrintScore());
            defaultHandler[Verb.Quit] = new Script(s => s.Quit());
            defaultHandler[Verb.Inventory] = new Script(s => s.PrintInventory());
            defaultHandler[Verb.Get] = new Script(s => s.GetScript());
            defaultHandler[Verb.Drop] = new Script(s => s.DropScript());
        }

        public static Script GetDefaultScript(Verb verb)
        {
            Script results;
            if (!defaultHandler.TryGetValue(verb, out results))
            {
                results = null;
            }

            return results;
        }
    }
}
