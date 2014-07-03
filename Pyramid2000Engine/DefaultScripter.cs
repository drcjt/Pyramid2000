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
            defaultHandler[Verb.North] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.East] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.West] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.South] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.NorthEast] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.SouthEast] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.NorthWest] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.SouthWest] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_That_Way));
            defaultHandler[Verb.In] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_In_Or_Out));
            defaultHandler[Verb.Out] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_In_Or_Out));
            defaultHandler[Verb.Left] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_Left_Or_Right));
            defaultHandler[Verb.Right] = new Script(s => s.PrintMessageX(Resources.Message_Cant_Go_Left_Or_Right));
            defaultHandler[Verb.Panel] = new Script(s => s.PrintMessageX(Resources.Message_Nothing_Happens));
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
